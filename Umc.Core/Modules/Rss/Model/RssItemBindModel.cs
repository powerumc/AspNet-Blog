using System;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Modules.Rss.Model
{
	public class RssItemBindModel : RssItemModel, IListSource
	{
		public RssItemBindModel()
		{
		}

		private ArrayList items = new ArrayList();

		public int Count
		{
			get { return items.Count; }
		}

		public IEnumerator GetEnumerator()
		{
			return items.GetEnumerator();
		}

		public void Add(RssItemModel model)
		{
			items.Add( model );
		}

		public RssItemModel this[int index]
		{
			get { return (RssItemModel)items[index]; }
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
