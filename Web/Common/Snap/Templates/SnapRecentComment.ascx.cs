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
using Umc.Core.Modules.Comment;
using Umc.Core.Modules.Comment.Model;
using Umc.Core.Util;
using Umc.Core.Modules.Article;

public partial class Common_Snap_Templates_SnapRecentComment : Umc.Core.Web.UmcContentsCommonPage
{
	int articleNo;
	protected void Page_Load(object sender, EventArgs e)
	{
		initParam();

		if( IsPostBack ) return;

		bind();
	}

	private void initParam()
	{
		articleNo		= GetParamInt( ArticleConst.PARAM_ARTICLENO );
	}

	private void bind()
	{
		int count	= BlogManager.GetInstance().BlogBaseModel.BlogModel.RecentCommentListCount;
		CommentBindModel bindModel	= CommentManager.GetInstance().GetRecentCommentList(count);
		
		DataList dlRecentComment = (DataList)snap_RecentComment.FindControl("panel1").FindControl("dlRecentComment");
		dlRecentComment.DataSource = bindModel;
		dlRecentComment.DataBind();
	}
	protected void dlRecentComment_ItemDataBound(object sender, DataListItemEventArgs e)
	{
		if( !(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem) ) return;

		CommentModel comment	= (CommentModel)e.Item.DataItem;

		HyperLink hpComment		= (HyperLink)e.Item.FindControl("hpComment");
		Literal ltrNewIcon		= (Literal)e.Item.FindControl("ltrNewIcon");

		hpComment.Text			= Utility.LengthString(comment.Content)>23 ? Utility.CutString(comment.Content, 23) : comment.Content;
		if( comment.ArticleNo != articleNo )
			hpComment.NavigateUrl	= Utility.MakeArticleUrl(comment.ArticleNo)+"#"+comment.CommentNo.ToString();
		else
			hpComment.NavigateUrl	= string.Format("javascript:goComment({0});", comment.CommentNo);
		ltrNewIcon.Text			= Parameters.ICON_NEW;
		ltrNewIcon.Visible		= comment.NewIcon;
	}
}
