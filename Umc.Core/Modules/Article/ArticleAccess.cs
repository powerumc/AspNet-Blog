using System;
using System.Data;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;

using Umc.Core.Data;
using Umc.Core.Modules.Category.Model;
using Umc.Core.Modules.Article.Model;

namespace Umc.Core.Modules.Article
{
	internal class ArticleAccess : AbstractDataAccess
	{
		#region ��ƼŬ ����
		private const string REPOSITORY_ARTICLE	= "Article";

		/// <summary>
		/// ��ƼŬ�� �����Ѵ�.
		/// </summary>
		/// <param name="model"></param>
		public static int InsertArticle(ArticleModel model, HttpFileCollection fileCollection)
		{
			object trackbackUrl		= model.TrackbackUrl.Length > 0 ? (object)model.TrackbackUrl : DBNull.Value;

			SqlParameter[] param = 
				{
					CreateInParam("@CategoryID",		SqlDbType.Int, 4,					model.CategoryID),
					CreateInParam("@Title",				SqlDbType.VarChar,255,				model.Title),
					CreateInParam("@Content",			SqlDbType.Text,Int32.MaxValue,		model.Content),
					CreateInParam("@TrackbackUrl",		SqlDbType.VarChar,255,				trackbackUrl),
					CreateInParam("@PublicFlag",		SqlDbType.Bit,1,					model.PublicFlag),
					CreateInParam("@PublicRss",			SqlDbType.Bit,1,					model.PublicRss),
					CreateInParam("@AllowComment",		SqlDbType.Bit,1,					model.AllowComment),
					CreateInParam("@AllowTrackback",	SqlDbType.Bit,1,					model.AllowTrackback),
					CreateReturnValue()
				};

			SqlCommand cmd		= GetSpCommand("UBA_InsertArticle", param, IsolationLevel.ReadCommitted);

			try
			{
				cmd.ExecuteNonQuery();
				int seq = (int)cmd.Parameters["@ReturnValue"].Value;

				// ÷������ ����
				for(int i=0; i<fileCollection.Count; i++)
				{
					if( fileCollection[i].ContentLength<=0) continue;
					string path = string.Format("{0}/{1}", REPOSITORY_ARTICLE, seq.ToString());
					RepositoryManager.GetInstance().SaveAs( path, fileCollection[i]);

					AttachFileModel fileModel = new AttachFileModel();
					fileModel.ArticleNo		= seq;
					fileModel.FilePath		= path + "/" + Path.GetFileName( fileCollection[i].FileName );
					fileModel.FileSize		= fileCollection[i].ContentLength;

					InsertAttachFile( cmd, fileModel );

					fileModel				= null;
				}

				// �±� ����
				if (!InsertTag(cmd, seq, model.Tag))
				{
					throw new UmcDataException("Tag ���� �� ����");
				}
					
				ReleaseCommandWithCommit( cmd );

				return seq;
			}
			catch ( Exception ex )
			{
				ReleaseCommandWithRollback( cmd );
				throw new UmcDataException("UBA_InsertArticle ���ν��� ȣ���� ����",ex );
			}
		}

