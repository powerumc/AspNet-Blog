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
using Umc.Core.Util;

public partial class WebAdmin_05Article_Templates_ArticleView : WebAdminCommonTemplate
{
	protected int articleNo;

	protected void Page_Load(object sender, EventArgs e)
	{
		initParam();

		Control template = LoadControl( ArticleConst.CONTROL_ARTICLE_CONTENT );
		this.Controls.AddAt( 0, template );
	}

	private void initParam()
	{
		articleNo		= GetParamInt( ArticleConst.PARAM_ARTICLENO );

		hpWrite.NavigateUrl	= WriteQueryString + articleNo.ToString();

		lnkRemoveArticle.OnClientClick	= string.Format("return confirm('{0}')",
												UmcConfiguration.Message[ ArticleConst.MESSAGE_ARTICLE_REALLY_REMOVE ] );
	}

	#region 프로퍼티
	protected string WriteQueryString
	{
		get
		{
			string url = string.Format("{0}?{1}={2}&{3}={4}&{5}=",
				Request.Path,
				Parameters.PARAM_MODULE_ID, ModuleID,
				Parameters.PARAM_VIEWMODE, Parameters.VIEWMODE_WRITE,
				ArticleConst.PARAM_ARTICLENO);

			return url;
		}
	}
	protected string ListQueryString
	{
		get
		{
			string url	= string.Format("{0}?{1}={2}&{3}={4}",
				Request.Path,
				Parameters.PARAM_MODULE_ID, ModuleID,
				Parameters.PARAM_VIEWMODE, Parameters.VIEWMODE_LIST);

			return url;
		}
	}
	#endregion
	protected void lnkRemoveArticle_Click(object sender, EventArgs e)
	{
		ArticleManager.GetInstance().RemoveArticleByNo( articleNo );

		string script	= string.Format("alert('{0}'); location.href='{1}';",
							UmcConfiguration.Message[ ArticleConst.MESSAGE_ARTICLE_REMOVE ],
							ListQueryString );

		Utility.JsCall( sender, script );
	}
}
