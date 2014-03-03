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
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Article.Model;

public partial class WebAdmin_03Tag_TagCloud : Umc.Core.WebAdmin.WebAdminCommonTemplate
{
	protected TagBindModel bindModel;

	protected void Page_Load(object sender, EventArgs e)
	{
		init();

		if( IsPostBack ) return;

		bind();
	}

	private void init()
	{
		bindModel	= ArticleManager.GetInstance().GetTagList();
	}

	private void bind()
	{
		rptList.DataSource	= bindModel;
		rptList.DataBind();
	}
	protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if( !(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem )) return;

		TagModel model			= (TagModel)e.Item.DataItem;

		HyperLink hpTagName		= (HyperLink)e.Item.FindControl("hpTagName");
		hpTagName.Text			= model.TagName;
		hpTagName.NavigateUrl	= Utility.MakeTagUrl( model.TagName );
	}
}
