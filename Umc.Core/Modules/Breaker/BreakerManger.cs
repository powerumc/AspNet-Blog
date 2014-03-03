using System;
using System.Collections.Generic;
using System.Text;

using Umc.Core;
using Umc.Core.Modules;
using Umc.Core.Data;

namespace Umc.Core.Modules.Breaker 
{
	public class BreakerManager : IManager
	{
		private static BreakerManager instance = null;

		private List<BreakerModel> model		= null;

		public static BreakerManager GetInstance()
		{
			lock (typeof(BreakerManager))
			{
				if (instance == null)
				{
					instance = new BreakerManager();
					instance.Init();
				}

				return instance;
			}
		}

		private void Init()
		{
		}

		public List<BreakerModel> Model
		{
			get { return model; }
			set { model = value; }
		}

		/// <summary>
		/// 차단 목록을 추가한다.
		/// </summary>
		/// <param name="model"></param>
		/// <returns>고유키         -1 일경우 이미 등록됨</returns>
		public int InsertBreaker(BreakerModel model)
		{
			return BreakerAccess.InsertBreaker( model );
		}

		/// <summary>
		/// 차단목록에서 제거
		/// </summary>
		/// <param name="userip"></param>
		/// <returns></returns>
		public bool RemoveBreaker(string userip)
		{
			return BreakerAccess.RemoveBreaker( userip );
		}

		/// <summary>
		/// 차단목록 리스트
		/// </summary>
		/// <returns></returns>
		public List<BreakerModel> GetBreakerList()
		{
			return BreakerAccess.GetBreakerList();
		}

		public bool CompareBreakerIP(string userip)
		{
			return BreakerAccess.CompareBreakerIP( userip );
		}

		#region IManager 멤버

		public void Dispose()
		{
			instance	= null;
			model		= null;
		}

		#endregion
	}
}
