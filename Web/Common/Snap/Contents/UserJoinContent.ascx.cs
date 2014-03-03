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

using Umc.Core.Authenticate;
using Umc.Core.Util;
using Umc.Core.Modules.Snap;
using Umc.Core.Web;
using AjaxPro.JSON;

public partial class Common_Snap_Contents_UserJoinContent : UmcContentsCommonPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		
	}

	protected void btnUserJoin_Click(object sender, ImageClickEventArgs e)
	{
		if (txtEMail.Text.Length < 5)
		{
			Utility.JS_Alert( sender, AuthenticateConst.MESSAGE_WRONG_EMAIL );
			return;
		}
		if (txtName.Text.Length < 2)
		{
			Utility.JS_Alert( sender, AuthenticateConst.MESSAGE_EMPTY_NAME );
			return;
		}
		if (txtNickName.Text.Length < 2)
		{
			Utility.JS_Alert( sender, AuthenticateConst.MESSAGE_EMPTY_NICKNAME );
			return;
		}
		if (txtPassword.Text.Length < 4)
		{
			Utility.JS_Alert( sender, AuthenticateConst.MESSAGE_EMPTY_PASSWORD );
			return;
		}
		if (txtPassword.Text != txtPassword2.Text )
		{
			Utility.JS_Alert( sender, AuthenticateConst.MESSAGE_COMPARE_PASSWORD );
			return;
		}

		string email	= txtEMail.Text;
		UserInfo user	= UserInfo.CreateUser(email);
		user.Name = txtName.Text;
		user.NickName	= txtNickName.Text;
		user.Password	= FormsAuthentication.HashPasswordForStoringInConfigFile(
			txtPassword.Text, AuthenticateConst.AUTHENTICATE_HASH_FORMAT);
		user.Homepage	= txtHomepage.Text;
		user.Level		= LevelAttribute.MEMBER;

		string returnCode = Authenticator.GetInstance().InsertUser(user);

		Authenticator.GetInstance().Login( user, Context );

		string msg		= Umc.Core.UmcConfiguration.Message[ returnCode ];
		string script	= string.Format("alert('{0}'); parent.location.href='/';", msg);

		Utility.JsCall( sender, script );
	}
}
