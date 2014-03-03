<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProfileInfo.ascx.cs" Inherits="WebAdmin_01Blog_ProfileInfo" %>
<table style="width:100%;">
	<tr>
		<td colspan="2" class="tb_topline">
		</td>
	</tr>
	<tr>
		<td style="width:100px;" class="tb_title">이름 공개</td>
		<td class="tb_content">
			<asp:RadioButtonList ID="rblPublicName" runat="server" RepeatDirection="Horizontal" Width="200px">
				<asp:ListItem Value="True" Text="예"></asp:ListItem>
				<asp:ListItem Value="False" Text="아니오"></asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr>
		<td colspan="2" class="tb_line"></td>
	</tr>
	<tr>
		<td style="width:100px;" class="tb_title">성별 공개</td>
		<td class="tb_content">
			<asp:RadioButtonList ID="rblPublicGender" runat="server" RepeatDirection="Horizontal" Width="200px">
				<asp:ListItem Value="True" Text="예"></asp:ListItem>
				<asp:ListItem Value="False" Text="아니오"></asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr>
		<td colspan="2" class="tb_line"></td>
	</tr>
	<tr>
		<td style="width:100px;" class="tb_title">주소 공개</td>
		<td class="tb_content">
			<asp:RadioButtonList ID="rblPublicAddress" runat="server" RepeatDirection="Horizontal" Width="200px">
				<asp:ListItem Value="True" Text="예"></asp:ListItem>
				<asp:ListItem Value="False" Text="아니오"></asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr>
		<td colspan="2" class="tb_line"></td>
	</tr>
	<tr>
		<td style="width:100px;" class="tb_title">방명록 공개</td>
		<td class="tb_content">
			<asp:RadioButtonList ID="rblPublicGuestBoard" runat="server" RepeatDirection="Horizontal" Width="200px">
				<asp:ListItem Value="True" Text="예"></asp:ListItem>
				<asp:ListItem Value="False" Text="아니오"></asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
</table>
<table style="width:100%">
	<tr>
		<td style="text-align:right;">
			<asp:LinkButton ID="lnkRegister" runat="server" OnClick="lnkRegister_Click">
				<img src="/common/images/btn_regist.gif" alt="등록" />
			</asp:LinkButton>
		</td>
	</tr>
</table>