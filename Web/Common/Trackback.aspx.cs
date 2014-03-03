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
using System.Text;
using System.Xml;

using Umc.Core.Web;
using Umc.Core.Modules.Trackback;

public partial class Common_Trackback : System.Web.UI.Page
{
	private int articleNo;

	protected void Page_Load(object sender, EventArgs e)
	{
		initParam();

		if( IsPostBack ) return;

		Process();
	}

	private void initParam()
	{
		Response.Cache.SetNoStore();
		Response.Expires = 0;
		Response.AddHeader("pragma", "no-cache");

		if( Request[ TrackbackConst.PARAM_TRACKBACK ] != null )
			articleNo	= int.Parse( Request[ TrackbackConst.PARAM_TRACKBACK ].ToString() );
		else
			articleNo	= -1;
	}

	private void Process()
	{
		TrackbackManager.GetInstance().ReceiveTrackback( articleNo, Context );
	}
}