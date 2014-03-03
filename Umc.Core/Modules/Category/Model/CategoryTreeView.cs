using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Umc.Core.Modules.Category.Model
{
	public class CategoryTreeView : CategoryModel
	{
		public override void Bind(System.Web.UI.Control control)
		{
			TreeView tree = control as TreeView;

			if( tree == null ) return;

			TreeNode lastNode	= new TreeNode();
			for (int i = 0; i < this.Count; i++)
			{
				string nodeTitle = this[i].CategoryTitle;
				if( this[i].ArticleCount > 0 ) nodeTitle += " [ " + this[i].ArticleCount.ToString() + " ] ";
				if( this[i].NewIcon ) nodeTitle += Parameters.ICON_NEW;

				TreeNode node = new TreeNode(nodeTitle, this[i].NodeValue.ToString());

				if (this[i].CategoryStep == 1)
				{
					node.NavigateUrl = string.Format("javascript:setContent('Category&{0}');", "nodeValue=" + this[i].NodeValue);
					tree.Nodes.Add(node);
					lastNode = node;
				}

				if (this[i].CategoryStep > 1)
				{
					node.NavigateUrl = string.Format("javascript:setContent('Category&{0}');","nodeValue="+this[i].NodeValue);
					lastNode.ChildNodes.Add(node);
				}
			}

			tree.ExpandAll();
		}
	}
}
