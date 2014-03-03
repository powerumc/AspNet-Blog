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
using Umc.Core.Modules.Blog.Model;
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Article.Model;
using Umc.Core.Util;

public partial class WebAdmin_02Privacy_Privacy : System.Web.UI.UserControl
{
	BlogBaseModel model;
	protected void Page_Load(object sender, EventArgs e)
	{
		bind();
	}

	private void bind()
	{
		model		= BlogManager.GetInstance().BlogBaseModel;

		rblCanWriteMemo.SelectedValue			= model.PrivacyModel.CanWriteMemo.ToString();
		rblCanWriteGuestBoard.SelectedValue		= model.PrivacyModel.CanWriteGuestBoard.ToString();
		rblCanWriteBbs.SelectedValue			= model.PrivacyModel.CanWriteBbs.ToString();
		rblPublicRSS.SelectedValue				= model.PrivacyModel.PublicRSS.ToString();
		rblAllowMouseRightButton.SelectedValue	= model.PrivacyModel.AllowMouseRightButton.ToString();
		rblLimitRssCount.SelectedValue			= model.PrivacyModel.LimitRssCount.ToString();

		if( IsPostBack ) return;

		ArticleBindModel articleBindModel		= ArticleManager.GetInstance().GetRecentArticleList( int.MaxValue );

		foreach (ArticleModel articleModel in articleBindModel)
		{
			ddlGuestBookArticle.Items.Add( new ListItem( articleModel.Title, articleModel.ArticleNo.ToString() ) );
		}

		ddlGuestBookArticle.SelectedValue		= model.PrivacyModel.GuestBoardArticleNo.ToString();
	}

	protected void lnkRegister_Click(object sender, EventArgs e)
	{
		model.PrivacyModel.CanWriteMemo			= bool.Parse(rblCanWriteMemo.SelectedValue);
		model.PrivacyModel.CanWriteGuestBoard	= bool.Parse(rblCanWriteGuestBoard.SelectedValue);
		model.PrivacyModel.CanWriteBbs			= bool.Parse(rblCanWriteBbs.SelectedValue);
		model.PrivacyModel.PublicRSS			= bool.Parse(rblPublicRSS.SelectedValue);
		model.PrivacyModel.AllowMouseRightButton= bool.Parse(rblAllowMouseRightButton.SelectedValue);
		model.PrivacyModel.GuestBoardArticleNo	= int.Parse( ddlGuestBookArticle.SelectedValue);
		model.PrivacyModel.LimitRssCount		= int.Parse(rblLimitRssCount.SelectedValue);

		string path = Utility.GetAbsolutePath(UmcConfiguration.Core["BlogXmlPath"]);
		BlogManager.GetInstance().WriteBlogBaseInfo(path, model);

		Utility.JS_Alert(sender, MessageCode.MESSAGE_SAVED);
	}
}
