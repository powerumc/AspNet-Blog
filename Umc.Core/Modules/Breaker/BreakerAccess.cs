using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

using Umc.Core;
using Umc.Core.Data;

namespace Umc.Core.Modules.Breaker
{
	internal class BreakerAccess : AbstractDataAccess
	{
		/// <summary>
		/// 차단 목록을 추가한다.
		/// </summary>
		/// <param name="model"></param>
		/// <returns>고유키         -1 일경우 이미 등록됨</returns>
		public static int InsertBreaker(BreakerModel model)
		{
			SqlParameter[] param = {
				CreateInParam("@UserIP",				SqlDbType.VarChar,20,			model.UserIP),
				CreateReturnValue()
			};

			SqlCommand cmd			= GetSpCommand("UBB_InsertBreaker", param, IsolationLevel.ReadUncommitted);

			try
			{
				cmd.ExecuteNonQuery();

				int seqNo			= (int)cmd.Parameters["@ReturnValue"].Value;

				ReleaseCommandWithCommit(cmd);

				return seqNo;
			}
			catch (UmcDataException ex)
			{
				ReleaseCommandWithRollback(cmd);
				throw new UmcDataException("UBB_InsertBreaker 프로시져 호출중 에러", ex);
			}
		}

		/// <summary>
		/// 차단목록에서 제거한다.
		/// </summary>
		/// <param name="userip"></param>
		/// <returns></returns>
		public static bool RemoveBreaker(string userip)
		{
			SqlParameter[] param = {
				CreateInParam("@UserIP",				SqlDbType.VarChar,20,			userip)
			};

			SqlCommand cmd			= GetSpCommand("UBB_RemoveBreaker", param, IsolationLevel.ReadUncommitted);

			try
			{
				cmd.ExecuteNonQuery();

				ReleaseCommandWithCommit(cmd);
				return true;
			}
			catch (UmcDataException ex)
			{
				ReleaseCommandWithRollback(cmd);

				return false;
			}
		}

		/// <summary>
		/// 차단 목록 리스트를 가져온다.
		/// </summary>
		/// <returns></returns>
		public static List<BreakerModel> GetBreakerList()
		{
			SqlCommand cmd			= GetRawCommand("SELECT * FROM Breaker ORDER BY InsertDate");
			SqlDataReader reader	= cmd.ExecuteReader(CommandBehavior.CloseConnection);

			List<BreakerModel> bindModel	= new List<BreakerModel>();

			while (reader.Read())
			{
				BreakerModel model			= new BreakerModel();
				fillBreakerModel( reader, model );

				bindModel.Add( model );
				model						= null;
			}

			return bindModel;

		}

		/// <summary>
		/// 해당 아이피가 차단목록에 있는지 검사
		/// </summary>
		/// <param name="userip"></param>
		/// <returns></returns>
		public static bool CompareBreakerIP(string userip)
		{
			SqlParameter[] param	= {
				CreateInParam("@UserIP",			SqlDbType.VarChar,20,			userip),
				CreateReturnValue()
			};

			SqlCommand cmd			= GetSpCommand("UBB_CompareBreakerIP", param);
			cmd.ExecuteNonQuery();

			int result				= (int)cmd.Parameters["@ReturnValue"].Value;

			return result == 1 ? true : false;
		}

		private static void fillBreakerModel(IDataRecord row, BreakerModel model)
		{
			model.SeqNo				= (int)row["SeqNo"];
			model.UserIP			= (string)row["UserIP"];
			model.InsertDate		= (object)row["InsertDate"];
		}
	}
}
