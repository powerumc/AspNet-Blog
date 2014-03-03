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

public partial class Common_Snap_Contents_TagList : UmcContentsCommonPage
{
	private ArticleBindModel bindModel;
	protected void Page_Load(object sender, EventArgs e)
	{
		string tag		= GetParamString( ArticleConst.PARAM_TAG );

		if( tag == null ) return;

		bindModel		= ArticleManager.GetInstance().GetArticleListByTag( tag, true );

		dlTagList.DataSource = bindModel;
		dlTagList.DataBind();

	}
	protected void dlTagList_ItemDataBound(object sender, DataListItemEventArgs e)
	{
		if (!(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)) return;

		ArticleModel model			= (ArticleModel)e.Item.DataItem;

		HyperLink hpTitle			= (HyperLink)e.Item.FindControl("hpTitle");
		Literal ltrNewIcon			= (Literal)e.Item.FindControl("ltrNewIcon");

		hpTitle.Text				= model.Title;
		hpTitle.NavigateUrl			= Utility.MakeArticleUrl(model.ArticleNo);

		hpTitle.Text				+= model.CommentCount > 0 ?
											string.Format(" [ <b>{0}</b> ]", model.CommentCount) : string.Empty;

		ltrNewIcon.Text				= Parameters.ICON_NEW;
		ltrNewIcon.Visible			= model.NewIcon;
	}
}
