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
using Umc.Core.WebAdmin.Sitemap;

public partial class WebAdmin_05Article_Controls_ArticleControl : WebAdminCommonTemplate
{
	protected void Page_Load(object sender, EventArgs e)
	{
		initControl();
	}

	private void initControl()
	{
		Control template = null;
		if (ViewMode == Parameters.VIEWMODE_VIEW)
		{
			template = LoadControl(CurrentSitemapInfo.GetInitParam(Parameters.TEMPLATE_VIEW));
		}
		else if (ViewMode == Parameters.VIEWMODE_WRITE)
		{
			template = LoadControl(CurrentSitemapInfo.GetInitParam(Parameters.TEMPLATE_WRITE));
		}
		else
		{
			template = LoadControl(CurrentSitemapInfo.GetInitParam(Parameters.TEMPLATE_LIST));
		}

		this.Controls.Add( template );
	}
}
