using System;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.WebAdmin.Sitemap
{
	/// <summary>
	/// Treeview ��Ʈ�ѿ� ���ε� �ϱ����� Node Ŭ����
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