		/// <summary>
		/// ��ƼŬ�� �����Ѵ�.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="fileCollection"></param>
		/// <returns></returns>
		public static bool UpdateArticle(ArticleModel model, HttpFileCollection fileCollection)
		{
			object trackbackUrl = model.TrackbackUrl.Length > 0 ? (object)model.TrackbackUrl : DBNull.Value;

			SqlParameter[] param = 
				{
					CreateInParam("@ArticleNo",					SqlDbType.Int,4,				model.ArticleNo),
					CreateInParam("@CategoryID",				SqlDbType.Int, 4,				model.CategoryID),
					CreateInParam("@Title",						SqlDbType.VarChar,255,			model.Title),
					CreateInParam("@Content",					SqlDbType.Text,Int32.MaxValue,	model.Content),
					CreateInParam("@TrackbackUrl",				SqlDbType.VarChar,255,			trackbackUrl),
					CreateInParam("@PublicFlag",				SqlDbType.Bit,1,				model.PublicFlag),
					CreateInParam("@PublicRss",					SqlDbType.Bit,1,				model.PublicRss),
					CreateInParam("@AllowComment",				SqlDbType.Bit,1,				model.AllowComment),
					CreateInParam("@AllowTrackback",			SqlDbType.Bit,1,				model.AllowTrackback)
				};

			SqlCommand cmd = GetSpCommand("UBA_UpdateArticle", param, IsolationLevel.ReadCommitted);

			try
			{
				cmd.ExecuteNonQuery();

				// ÷������ ����
				for (int i = 0; i < fileCollection.Count; i++)
				{
					if (fileCollection[i].ContentLength <= 0) continue;
					string path = string.Format("{0}/{1}", REPOSITORY_ARTICLE, model.ArticleNo.ToString());
					RepositoryManager.GetInstance().SaveAs(path, fileCollection[i]);

					AttachFileModel fileModel = new AttachFileModel();
					fileModel.ArticleNo = model.ArticleNo;
					fileModel.FilePath = path + "/" + Path.GetFileName(fileCollection[i].FileName);
					fileModel.FileSize = fileCollection[i].ContentLength;

					InsertAttachFile(cmd, fileModel);

					fileModel = null;
				}

				// �±׸� ����� ������ �±׸� �����Ѵ�.
				RemoveTagAll( cmd, model.ArticleNo );				
				if (!InsertTag(cmd, model.ArticleNo, model.Tag))
				{
					throw new UmcDataException("Tag ������ ����");
				}

				ReleaseCommandWithCommit(cmd);

				return true;
			}
			catch (Exception ex)
			{
				ReleaseCommandWithRollback(cmd);
				//return false;
				throw new UmcDataException("UBA_UpdateArticle ���ν��� ȣ���� ����", ex);
			}
		}

		/// <summary>
		/// ��ƼŬ�� �����Ѵ�.
		/// </summary>
		/// <param name="articleNo"></param>
		/// <returns></returns>
		public static bool RemoveArticleByNo(int articleNo)
		{
			SqlParameter[] param	= {
				CreateInParam("@ArticleNo",			SqlDbType.Int,4,			articleNo )
			};

			SqlCommand cmd			= GetSpCommand("UBA_RemoveArticle", param, IsolationLevel.ReadUncommitted);

			try
			{
				cmd.ExecuteNonQuery();
				ReleaseCommandWithCommit(cmd);
				return true;
			}
			catch (Exception ex)
			{
				ReleaseCommandWithRollback(cmd);
				throw new UmcDataException("UBA_RemoveArticle ���ν��� ȣ���� ����", ex);
			}
		}

		/// <summary>
		/// ī�װ��� ��ƼŬ ����Ʈ�� �����´�
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public static ArticleBindModel GetArticleList(CategoryNodeValue node)
		{
			SqlParameter[] param = {
				CreateInParam("@CategoryID",		SqlDbType.Int,4,		node.CategoryID),
				CreateInParam("@CategoryStep",		SqlDbType.Int,4,		node.CategoryStep)
			};

			SqlCommand cmd				= GetSpCommand("UBA_GetArticleListByCategoryID", param);
			SqlDataReader reader		= cmd.ExecuteReader( CommandBehavior.CloseConnection );
			ArticleBindModel bindModel	= new ArticleBindModel();
			try
			{
				while (reader.Read())
				{
					ArticleModel model = new ArticleModel();

					FillArticle(reader, model);

					bindModel.Add(model);
					model = null;
				}

				return bindModel;
			}
			catch ( Exception ex )
			{
				throw new UmcDataException("UBA_GetArticleListByCategoryID ���ν��� ȣ���� ����", ex);
			}
			finally
			{
				reader.Close();
				ReleaseCommand(cmd);
			}
		}

