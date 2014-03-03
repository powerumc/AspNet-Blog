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

using Umc.Core;
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Article.Model;

public partial class WebAdmin_03Tag_RemoveTag : Umc.Core.WebAdmin.WebAdminCommonTemplate
{
	protected void Page_Load(object sender, EventArgs e)
	{
		init();

		if (IsPostBack) return;

		bind();
	}

	private void init()
	{
	}

	private void bind()
	{
		TagBindModel bindModel = ArticleManager.GetInstance().GetTagList();
		rptList.DataSource = bindModel;
		rptList.DataBind();
	}
	protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (!(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)) return;

		TagModel model = (TagModel)e.Item.DataItem;

		LinkButton lnkTagName = (LinkButton)e.Item.FindControl("lnkTagName");
		lnkTagName.Text = model.TagName;

		lnkTagName.OnClientClick = string.Format("return confirm('{0}');", UmcConfiguration.Message[ArticleConst.MESSAGE_REMOVE_REALLY_TAG] );
	}
	protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
	{
		if (e.CommandName == "removeTag")
		{
			ArticleManager.GetInstance().RemoveTagByTagName( e.CommandArgument.ToString() );
		}

		bind();
	}
}
