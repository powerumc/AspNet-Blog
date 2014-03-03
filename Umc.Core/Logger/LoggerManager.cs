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
		/// 세션이 처음 시작될때 로그를 저장한다.
		/// </summary>
		/// <param name="model"></param>
		public void InsertConnectionLog(ConnectionLogModel model)
		{
			LoggerAccess.InsertConnectionLog( model );
		}

		/// <summary>
		/// 접속별 로그를 가져온다.
		/// 
		/// Tables[0] : 날짜까지 총 카운터
		/// Tables[1] : 오늘 카운터
		/// Tables[2] : 이번주 카운터
		/// Tables[3] : 이번달 카운터
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public DataSet GetConnectionLog(string date)
		{
			return LoggerAccess.GetConnectionLog( date );
		}

		#region IManager 멤버

		public void Dispose()
		{
			instance		= null;
		}

		#endregion
	}
}
