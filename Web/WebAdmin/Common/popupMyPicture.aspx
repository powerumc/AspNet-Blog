<%@ Page Language="C#" AutoEventWireup="true" CodeFile="popupMyPicture.aspx.cs" Inherits="WebAdmin_Common_popupMyPicture" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>내사진 등록</title>
	<link href="/Common/Css/global.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="formMyPicture" runat="server">
    <div style="text-align:center;">
		<asp:FileUpload ID="fileMyPicture" runat="server" Width="300px" />
		<asp:LinkButton ID="lnkRegister" runat="server" OnClick="lnkRegister_Click">
			<img src="/common/images/btn_regist.gif" alt="사진등록" style="vertical-align:bottom;" />
		</asp:LinkButton>
    </div>
    </form>
</body>
</html>
