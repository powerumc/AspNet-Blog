using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Umc.Core;
using Umc.Core.Data;

namespace Umc.Core.Modules.Trackback
{
	internal class TrackbackAccess : AbstractDataAccess
	{
		/// <summary>
		/// 트랙백 정보를 저장한다.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public static int InsertTrackback(TrackbackModel model)
		{
			object exceprt		= !string.IsNullOrEmpty(model.Exceprt) ? (object)model.Exceprt : DBNull.Value;

			SqlParameter[] param = {
				CreateInParam("@ArticleNo",			SqlDbType.Int,4,					model.ArticleNo),
				CreateInParam("@Url",				SqlDbType.VarChar,255,				model.Url),
				CreateInParam("@Blog_Name",			SqlDbType.VarChar,255,				model.Blog_Name),
				CreateInParam("@Title",				SqlDbType.VarChar,255,				model.Title),
				CreateInParam("@Exceprt",			SqlDbType.Text, Int32.MaxValue,		exceprt),
				CreateInParam("@UserIP",			SqlDbType.VarChar,20,				model.UserIP),
				CreateReturnValue()
			};

			SqlCommand cmd				= GetSpCommand("UBT_InsertTrackback", param, IsolationLevel.ReadUncommitted);

			try
			{
				cmd.ExecuteNonQuery();

				int seqNo				= (int)cmd.Parameters["@ReturnValue"].Value;

				ReleaseCommandWithCommit(cmd);

				return seqNo;
			}
			catch (Exception ex)
			{
				ReleaseCommandWithRollback(cmd);
				throw new UmcDataException("UBT_InsertTrackback 프로시져 호출중 에러", ex);
			}
		}

		/// <summary>
		/// 트랙백을 제거한다.
		/// </summary>
		/// <param name="seqNo"></param>
		public static void RemoveTrackback(int seqNo)
		{
			SqlParameter[] param = {
				CreateInParam("@SeqNo",				SqlDbType.Int,4,					seqNo)
			};

			SqlCommand cmd				= GetSpCommand("UBT_RemoveTrackback", param, IsolationLevel.ReadUncommitted);

			try
			{
				cmd.ExecuteNonQuery();

				ReleaseCommandWithCommit(cmd);
			}
			catch (Exception ex)
			{
				ReleaseCommandWithRollback(cmd);
				throw new UmcDataException("UBT_RemoveTrackback 프로시져 호출중 에러", ex);
			}
		}

		/// <summary>
		/// 아티클과 연결된 트랙백 리스트를 가져온다.
		/// </summary>
		/// <param name="articleNo"></param>
		/// <returns></returns>
		public static List<TrackbackModel> GetTrackbackList(int articleNo)
		{
			SqlParameter[] param = {
				CreateInParam("@ArticleNo",			SqlDbType.Int,4,					articleNo )
			};

			SqlCommand cmd					= GetSpCommand("UBT_GetTrackbackList", param );
			SqlDataReader reader			= cmd.ExecuteReader(CommandBehavior.CloseConnection);
			List<TrackbackModel> bindModel	= new List<TrackbackModel>();

			try
			{
				while (reader.Read())
				{
					TrackbackModel model = new TrackbackModel((int)reader["SeqNo"]);
					fillTrackback(reader, model);

					bindModel.Add(model);
					model = null;
				}
				return bindModel;
			}
			catch (Exception ex)
			{
				throw new UmcDataException("UBT_GetTrackbackList 프로시져 호출중 에러", ex);
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}

		private static void fillTrackback(IDataRecord row, TrackbackModel model)
		{
			model.ArticleNo					= (int)row["ArticleNo"];
			model.Url						= (string)row["Url"];
			model.Blog_Name					= (string)row["Blog_Name"];
			model.Title						= (string)row["Title"];
			model.Exceprt					= row["Exceprt"] != DBNull.Value ? (string)row["Exceprt"] : string.Empty;
			model.InsertDate				= row["InsertDate"];
		}
	}
}
