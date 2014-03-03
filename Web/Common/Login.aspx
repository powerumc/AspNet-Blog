<%@ Page Language="C#"  Inherits="Umc.Core.Web.UmcBlogBasePage" %>
<%@ Import Namespace="Umc.Core.Authenticate" %>
<%@ Import Namespace="Umc.Core.Util" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
	private string returnUrl;
	
	private void Page_Load( object sender, EventArgs e)
	{
		returnUrl		= GetParamString("returnUrl", "/");
	}
	
	protected void lnkLogin_Click(object sender, EventArgs e)
	{
		string password	= FormsAuthentication.HashPasswordForStoringInConfigFile( 
			txtPassword.Text, AuthenticateConst.AUTHENTICATE_HASH_FORMAT );
		
		int result		= Authenticator.GetInstance().CompareEmailAndPassword( txtEmail.Text, password );

		if (result == 1)
		{
			UserInfo userInfo	= Authenticator.GetInstance().GetUserInfo( txtEmail.Text, Context );

			if (Request.Url.ToString().ToLower().IndexOf("/webadmin") > 0)
			{
				if (userInfo.Level != LevelAttribute.ADMIN)
				{
					Utility.JS_Alert(sender, "관리자가 아닙니다");
					return;
				}
			}
			else
			{
				Utility.JsCall(sender, "top.mainUpdate(); top.GB_hide();");
				return;
			}

			if (returnUrl == "/")
			{
				Utility.JsCall(sender, "top.mainUpdate(); top.GB_hide();");
				return;
			}
			
			Response.Redirect( returnUrl );
		}
		else if (result == -1)
		{
			Utility.JS_Alert( sender, "이메일이 존재하지 않습니다");
		}
		else if (result == 0)
		{
			Utility.JS_Alert( sender, "패스워드가 일치하지 않습니다");
		}
		
		txtEmail.Text			= string.Empty;
		txtPassword.Text		= string.Empty;
	}
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>로그인</title>
    <script type="text/javascript">
		function window::onload()
		{
			document.getElementById("<%= txtEmail.ClientID %>").focus();
		}
		function loginEnter()
		{
			if( event.keyCode==13 )
				<%= ClientScript.GetPostBackEventReference( lnkLogin, "" ) %>;
				return false;
		}
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%;;text-align:center;vertical-align:middle;">
		<center>
		<table style="width:300px;">
			<tr>
				<td style="width:100px;">이메일</td>
				<td style="width:200px;text-align:left;">
					<asp:TextBox ID="txtEmail" runat="server" Width="150px" onkeypress="loginEnter();"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>비밀번호</td>
				<td style="text-align:left;">
					<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px" onkeypress="loginEnter();"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td colspan="2" style="text-align:center;">
					<asp:LinkButton ID="lnkLogin" runat="server" OnClick="lnkLogin_Click">
						<img src="/common/images/btn_gologin.gif" alt="로그인" />
					</asp:LinkButton>
				</td>
			</tr>
		</table>
		</center>
    </div>
    </form>
</body>
</html>
