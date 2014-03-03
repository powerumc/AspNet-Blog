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
using Umc.Core.WebAdmin;
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Article.Model;

public partial class WebAdmin_05Article_Templates_ArticleList : WebAdminCommonTemplate
{
	protected void Page_Load(object sender, EventArgs e)
	{
		init();

		if( IsPostBack ) return;

		bind();
	}

	private void init()
	{
	}

	private void bind()
	{
		dlArticleList.DataSource = ArticleManager.GetInstance().GetRecentArticleList( int.MaxValue );
		dlArticleList.DataBind();
	}

	#region 프로퍼티
	protected string ViewQueryString
	{
		get
		{
			string url = string.Format("{0}?{1}={2}&{3}={4}&{5}=",
				Request.Path,
				Parameters.PARAM_MODULE_ID, ModuleID,
				Parameters.PARAM_VIEWMODE, Parameters.VIEWMODE_VIEW,
				ArticleConst.PARAM_ARTICLENO
				);
			return url;
		}
	}
	#endregion
}
