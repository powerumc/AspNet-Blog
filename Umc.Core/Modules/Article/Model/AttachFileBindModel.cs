using System;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Modules.Article.Model
{
	public class AttachFileBindModel : AttachFileModel, IListSource
	{
		private ArrayList items = new ArrayList();

		public void Add(AttachFileModel model)
		{
			items.Add( model );
		}

		public int Count
		{
			get { return items.Count; }
		}

		public AttachFileModel this[int index]
		{
			get { return (AttachFileModel)items[index]; }
		}

		public AttachFileBindModel()
		{
		}
		public AttachFileBindModel(int fileNo) : base(fileNo)
		{
		}

		#region IListSource ¸â¹ö

		public bool ContainsListCollection
		{
			get { return false; }
		}

		public System.Collections.IList GetList()
		{
			return (IList)items;
		}

		#endregion
	}
}
