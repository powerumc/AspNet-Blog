using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Umc.Core;
using Umc.Core.Data;

namespace Umc.Core.Modules.Stat
{
	public class StatManager : IManager
	{
		private static StatManager instance = null;

		public static StatManager GetInstance()
		{
			lock( typeof( StatManager ) )
			{
				if( instance == null )
					instance = new StatManager();
			}

			return instance;
		}

		/// <summary>
		/// Ŀ�ؼ� ����Ʈ�� �����´�.
		/// </summary>
		/// <param name="currentPage"></param>
		/// <param name="pageSize"></param>
		/// <param name="searchKeyword"></param>
		/// <param name="searchString"></param>
		/// <returns></returns>
		public DataSet GetConnectionLogList(int currentPage, int pageSize, string searchKeyword, string searchString)
		{
			return StatAccess.GetConnectionLogList( currentPage, pageSize, searchKeyword, searchString );
		}
		#region IManager ���

		public void Dispose()
		{
			instance = null;
		}

		#endregion
	}
}
