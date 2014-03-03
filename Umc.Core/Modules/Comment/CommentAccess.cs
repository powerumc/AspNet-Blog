using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Umc.Core.Data;
using Umc.Core.Modules.Comment.Model;

namespace Umc.Core.Modules.Comment
{
	internal class CommentAccess : AbstractDataAccess
	{
		/// <summary>
		/// 덧글을 추가한다.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public static int InsertComment(CommentModel model)
		{
			object email = model.UserEmail != null ? (object)model.UserEmail : DBNull.Value;

			SqlParameter[] param = {
				CreateInParam("@ArticleNo", SqlDbType.Int,4,		model.ArticleNo),
				CreateInParam("@CommentGroup",SqlDbType.Int,4,		model.CommentGroup),
				CreateInParam("@CommentStep",SqlDbType.Int,4,		model.CommentStep),
				CreateInParam("@CommentOrder",SqlDbType.Int,4,		model.CommentOrder),
				CreateInParam("@UserEmail",SqlDbType.VarChar,20,	email),
				CreateInParam("@UserName",SqlDbType.VarChar,20,		model.UserName),
				CreateInParam("@UserBlogUrl",SqlDbType.VarChar,255,	model.UserBlogUrl),
				CreateInParam("@Content",SqlDbType.Text,Int32.MaxValue, model.Content ),
				CreateInParam("@Password",SqlDbType.VarChar,100,	model.Password),
				CreateInParam("@UserIP",SqlDbType.VarChar,20,		model.UserIP),
				CreateInParam("@Mode",SqlDbType.Int,4,				(int)model.CommentType),
				CreateReturnValue()
			};

			SqlCommand cmd = GetSpCommand("UBC_InsertComment", param, IsolationLevel.ReadUncommitted);

			try
			{
				cmd.ExecuteNonQuery();
				int identity = (int)cmd.Parameters["@ReturnValue"].Value;
				ReleaseCommandWithCommit(cmd);
				return identity;
			}
			catch (Exception ex)
			{
				ReleaseCommandWithRollback(cmd);
				//throw new UmcDataException("UBC_InsertComment 호출중 에러",ex);
				throw ex;
			}
		}

