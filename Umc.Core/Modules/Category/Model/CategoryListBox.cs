using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Umc.Core.Modules.Category.Model
{
	public class CategoryListBox : CategoryModel
	{
		public override void Bind(System.Web.UI.Control control)
		{
			ListBox listbox		= control as ListBox;

			if (listbox == null) return;

			ListItem lastItem	= new ListItem();
			for (int i = 0; i < this.Count; i++)
			{
				if(this[i].CategoryStep > 1)
					this[i].CategoryTitle	= this[i].CategoryTitle.Insert(0,"___");

				ListItem item = new ListItem(this[i].CategoryTitle, this[i].NodeValue.ToString());

				if (this[i].CategoryStep == 1)
				{
					listbox.Items.Add( item );
					lastItem = item;
				}

				if (this[i].CategoryStep > 1)
				{
					listbox.Items.Add(item);
				}
			}
		}
	}
}
