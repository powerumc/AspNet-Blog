using System;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Modules.Article.Model
{
	public class TagBindModel : TagModel, IListSource
	{
		private ArrayList items = new ArrayList();

		public int Count
		{
			get { return items.Count; }
		}

		public void Add(TagModel model)
		{
			items.Add( model );
		}

		public TagModel this[int index]
		{
			get
			{
				return (TagModel)items[index];
			}
		}

		public void Add(string str)
		{
			string[] tags = str.Split(',');

			foreach (string tag in tags)
			{
				items.Add( new TagModel( tag ) );
			}
		}

		public IEnumerator GetEnumerator()
		{
			return items.GetEnumerator();
		}

		#region IListSource ¸â¹ö

		public bool ContainsListCollection
		{
			get
			{
				return false;
			}
		}

		public System.Collections.IList GetList()
		{
			return (IList)items;
		}

		#endregion
	}
}
