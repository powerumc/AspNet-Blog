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
using Umc.Core.Util;
using Umc.Core.Modules.Snap;

public partial class Common_Snap_Templates_SnapContent : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Response.Cache.SetNoStore();
		Response.Expires = 0;
		Response.AppendHeader("pragma", "no-cache");

		string snapId = Request["snapID"] != null ? Request["snapID"].ToString() : string.Empty;
		if (snapId == string.Empty)
		{
		}

		string snapContent	= SnapManager.GetInstance().SnapCollection[snapId].ContentControl;
			
		Control contentTemplate = LoadControl(snapContent);
		placeholder1.Controls.Add( contentTemplate );
	}
}
