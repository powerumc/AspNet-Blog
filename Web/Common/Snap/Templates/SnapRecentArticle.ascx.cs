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
using Umc.Core.Modules.Blog;
using Umc.Core.Util;
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Article.Model;

public partial class Common_Snap_Templates_SnapRecentArticle : Umc.Core.Web.UmcContentsCommonPage
{
	protected ArticleBindModel listModel;
	protected int articleNo;

	protected void Page_Load(object sender, EventArgs e)
	{
		if( IsPostBack ) return;

		bind();
	}

	private void bind()
	{
		int count = BlogManager.GetInstance().BlogBaseModel.BlogModel.RecentArticleListCount;
		listModel = ArticleManager.GetInstance().GetRecentArticleList( count );

		dlRecentArtcle.DataSource	= listModel;
		dlRecentArtcle.DataBind();
	}

	protected void dlRecentArtcle_ItemDataBound(object sender, DataListItemEventArgs e)
	{
		if( !(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem) ) return;

		ArticleModel model		= (ArticleModel)e.Item.DataItem;

		HyperLink hpArticle		= (HyperLink)e.Item.FindControl("hpArticle");
		Literal ltrNewIcon		= (Literal)e.Item.FindControl("ltrNewIcon");

		hpArticle.Text			= Utility.LengthString(model.Title)>20 ? Utility.CutString(model.Title, 20)+".." : model.Title;
		hpArticle.NavigateUrl	= Utility.MakeArticleUrl( model.ArticleNo );
		hpArticle.Text			+= model.CommentCount > 0 ? 
			string.Format(" [ <b>{0}</b> ]", model.CommentCount) : string.Empty;

		ltrNewIcon.Text			= Parameters.ICON_NEW;
		ltrNewIcon.Visible		= model.NewIcon;
	}
}
