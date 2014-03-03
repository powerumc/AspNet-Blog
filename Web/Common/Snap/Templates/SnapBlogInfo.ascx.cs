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

using Umc.Core.Logger;

public partial class Common_Snap_Templates_SnapBlogInfo : Umc.Core.Web.UmcContentsCommonPage
{
	private DataSet ds;

	protected int totalCount, todayCount, weekCount, monthCount;

	protected void Page_Load(object sender, EventArgs e)
	{
		init();
	}

	private void init()
	{
		ds = LoggerManager.GetInstance().GetConnectionLog( DateTime.Now.ToShortDateString() );

		totalCount	= (int)ds.Tables[0].Rows[0][0];
		todayCount	= (int)ds.Tables[1].Rows[0][0];
		weekCount	= (int)ds.Tables[2].Rows[0][0];
		monthCount	= (int)ds.Tables[3].Rows[0][0];
	}
}
