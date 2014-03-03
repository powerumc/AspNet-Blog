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
using Umc.Core.Web;
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Article.Model;
using Umc.Core.Util;

public partial class Common_Snap_Templates_SnapTag : UmcContentsCommonPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if( IsPostBack) return;

		bind();
	}

	private void bind()
	{
		TagBindModel bindModel		= ArticleManager.GetInstance().GetTagList();

		rptTagList.DataSource		= bindModel;
		rptTagList.DataBind();
	}
	protected void dlTagList_ItemDataBound(object sender, DataListItemEventArgs e)
	{
		
	}
	protected void rptTagList_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (!(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)) return;

		TagModel model = (TagModel)e.Item.DataItem;

		HyperLink hpTag = (HyperLink)e.Item.FindControl("HpTag");
		hpTag.Text = model.TagName;
		hpTag.NavigateUrl = Utility.MakeTagUrl(model.TagName);
	}
}
