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
using Umc.Core.Modules.Snap;
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Article.Model;
using Umc.Core.Modules.Blog;
using Umc.Core.Web.Controls;

public partial class Common_Snap_Contents_ArticleListContent : UmcContentsCommonPage
{
	private ArticleBindModel bindModel;

	#region 프로퍼티
	public int PageSize
	{
		get { return UmcPager1.PageSize; }
		set { UmcPager1.PageSize = value; }
	}
	public int CurrentPage
	{
		get { return UmcPager1.CurrentPageIndex; }
		set { UmcPager1.CurrentPageIndex = value; }
	}
	public int RecordCount
	{
		get { return UmcPager1.RecordCount; }
		set { UmcPager1.RecordCount = value; }
	}

	public string SearchMode
	{
		get
		{
			return GetParamString( Parameters.PARAM_SEARCH_MODE, string.Empty );
		}
	}

	public string SearchKeyword
	{
		get
		{
			return GetParamString( Parameters.PARAM_SEARCH_KEYWORD, string.Empty );
		}
	}
	#endregion

	protected void Page_Load(object sender, EventArgs e)
	{
		initParam();

		if( IsPostBack ) return;
	
		bind();
	}

	private void initParam()
	{
		PageSize			= BlogManager.GetInstance().BlogBaseModel.BlogModel.PostCount;
	}

	private void bind()
	{
		bindModel	= ArticleManager.GetInstance().GetArticleList( CurrentPage, PageSize, SearchMode, SearchKeyword, true );

		RecordCount			= bindModel.TotalCount;

		foreach (ArticleModel model in bindModel)
		{
			ArticleContent template = (ArticleContent)LoadControl(SnapManager.GetInstance().SnapCollection["Article"].ContentControl);
			template.ArticleNo = model.ArticleNo;
			phArticleList.Controls.Add(template);
		}
	}
	protected void UmcPager1_PageIndexChanged(object sender, PageIndexChangedEventArgs e)
	{
		CurrentPage			= e.NewPageIndex;
		bind();
	}
}
