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
		/// ���� ����� �߰��Ѵ�.
		/// </summary>
		/// <param name="model"></param>
		/// <returns>����Ű         -1 �ϰ�� �̹� ��ϵ�</returns>
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
				throw new UmcDataException("UBB_InsertBreaker ���ν��� ȣ���� ����", ex);
			}
		}

		/// <summary>
		/// ���ܸ�Ͽ��� �����Ѵ�.
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
		/// ���� ��� ����Ʈ�� �����´�.
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
		/// �ش� �����ǰ� ���ܸ�Ͽ� �ִ��� �˻�
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
