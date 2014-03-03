using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

using Umc.Core;
using Umc.Core.Data;

namespace Umc.Core.Modules.Stat
{
	internal class StatAccess : AbstractDataAccess
	{
		/// <summary>
		/// 커넥션 로그 리스트를 가져온다,
		/// </summary>
		/// <param name="currentPage"></param>
		/// <param name="pageSize"></param>
		/// <param name="searchKeyword"></param>
		/// <param name="searchString"></param>
		/// <returns></returns>
		public static DataSet GetConnectionLogList(int currentPage, int pageSize, string searchKeyword, string searchString)
		{
			SqlParameter[] param = {
				CreateInParam( "@CurrentPage",	SqlDbType.Int,4,			currentPage ),
				CreateInParam( "@PageSize",		SqlDbType.Int,4,			pageSize ),
				CreateInParam( "@SearchKeyword",	SqlDbType.VarChar,20,	searchKeyword ),
				CreateInParam( "@SearchString",		SqlDbType.VarChar,100,	searchString )
			};

			SqlCommand cmd		= GetSpCommand("UBS_GetConnectionLogList", param);
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
