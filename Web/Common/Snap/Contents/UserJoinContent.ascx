<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserJoinContent.ascx.cs" Inherits="Common_Snap_Contents_UserJoinContent" %>
	<asp:UpdatePanel ID="panelJoin" runat="server">
	<ContentTemplate>
		<table style="width:100%;">
			<tr>
				<td class="tb_title" style="width:100px;">이메일</td>
				<td class="tb_content">
					<asp:TextBox ID="txtEMail" runat="server" BorderStyle="Groove" Width="300px"></asp:TextBox>&nbsp;<br />
					<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEMail"
						ErrorMessage="이메일 주소가 정확하지 않습니다" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
			</tr>
			<tr>
				<td class="tb_title">이름</td>
				<td class="tb_content">
					<asp:TextBox ID="txtName" runat="server" BorderStyle="Groove"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="tb_title">닉네임</td>
				<td class="tb_content">
					<asp:TextBox ID="txtNickName" runat="server" BorderStyle="Groove"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="tb_title">홈페이지</td>
				<td class="tb_content">
					http://<asp:TextBox ID="txtHomepage" runat="server" BorderStyle="Groove" Width="300px"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="tb_title">비밀번호</td>
				<td class="tb_content">
					<asp:TextBox ID="txtPassword" runat="server" BorderStyle="Groove" TextMode="Password"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="tb_title">비밀번호 확인</td>
				<td class="tb_content">
					<asp:TextBox ID="txtPassword2" runat="server" BorderStyle="Groove" TextMode="Password"></asp:TextBox>
				</td>
			</tr>
		</table>
		
		<table style="text-align:center;width:100%;">
			<tr>
				<td>
					<asp:ImageButton ID="btnUserJoin" runat="server" ImageUrl="/common/images/btn_regist.gif" OnClick="btnUserJoin_Click"  />
				</td>
			</tr>
		</table>
	</ContentTemplate>
	</asp:UpdatePanel>