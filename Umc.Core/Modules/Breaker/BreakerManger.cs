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
		/// ���� ����� �߰��Ѵ�.
		/// </summary>
		/// <param name="model"></param>
		/// <returns>����Ű         -1 �ϰ�� �̹� ��ϵ�</returns>
		public int InsertBreaker(BreakerModel model)
		{
			return BreakerAccess.InsertBreaker( model );
		}

		/// <summary>
		/// ���ܸ�Ͽ��� ����
		/// </summary>
		/// <param name="userip"></param>
		/// <returns></returns>
		public bool RemoveBreaker(string userip)
		{
			return BreakerAccess.RemoveBreaker( userip );
		}

		/// <summary>
		/// ���ܸ�� ����Ʈ
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

		#region IManager ���

		public void Dispose()
		{
			instance	= null;
			model		= null;
		}

		#endregion
	}
}
