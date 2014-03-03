using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Umc.Core.Data;
using Umc.Core.Logger.Model;

namespace Umc.Core.Logger
{
	internal class LoggerAccess : AbstractDataAccess
	{
		public static void InsertConnectionLog(ConnectionLogModel model)
		{
			object urlRefer = (object)model.UrlReferrer ?? DBNull.Value;
			SqlParameter[] param = {
				CreateInParam("@SessionID", SqlDbType.VarChar,100, model.SessionID),
				CreateInParam("@UrlReferrer", SqlDbType.VarChar,255, urlRefer ),
				CreateInParam("@UserIP", SqlDbType.VarChar,20, model.UserIP)
			};

			SqlCommand cmd		= GetRawCommand("INSERT ConnectionLog(SessionID, UrlReferrer, UserIP) VALUES(@SessionID, @UrlReferrer, @UserIP)", param);
			try
			{
				cmd.ExecuteNonQuery();
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}

		public static DataSet GetConnectionLog(string date)
		{
			SqlParameter[] param ={
				CreateInParam("@Date", SqlDbType.VarChar,20,		date)
				};

			SqlCommand cmd		= GetSpCommand("GetConnectionLog", param);
			SqlDataAdapter da	= new SqlDataAdapter(cmd);

			try
			{
				DataSet ds = new DataSet();
				da.Fill( ds );

				return ds;
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}
	}
}
