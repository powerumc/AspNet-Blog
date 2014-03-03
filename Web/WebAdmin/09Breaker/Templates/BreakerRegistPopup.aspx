<%@ Page Language="C#" Inherits="Umc.Core.WebAdmin.WebAdminTemplate"%>
<%@ Import Namespace="Umc.Core.Modules.Breaker" %>
<%@ Import Namespace="Umc.Core.Util" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

	protected void lnkRegist_Click(object sender, EventArgs e)
	{
		if (txtUserIP.Text == string.Empty)
		{
			Utility.JS_Alert( this, BreakerConst.MESSAGE_BREAKER_EMPTY_USERIP );
			return;
		}
		BreakerModel model	= new BreakerModel();
		model.UserIP		= txtUserIP.Text;
		
		int result			= BreakerManager.GetInstance().InsertBreaker( model );


		if (result == -1)
		{
			Utility.JS_Alert(this, BreakerConst.MESSAGE_BREAKER_ALREADY_INSERT);
		}
		else
		{
			Utility.JsCall(this, "top.breakerUpdate()");
		}
	}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>제목 없음</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-top:25px;text-align:center;width:100%">
		아이피를 입력하세요<br />
		<asp:TextBox ID="txtUserIP" runat="server"></asp:TextBox>
		<p />
		<asp:LinkButton ID="lnkRegist" runat="server" OnClick="lnkRegist_Click">
			<img src="/common/images/btn_ok.gif" alt="확인" />
		</asp:LinkButton>
    </div>
    </form>
</body>
</html>
