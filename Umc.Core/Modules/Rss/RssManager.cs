using System;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Modules.Rss
{
	public class RssManager : IManager
	{
		private static RssManager instance = null;

		public static RssManager GetInstance()
		{
			lock( typeof(RssManager ))
			{
				if( instance == null )
					instance = new RssManager();
			}

			return instance;
		}

		#region IManager ¸â¹ö

		public void Dispose()
		{
			instance = null;
		}

		#endregion
	}
}
