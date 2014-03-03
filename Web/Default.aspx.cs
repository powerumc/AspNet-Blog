using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Umc.Core;
using Umc.Core.Web;
using Umc.Core.Util;
using Umc.Core.Modules.Blog;
using Umc.Core.Modules.Snap;
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Trackback;
using Umc.Core.Authenticate;
using Umc.Core.WebAdmin.Sitemap;

public partial class _Default : Umc.Core.Web.UmcBlogBasePage
{
	public string CurrentIframeControl;

    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			initCurrentControl(sender, e);
			bind();
		}

		initCurrentContentControl();
		//Update(ContentViewControl);
	}

	private void bind()
	{
		hpBlogTitle.Text		= BlogManager.GetInstance().BlogBaseModel.BlogModel.Title;
		hpBlogTitle.NavigateUrl	= BlogManager.GetInstance().BlogBaseModel.BlogModel.Url;
	}

	protected void lnkSnapSave_Click(object sender, EventArgs e)
	{
		base.SnapSave();

		Utility.JS_Alert(sender, "저장되었습니다");
	}

	protected void lnkLogout_Click(object sender, EventArgs e)
	{
		Authenticator.GetInstance().Logout( Context );
		Utility.JsCall( sender, "document.getElementById(\"spanLogin\").style.display ='inline';" );
	}

	protected void lnkUserJoin_Click(object sender, EventArgs e)
	{
		ContentViewControl = SnapConst.SNAP_TEMPLATE_USER_JOIN;
		Update( SnapConst.SNAP_TEMPLATE_USER_JOIN );
	}

	protected void initCurrentControl(object sender, EventArgs e)
	{
		int articleNo	= GetParamInt(ArticleConst.PARAM_ARTICLENO);
		string tag		= GetParamString(ArticleConst.PARAM_TAG, string.Empty);

		if ( articleNo != -1)
		{
			//Utility.JsCall(sender, "setContent('Article')");
			CurrentIframeControl	= string.Format("{0}?snapID=Article&{1}={2}", 
				Parameters.ASPX_SNAP_TEMPLATE_SNAPCONTENT,
				ArticleConst.PARAM_ARTICLENO, 
				articleNo.ToString() );
			return;
		}

		if (tag != string.Empty)
		{
			CurrentIframeControl = string.Format("{0}?snapID=TagList&{1}={2}",
				Parameters.ASPX_SNAP_TEMPLATE_SNAPCONTENT,
				ArticleConst.PARAM_TAG,
				tag);

			return;
		}

		CurrentIframeControl	= string.Format("{0}?snapID=ArticleList",
			Parameters.ASPX_SNAP_TEMPLATE_SNAPCONTENT);
		return;
	}

	protected void initCurrentContentControl()
	{
		
	}
}