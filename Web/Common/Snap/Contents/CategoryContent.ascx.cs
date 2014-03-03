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
using Umc.Core.Util;
using Umc.Core.Modules.Category.Model;
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Article.Model;
using Umc.Core.Modules.Snap;

public partial class Common_Snap_Contents_CategoryContent : UmcContentsCommonPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		string nodeValue	= GetParamString("nodeValue");
		string date			= GetParamString("date");
		ArticleBindModel bindModel = null;

		if (nodeValue != null)
		{
			CategoryNodeValue CurrentCategoryNodeValue = CategoryNodeValue.Parse(nodeValue);
			bindModel = ArticleManager.GetInstance().GetArticleList(CurrentCategoryNodeValue);
		}
		else if (date != null)
		{
			bindModel = ArticleManager.GetInstance().GetArticleList(date);
		}

		dlCategory.DataSource = (ArticleBindModel)bindModel;
		dlCategory.DataBind();
	}
	protected void dlCategory_ItemDataBound(object sender, DataListItemEventArgs e)
	{
		if( !(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem) ) return;

		ArticleModel model				= (ArticleModel)e.Item.DataItem;

		HyperLink hpTitle				= (HyperLink)e.Item.FindControl("hpTitle");
		Literal ltrNewIcon				= (Literal)e.Item.FindControl("ltrNewIcon");
		HyperLink hpCategoryMTitle		= (HyperLink)e.Item.FindControl("hpCategoryMTitle");
		
		hpTitle.Text					= model.Title;
		hpTitle.NavigateUrl				= Utility.MakeArticleUrl( model.ArticleNo );

		hpTitle.Text					+= model.CommentCount > 0 ?
											string.Format(" [ <b>{0}</b> ]", model.CommentCount) : string.Empty;
		
		hpCategoryMTitle.Text			= model.CategoryMTitle;

		ltrNewIcon.Text					= Parameters.ICON_NEW;
		ltrNewIcon.Visible				= model.NewIcon;
	}
}
