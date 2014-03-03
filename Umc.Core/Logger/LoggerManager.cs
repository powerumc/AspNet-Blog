using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Umc.Core.Logger.Model;

namespace Umc.Core.Logger
{
	public class LoggerManager : Umc.Core.Modules.IManager
	{
		private static LoggerManager instance = null;

		public static LoggerManager GetInstance()
		{
			lock( typeof(LoggerManager) )
			{
				if( instance == null )
					instance = new LoggerManager();
			}

			return instance;
		}

		/// <summary>
		/// ������ ó�� ���۵ɶ� �α׸� �����Ѵ�.
		/// </summary>
		/// <param name="model"></param>
		public void InsertConnectionLog(ConnectionLogModel model)
		{
			LoggerAccess.InsertConnectionLog( model );
		}

		/// <summary>
		/// ���Ӻ� �α׸� �����´�.
		/// 
		/// Tables[0] : ��¥���� �� ī����
		/// Tables[1] : ���� ī����
		/// Tables[2] : �̹��� ī����
		/// Tables[3] : �̹��� ī����
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public DataSet GetConnectionLog(string date)
		{
			return LoggerAccess.GetConnectionLog( date );
		}

		#region IManager ���

		public void Dispose()
		{
			instance		= null;
		}

		#endregion
	}
}
