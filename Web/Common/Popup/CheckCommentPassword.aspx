<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckCommentPassword.aspx.cs" Inherits="Common_Popup_CheckCommentPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>제목 없음</title>
	<link href="/Common/Css/global.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:400px;height:200px; text-align:center;vertical-align:middle;">
		비밀번호 : 
		<asp:TextBox ID="txtPassword" runat="server"></asp:TextBox> 
		<asp:ImageButton ID="ibCheck" runat="server" ImageUrl="/common/images/btn_ok.gif" OnClick="ibCheck_Click" />
    </div>
    </form>
</body>
</html>
