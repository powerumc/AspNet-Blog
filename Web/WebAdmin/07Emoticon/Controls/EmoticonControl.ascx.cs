﻿using System;
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

public partial class WebAdmin_07Emoticon_Controls_EmoticonControl : WebAdminCommonTemplate
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
		}
		else
		{
			template = LoadControl(CurrentSitemapInfo.GetInitParam(Parameters.TEMPLATE_LIST));
		}

		this.Controls.Add(template);
	}
}
