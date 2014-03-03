using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Umc.Core.Util;
using Umc.Core.WebAdmin;
using Umc.Core.Modules.Breaker;

public partial class WebAdmin_09Breaker_Templates_BreakerList : WebAdminCommonTemplate
{
	protected void Page_Load(object sender, EventArgs e)
	{
		initParam();

		if( IsPostBack ) return;

		bind();
	}

	private void initParam()
	{
	}

	private void bind()
	{
		List<BreakerModel> bindModel		= BreakerManager.GetInstance().GetBreakerList();

		dlBreakerList.DataSource	= bindModel;
		dlBreakerList.DataBind();
	}
	protected void dlBreakerList_ItemDataBound(object sender, DataListItemEventArgs e)
	{
		
	}
	protected void dlBreakerList_ItemCommand(object source, DataListCommandEventArgs e)
	{
		if (e.CommandName == "unbreaker")
		{
			if (BreakerManager.GetInstance().RemoveBreaker(e.CommandArgument.ToString()))
			{
				Utility.JS_Alert(this, BreakerConst.MESSAGE_BREAKER_REMOVE);
			}
			else
			{
				Utility.JS_Alert(this, BreakerConst.MESSAGE_BREAKER_CAN_NOT_REMOVE);
			}
		}

		lnkBreakerUpdate_Click( this, null );
	}
	protected void lnkBreakerUpdate_Click(object sender, EventArgs e)
	{
		Response.Redirect(Request.Url.ToString());
	}
}
