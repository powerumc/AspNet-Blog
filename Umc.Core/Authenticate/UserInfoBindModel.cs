using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Authenticate
{
	public class UserInfoBindModel : UserInfo, IListSource
	{
		private ArrayList items = new ArrayList();

		public void Add(UserInfo userInfo)
		{
			items.Add( userInfo );
		}

		public int Count
		{
			get { return items.Count; }
		}

		#region IListSource ¸â¹ö

		public bool ContainsListCollection
		{
			get { return false; }
		}

		public IList GetList()
		{
			return (IList)items;
		}

		#endregion
	}
}
