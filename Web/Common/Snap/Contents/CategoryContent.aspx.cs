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

public partial class Common_Snap_Contents_CategoryContent : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Response.Cache.SetNoStore();
		Response.Expires = 0;
		Response.AppendHeader("pragma", "no-cache");
	}
}