		/// <summary>
		/// ��¥�� ��ƼŬ�� �����´�.
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static ArticleBindModel GetArticleList(string date)
		{
			SqlParameter[] param = {
				CreateInParam("@Date",SqlDbType.VarChar,20,		date)
			};

			SqlCommand cmd				= GetSpCommand("UBA_GetArticleListByDate", param);
			SqlDataReader reader		= cmd.ExecuteReader(CommandBehavior.CloseConnection);
			ArticleBindModel bindModel	= new ArticleBindModel();
			try
			{
				while (reader.Read())
				{
					ArticleModel model = new ArticleModel();

					FillArticle(reader, model);

					bindModel.Add(model);
					model = null;
				}

				return bindModel;
			}
			catch (Exception ex)
			{
				throw new UmcDataException("UBA_GetArticleListByDate ���ν��� ȣ���� ����", ex);
			}
			finally
			{
				reader.Close();
				ReleaseCommand(cmd);
			}
		}

		/// <summary>
		/// �˻� �Ǵ� ������ ���� ��ƼŬ�� �����´�.
		/// </summary>
		/// <param name="currentPage"></param>
		/// <param name="pageCount"></param>
		/// <param name="searchMode"></param>
		/// <param name="searchKeyword"></param>
		/// <param name="publicArticle">��������Ʈ true / ����� ����Ʈ���� false</param>
		/// <returns></returns>
		public static ArticleBindModel GetArticleList(int currentPage, int pageCount, string searchMode, string searchKeyword, bool publicArticle)
		{
			SqlParameter[] param = {
				CreateInParam("@CurrentPage",			SqlDbType.Int,4,			currentPage),
				CreateInParam("@PageSize",				SqlDbType.Int,4,			pageCount),
				CreateInParam("@SearchMode",			SqlDbType.VarChar,20,		searchMode),
				CreateInParam("@SearchKeyword",			SqlDbType.VarChar,20,		searchKeyword),
				CreateInParam("@PublicArticle",			SqlDbType.Bit,1,			publicArticle)
			};

			SqlCommand cmd				= GetSpCommand("UBA_GetArticleList", param);
			SqlDataReader reader		= cmd.ExecuteReader( CommandBehavior.CloseConnection );
			ArticleBindModel bindModel	= new ArticleBindModel();

			try
			{
				if( reader.Read() )
					bindModel.TotalCount= (int)reader["Count"];

				if( !reader.NextResult() ) return bindModel;

				while (reader.Read())
				{
					ArticleModel model	= new ArticleModel();
					FillArticle( reader, model );

					bindModel.Add( model );
					model				= null;
				}

				return bindModel;
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}

		/// <summary>
		/// �±׷� ��ƼŬ�� �����´�.
		/// </summary>
		/// <param name="currentPage"></param>
		/// <param name="pageCount"></param>
		/// <param name="tag"></param>
		/// <param name="publicArticle"></param>
		/// <returns></returns>
		public static ArticleBindModel GetArticleListByTag(string tag, bool publicArticle)
		{
			SqlParameter[] param = {
				CreateInParam("@Tag",			SqlDbType.VarChar,50,			tag),
				CreateInParam("@PublicArticle",	SqlDbType.Bit,1,				publicArticle)
			};

			SqlCommand cmd					= GetSpCommand("UBA_GetArticleListByTag", param);
			SqlDataReader reader			= cmd.ExecuteReader( CommandBehavior.CloseConnection );
			ArticleBindModel bindModel		= new ArticleBindModel();

			try
			{
				while (reader.Read())
				{
					ArticleModel model = new ArticleModel();
					FillArticle(reader, model);
					bindModel.Add(model);

					model = null;
				}

				return bindModel;
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}

		/// <summary>
		/// ��¥���� ��ƼŬ ������ �����´�.
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static NameValueCollection GetArticleListGroupByDate(string date)
		{
			SqlParameter[] param = { CreateInParam("@Date", SqlDbType.VarChar,10, date) };

			SqlCommand cmd		= GetSpCommand("UBA_GetArticleGroupByDate", param );

			try
			{
				SqlDataReader reader = cmd.ExecuteReader( CommandBehavior.CloseConnection );
				NameValueCollection dic = new NameValueCollection();
				while (reader.Read())
				{
					dic.Add( reader["Date"].ToString(), reader["ArticleCount"].ToString() );
				}

				return dic;
			}
			catch(Exception ex)
			{
				throw new UmcDataException("UBA_GetArticleGroupByDate ���ν��� ȣ���� ����", ex);
			}
			finally
			{
				ReleaseCommand( cmd );
			}
		}

		/// <summary>
		/// ��ƼŬ��ȣ�� ��ƼŬ�� �����´�.
		/// </summary>
		/// <param name="articleNo"></param>
		/// <returns></returns>
		public static ArticleModel GetArticleByArticleNo(int articleNo)
		{
			SqlParameter[] param = { CreateInParam("@ArticleNo",SqlDbType.Int, 4, articleNo) };

			SqlCommand cmd			= GetSpCommand("UBA_GetArticleByArticleNo", param);
			SqlDataReader reader	= cmd.ExecuteReader(CommandBehavior.CloseConnection);
			ArticleModel model		= null;

			try
			{
				if( !reader.Read() ) return model;
				model = new ArticleModel();
				FillArticle( reader, model );
				FillTag(reader, model);
				FillAttachFile( reader, model );

				return model;
			}
			catch (Exception ex)
			{
				throw new UmcDataException("UBA_GetArticleByArticleNo ���ν��� ȣ���� ����", ex);
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}

		/// <summary>
		/// �ֱ� ��ƼŬ�� �����´�.
		/// </summary>
		/// <param name="count"></param>
		/// <returns></returns>
		public static ArticleBindModel GetRecentArticleList(int count)
		{
			SqlParameter[] param = { CreateInParam("@Count", SqlDbType.Int,4, count) };

			SqlCommand cmd			= GetSpCommand("UBA_GetRecentArticle", param);
			SqlDataReader reader	= cmd.ExecuteReader(CommandBehavior.CloseConnection);
			ArticleBindModel bindModel = new ArticleBindModel();

			try
			{
				while (reader.Read())
				{
					ArticleModel model = new ArticleModel();
					FillArticle(reader, model);
					
					bindModel.Add(model);

					model = null;
				}
				return bindModel;
			}
			catch (Exception ex)
			{
				throw new UmcDataException("UBA_GetRecentArticle ���ν��� ȣ���� ����", ex);
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}

		private static void FillArticle(IDataRecord reader,ArticleModel model)
		{
			model.ArticleNo			= (int)reader["ArticleNo"];
			model.CategoryID		= (int)reader["CategoryID"];
			model.Title				= (string)reader["Title"];
			model.Content			= (string)reader["Content"];
			model.TrackbackUrl		= reader["TrackbackUrl"] != DBNull.Value ? (string)reader["TrackbackUrl"] : null;
			model.ViewCount			= (int)reader["ViewCount"];
			model.TrackbackCount	= (int)reader["TrackbackCount"];
			model.CommentCount		= (int)reader["CommentCount"];
			model.PublicFlag		= (bool)reader["PublicFlag"];
			model.PublicRss			= (bool)reader["PublicRss"];
			model.AllowComment		= (bool)reader["AllowComment"];
			model.AllowTrackback	= (bool)reader["AllowTrackback"];
			model.CategoryLCode		= ( reader["CategoryLCode"] != DBNull.Value ) ? (int)reader["CategoryLCode"] : -1;
			model.CategoryMCode		= ( reader["CategoryMCode"] != DBNull.Value ) ? (int)reader["CategoryMCode"] : -1;
			model.InsertDate		= ( reader["InsertDate"] != DBNull.Value) ? reader["InsertDate"] : null;
			model.UpdateDate		= ( reader["UpdateDate"] != DBNull.Value) ? reader["UpdateDate"] : null;
			try
			{
				model.CategoryGroup = (int)reader["CategoryGroup"];
				model.CategoryOrder = (int)reader["CategoryStep"];
				model.CategoryStep	= (int)reader["CategoryOrder"];
			}
			catch (IndexOutOfRangeException ex) { }
			try
			{
				model.CategoryMTitle = (string)reader["CategoryMTitle"];
			}
			catch (IndexOutOfRangeException ex) { }

			try
			{
				model.Tag.Add((string)reader["Tag"]);
			}
			catch (IndexOutOfRangeException ex)
			{
			}
		}
		#endregion

		#region �±� ����
		private static void FillTag(SqlDataReader reader, ArticleModel model)
		{
			if (reader.NextResult())
			{
				while (reader.Read())
				{
					model.Tag.Add(new TagModel((int)reader["TagNo"], (string)reader["TagName"], (DateTime)reader["InsertDate"]));
				}
			}
		}

		/// <summary>
		/// �±׸� ����
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="articleNo"></param>
		/// <param name="bindModel"></param>
		/// <returns></returns>
		public static bool InsertTag(SqlCommand cmd, int articleNo, TagBindModel bindModel)
		{
			try
			{
				cmd.Parameters.Clear();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText	= "UAT_InsertTag";

				foreach( TagModel model in  bindModel )
				{
					cmd.Parameters.Add("@ArticleNo", SqlDbType.Int,4);
					cmd.Parameters.Add("@TagName", SqlDbType.VarChar,50);

					cmd.Parameters["@ArticleNo"].Value	= articleNo;
					cmd.Parameters["@TagName"].Value	= model.TagName.Trim();

					cmd.ExecuteNonQuery();

					cmd.Parameters.Clear();
				}

				return true;
			}
			catch (Exception ex)
			{
				throw new UmcDataException("UAT_InsertTag ���ν��� ȣ���� ����", ex);
			}
		}

		/// <summary>
		/// �±� ����Ʈ�� �����´�.
		/// </summary>
		/// <returns></returns>
		public static TagBindModel GetTagList()
		{
			SqlCommand cmd			= GetSpCommand("UAT_GetTagList");
			SqlDataReader reader	= cmd.ExecuteReader(CommandBehavior.CloseConnection);
			TagBindModel bindModel	= null;
			try
			{
				bindModel			= new TagBindModel();

				while (reader.Read())
				{
					bindModel.Add(new TagModel(reader["TagName"].ToString()));
				}

				return bindModel;
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}

		/// <summary>
		/// �±׸� �����Ѵ�.
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="articleNo"></param>
		public static void RemoveTagAll(SqlCommand cmd, int articleNo)
		{
			cmd.Parameters.Clear();

			cmd.Parameters.Add("@ArticleNo", SqlDbType.Int,4);
			cmd.Parameters["@ArticleNo"].Value = articleNo;

			cmd.CommandText = "DELETE Tag WHERE ArticleNo=@ArticleNo";
			cmd.CommandType = CommandType.Text;
			
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// �±� �̸����� �±׸� �����Ѵ�.
		/// </summary>
		/// <param name="tagName"></param>
		public static void RemoveTagByTagName(string tagName)
		{
			SqlParameter[] param = {
				CreateInParam("@TagName", SqlDbType.VarChar, 100, tagName)
			};

			SqlCommand cmd	= GetRawCommand("DELETE Tag WHERE TagName=@TagName", param);

			try
			{
				cmd.ExecuteNonQuery();
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}

		/// <summary>
		/// ������� ����.
		/// </summary>
		/// <param name="articleNo"></param>
		/// <param name="addNumber"></param>
		public static void AddCommentCount(int articleNo, int addNumber)
		{
			SqlParameter[] param = {
				CreateInParam("@ArticleNo",				SqlDbType.Int,4,				articleNo),
				CreateInParam("@AddNumber",				SqlDbType.Int,4,				addNumber)
			};

			SqlCommand cmd			= GetSpCommand("UBA_AddCommentCount",param);
			cmd.ExecuteNonQuery();

			ReleaseCommand(cmd);
		}
		#endregion

		#region ÷������ ����
		private static void InsertAttachFile(SqlCommand cmd, AttachFileModel model)
		{
			cmd.Parameters.Clear();

			cmd.CommandText = "UAA_InsertAttachFile";
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.Add("@ArticleNo", SqlDbType.Int);
			cmd.Parameters.Add("@FilePath", SqlDbType.VarChar,255);
			cmd.Parameters.Add("@FileSize", SqlDbType.Int);

			cmd.Parameters["@ArticleNo"].Value	= model.ArticleNo;
			cmd.Parameters["@FilePath"].Value	= model.FilePath;
			cmd.Parameters["@FileSize"].Value	= model.FileSize;

			cmd.ExecuteNonQuery();
		}

		private static void FillAttachFile(SqlDataReader reader, ArticleModel model)
		{
			if( !reader.NextResult() ) return;

			while (reader.Read())
			{
				AttachFileModel fileModel = new AttachFileModel((int)reader["FileNo"]);
				fileModel.ArticleNo		= (int)reader["ArticleNo"];
				fileModel.FilePath		= (string)reader["FilePath"];
				fileModel.FileSize		= (int)reader["FileSize"];
				fileModel.DownCount		= (int)reader["DownCount"];
				fileModel.InsertDate	= (DateTime)reader["InsertDate"];

				model.AttachFile.Add( fileModel );

				fileModel				= null;
			}
		}

		/// <summary>
		/// ���Ϲ�ȣ�� ÷�������� �����´�.
		/// </summary>
		/// <param name="fileNo"></param>
		/// <returns></returns>
		public static AttachFileModel GetAttachFileByFileNo(int fileNo)
		{
			SqlParameter[] param = {
				CreateInParam("@FileNo", SqlDbType.Int, 4, fileNo)
			};

			SqlCommand cmd		= GetRawCommand("SELECT * FROM AttachFile WHERE FileNo=@FileNo", param);
			SqlDataReader reader= cmd.ExecuteReader(CommandBehavior.CloseConnection);

			if( !reader.Read()) return new AttachFileModel();

			AttachFileModel fileModel = new AttachFileModel((int)reader["FileNo"]);
			fileModel.ArticleNo = (int)reader["ArticleNo"];
			fileModel.FilePath = (string)reader["FilePath"];
			fileModel.FileSize = (int)reader["FileSize"];
			fileModel.DownCount = (int)reader["DownCount"];
			fileModel.InsertDate = (DateTime)reader["InsertDate"];

			return fileModel;
		}

		/// <summary>
		/// ÷�������� �����Ѵ�. ���������� ���ŵȴ�.
		/// </summary>
		/// <param name="fileNo"></param>
		/// <returns></returns>
		public static bool RemoveAttachFileByFileNo(int fileNo)
		{
			SqlParameter[] param = {
				CreateInParam("@FileNo", SqlDbType.Int,4, fileNo)
			};

			SqlCommand cmd		= GetRawCommand("SELECT FilePath FROM AttachFile WHERE FileNo=@FileNo; DELETE AttachFile WHERE FileNo=@FileNo", param, IsolationLevel.ReadUncommitted);

			try
			{
				string filePath = (string)cmd.ExecuteScalar();
				string path = string.Format("{0}/{1}",
					RepositoryManager.GetInstance().RepositoryDirectory,
					filePath
				);

				File.Delete( path );

				ReleaseCommandWithCommit(cmd);

				return true;
			}
			catch (Exception ex)
			{
				ReleaseCommandWithRollback(cmd);

				return false;
			}
		}

		/// <summary>
		/// ÷������ �ٿ�α� Ƚ���� ����
		/// </summary>
		/// <param name="fileNo"></param>
		public static void AddDownloadCount(int fileNo)
		{
			SqlParameter[] param	= {
				CreateInParam("@FileNo",				SqlDbType.Int,4,		fileNo)
			};

			SqlCommand cmd		= GetRawCommand("UPDATE AttachFile SET DownCount=DownCount+1 WHERE FileNo=@FileNo", param, IsolationLevel.ReadUncommitted);

			cmd.ExecuteNonQuery();
		}
		#endregion
	}
}
