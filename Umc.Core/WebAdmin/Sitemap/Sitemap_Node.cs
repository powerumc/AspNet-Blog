using System;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.WebAdmin.Sitemap
{
	/// <summary>
	/// Treeview 컨트롤에 바인딩 하기위한 Node 클래스
	/// </summary>
	public class Sitemap_Node : System.Web.UI.WebControls.TreeNode
	{
		ISitemap sitemap;

		public Sitemap_Node(ISitemap _sitemap)
			: base(_sitemap.Title)
		{
			this.sitemap		= _sitemap;
			base.Value			= _sitemap.ID;
		}

		public ISitemap Sitemap
		{
			get { return sitemap; }
		}
	}
}
