<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommentModify.aspx.cs" Inherits="Common_Popup_CommentModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>제목 없음</title>
	<link href="/Common/Css/global.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:500px;height:300px;">
		<asp:ScriptManager ID="ScriptManager1" runat="server">
		</asp:ScriptManager>
		
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
		<asp:Panel ID="pnPassword" runat="server" Visible="false">
			<div style="text-align:center;width:500px;">
				비밀번호 : 
				<asp:TextBox ID="txtCheckPassword" runat="server"></asp:TextBox> <asp:ImageButton ID="ibCheckPassword" runat="server" ImageUrl="/common/images/btn_ok.gif" OnClick="ibCheckPassword_Click" />
			</div>
		</asp:Panel>
		<asp:panel ID="pnModify" runat="server" Visible="false">
			<table class="tb_comment">
			<tr>
				<td class="tb_title" style="width:100px;">이름</td>
				<td>
					<asp:TextBox ID="txtUserName" runat="server" BorderStyle="Groove"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="tb_title">비밀번호</td>
				<td>
					<asp:TextBox ID="txtPassword" runat="server" BorderStyle="groove" TextMode="password"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="tb_title">블로그 주소</td>
				<td>
					http://<asp:TextBox ID="txtUserBlogUrl" runat="server" style="width:90%" BorderStyle="Groove"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="tb_title">내용</td>
				<td>
					<asp:TextBox ID="txtContent" runat="server" Rows="5" Columns="80" TextMode="MultiLine" style="width:80%" BorderStyle="Groove"></asp:TextBox>
					<asp:ImageButton ID="btnRegister" runat="server" ImageUrl="/common/images/btn_modify.gif" OnClick="btnRegister_Click" />
				</td>
			</tr>
			<tr>
				<td class="tb_title">
					<img src="/Common/ConfirmBitmapHandler.ashx" alt="인증번호" />
				</td>
				<td>
					<asp:TextBox ID="txtConfirmBitmapHandler" runat="server"></asp:TextBox>
				</td>
			</tr>
		</table>
	</asp:panel>
	</ContentTemplate>
		</asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
