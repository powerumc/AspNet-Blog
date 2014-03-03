<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommentReply.aspx.cs" Inherits="Common_Popup_CommentReply" %>

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
		
		<asp:UpdatePanel ID="pnCommentInsert" runat="server">
			<ContentTemplate>
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
							http:// <asp:TextBox ID="txtUserBlogUrl" runat="server" BorderStyle="Groove" Width="250px"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="tb_title">내용</td>
						<td>
							<asp:TextBox ID="txtContent" runat="server" Rows="5" Columns="80" TextMode="MultiLine" style="width:80%" BorderStyle="Groove"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="tb_title">
							<img src="/common/ConfirmBitmapHandler.ashx" alt="인증번호" />
						</td>
						<td>
							<asp:TextBox ID="txtConfirmBitmapHandler" runat="server"></asp:TextBox>
							<asp:ImageButton ID="btnRegister" runat="server" ImageUrl="/common/images/btn_regist.gif" OnClick="btnRegister_Click" />
						</td>
					</tr>
				</table>
			</ContentTemplate>
		</asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
