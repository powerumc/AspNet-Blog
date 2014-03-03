using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

using Umc.Core.Modules.Article;

namespace Umc.Core.Modules.Article.Model
{
	public class ArticleBindModel : ArticleModel, IListSource
	{
		private ArrayList items	= new ArrayList();
		private int totalCount;

		public ArticleModel this[int index]
		{
			get { return (ArticleModel)items[index]; }
		}

		public IEnumerator GetEnumerator()
		{
			return items.GetEnumerator();
		}

		public int Count
		{
			get { return items.Count; }
		}

		public int TotalCount
		{
			get { return totalCount; }
			set { totalCount = value; }
		}

		public void Add(ArticleModel model)
		{
			items.Add( model );
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
