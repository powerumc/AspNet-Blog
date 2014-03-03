using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;

namespace Umc.Core.Modules.Comment.Model
{
	public class CommentBindModel : CommentModel, IListSource
	{
		private ArrayList items	= new ArrayList();

		public CommentBindModel()
		{
		}

		public CommentBindModel(int articleNo)
		{
			this.ArticleNo = articleNo;
		}

		public CommentModel this[int index]
		{
			get { return (CommentModel)items[index]; }
		}

		public int Count
		{
			get { return items.Count; }
		}

		public void Add(CommentModel model)
		{
			items.Add(model);
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
