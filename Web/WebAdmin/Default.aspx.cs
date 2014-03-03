using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Umc.Core.Util;
using Umc.Core.WebAdmin;
using Umc.Core.WebAdmin.Sitemap;

public partial class WebAdmin_Default : Umc.Core.WebAdmin.WebAdminTemplate
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			BuildTree();
		}

		//CurrentSitemapInfo = SitemapManager.GetInstance().GetSitemapByID(treeMenu.SelectedValue);
		//LoadPlaceTemplateByID(treeMenu.SelectedValue);
		string currentID = GetParamString("id");

		if (currentID == null) Response.Redirect(Request.Path + "?id=ADMIN1");

		CurrentSitemapInfo = SitemapManager.GetInstance().GetSitemapByID(currentID);

		LoadPlaceTemplateByID(CurrentSitemapInfo.ID);
	}

	private void CommonTemplate_UmcRegisterEvent(object sender, EventArgs e)
	{
		Utility.JS_Alert(sender, "^^");
	}

	private void BuildTree()
	{
		treeMenu.Nodes.Clear();

#if(DEBUG) // 
		SitemapManager.GetInstance().Dispose();
#endif

		sitemap				= SitemapManager.GetInstance().SiteInfo;
		Sitemap_Node node	= new Sitemap_Node(sitemap);

		treeMenu.Nodes.Add(node);

		AddNodes(sitemap, node);

		treeMenu.ExpandAll();
	}


	protected void treeMenu_SelectedNodeChanged(object sender, EventArgs e)
	{
		CurrentSitemapInfo	= SitemapManager.GetInstance().GetSitemapByID( treeMenu.SelectedValue );

		LoadPlaceTemplate( CurrentSitemapInfo );
	}

	private void LoadPlaceTemplate(ISitemap _sitemap)
	{
		if (CommonMainPlace.Sitemap == null)
		{
			CommonMainPlace.Sitemap = _sitemap;
			CommonMainPlace.Update();
		}
	}

	private void LoadPlaceTemplateByID(string id)
	{
		LoadPlaceTemplate( SitemapManager.GetInstance().GetSitemapByID(id) );
	}
}