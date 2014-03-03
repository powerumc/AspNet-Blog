<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmoticonRegistPopup.aspx.cs" Inherits="WebAdmin_07Emoticon_Templates_EmoticonRegistPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>제목 없음</title>
    <script type="text/javascript" >
		var update			= function()
		{
			top.update();
			top.GB_hide();
		}
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		텍스트 : <asp:TextBox ID="txtString" runat="server"></asp:TextBox><br />
		이미지 : <asp:FileUpload ID="file1" runat="server" />
		<br />
		설명   : <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="90px" Width="259px"></asp:TextBox>
		<p />
		<asp:Label ID="lblResult" runat="server"></asp:Label>
		<br /><br />
		<asp:LinkButton ID="lnkWriteOK" runat="server" OnClick="lnkWriteOK_Click" >
			<img src="/Common/Images/Btn_ok.gif" alt="확인" />
		</asp:LinkButton>
    </div>
    </form>
</body>
</html>