		/// <summary>
		/// 덧글 리스트를 가져온다.
		/// </summary>
		/// <param name="articleNo"></param>
		/// <returns></returns>
		public static CommentBindModel GetCommentList(int articleNo)
		{
			SqlParameter[] param = { CreateInParam("@ArticleNo", SqlDbType.Int, 4, articleNo) };

			SqlCommand cmd = GetSpCommand("UBC_GetCommentList", param);
			SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

			CommentBindModel bindModel;
			try
			{
				bindModel = new CommentBindModel(articleNo);

				while (reader.Read())
				{
					CommentModel model = new CommentModel();

					FillComment( reader, model );

					bindModel.Add( model );

					model = null;
				}

				return bindModel;
			}
			catch( Exception ex )
			{
				throw  ex;
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}

		/// <summary>
		/// 덧글을 삭제한다.
		/// 0:실패(자식덧글이있을때) 1:성공
		/// </summary>
		/// <param name="commentNo"></param>
		public static int RemoveComment(int commentNo)
		{
			SqlParameter[] param = { 
				CreateInParam("@CommentNo", SqlDbType.Int, 4, commentNo ),
				CreateReturnValue()
			};

			SqlCommand cmd = GetSpCommand("UBC_RemoveComment", param, IsolationLevel.ReadUncommitted );

			try
			{
				cmd.ExecuteNonQuery();
				int val = (int)cmd.Parameters["@ReturnValue"].Value;

				ReleaseCommandWithCommit(cmd);
				return val;
			}
			catch(Exception ex )
			{
				ReleaseCommandWithRollback(cmd);
				throw new UmcDataException("UBC_RemoveComment 프로시져 호출중 에러",ex);
			}
		}

		/// <summary>
		/// 댓글 번호로 댓글을 가져온다.
		/// </summary>
		/// <param name="commentNo"></param>
		/// <returns></returns>
		public static CommentModel GetComment(int commentNo)
		{
			SqlParameter[] param	= { CreateInParam("@CommentNo", SqlDbType.Int,4, commentNo ) };

			SqlCommand cmd			= GetSpCommand("UBC_GetComment", param );
			SqlDataReader reader	= cmd.ExecuteReader(CommandBehavior.CloseConnection);
			CommentModel model		= null;

			try
			{
				if (!reader.Read()) return model;

				model			= new CommentModel();
				FillComment(reader, model);

				return model;
			}
			catch (Exception ex)
			{
				throw new UmcDataException("UBC_GetComment 프로시져 호출중 에러", ex);
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}

		/// <summary>
		/// 댓글을 수정한다.
		/// </summary>
		/// <param name="model"></param>
		public static void UpdateComment(CommentModel model)
		{
			SqlParameter[] param = 
				{
					CreateInParam("@CommentNo", SqlDbType.Int, 4,		model.CommentNo),
					CreateInParam("@UserName",	SqlDbType.VarChar,20,	model.UserName),
					CreateInParam("@UserBlogUrl",SqlDbType.VarChar,255,	model.UserBlogUrl),
					CreateInParam("@Content",	SqlDbType.Text, Int32.MaxValue, model.Content),
					CreateInParam("@Password",	SqlDbType.VarChar,100,	model.Password )
				};

			SqlCommand cmd		= GetSpCommand("UBC_UpdateComment", param, IsolationLevel.ReadUncommitted);

			try
			{
				cmd.ExecuteNonQuery();
				ReleaseCommandWithCommit(cmd);
			}
			catch (Exception ex)
			{
				ReleaseCommandWithRollback(cmd);
				throw new UmcDataException("UBC_UpdateComment 프로시져 호출중 에러", ex);
			}
		}

		/// <summary>
		/// 최신 댓글 리스트를 갯수만큼 가져온다.
		/// </summary>
		/// <param name="count"></param>
		/// <returns></returns>
		public static CommentBindModel GetRecentCommentList(int count)
		{
			SqlParameter[] param = { CreateInParam("@Count", SqlDbType.Int,4, count ) };

			SqlCommand cmd		= GetSpCommand("UBC_GetRecentCommentList", param);
			SqlDataReader reader= cmd.ExecuteReader(CommandBehavior.CloseConnection);
			CommentBindModel bindModel	= new CommentBindModel();

			try
			{
				while(reader.Read())
				{
					CommentModel model = new CommentModel();
					FillComment( reader, model );
					bindModel.Add( model );

					model				= null;
				}

				return bindModel;
			}
			catch( Exception ex)
			{
				throw new UmcDataException("UBC_GetRecentCommentList 프로시져 호출중 에러", ex);
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}

		/// <summary>
		/// 클래스에 덧글을 채운다.
		/// </summary>
		/// <param name="row"></param>
		/// <param name="Model"></param>
		private static void FillComment(IDataRecord row, CommentModel Model)
		{
			Model.ArticleNo		= (int)row["ArticleNo"];
			Model.CommentGroup	= (int)row["CommentGroup"];
			Model.CommentNo		= (int)row["CommentNo"];
			Model.CommentOrder	= (int)row["CommentOrder"];
			Model.CommentStep	= (int)row["CommentStep"];
			Model.Content		= (string)row["Content"];
			Model.InsertDate	= (DateTime)row["InsertDate"];
			Model.Password		= (string)row["Password"];
			Model.UpdateDate	= row["UpdateDate"] != DBNull.Value ? row["UpdateDate"] : null;
			Model.UserBlogUrl	= row["UserBlogUrl"]!=DBNull.Value ? (string)row["UserBlogUrl"] : null;
			Model.UserEmail		= row["UserEmail"]!=DBNull.Value ?  (string)row["UserEmail"] : null;
			Model.UserIP		= (string)row["UserIP"];
			Model.UserName		= (string)row["UserName"];
		}
	}
}
