<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Privacy.ascx.cs" Inherits="WebAdmin_02Privacy_Privacy" %>
<table style="width:100%">
	<tr>
		<td colspan="2" class="tb_topline"></td>
	</tr>
	<tr>
		<td class="tb_title" style="width:100px;">
			댓글 허용
		</td>
		<td class="tb_content">
			<asp:RadioButtonList ID="rblCanWriteMemo" runat="server" RepeatDirection="Horizontal" Width="200px">
				<asp:ListItem Value="True" Text="예"></asp:ListItem>
				<asp:ListItem Value="False" Text="아니오"></asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">
			방명록쓰기 허용
		</td>
		<td class="tb_content">
			<asp:RadioButtonList ID="rblCanWriteGuestBoard" runat="server" RepeatDirection="Horizontal" Width="200px">
				<asp:ListItem Value="True" Text="예"></asp:ListItem>
				<asp:ListItem Value="False" Text="아니오"></asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">
			방명록으로 사용할 아티클
		</td>
		<td class="tb_content">
			<asp:DropDownList ID="ddlGuestBookArticle" runat="server"></asp:DropDownList>
		</td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">
			게시판쓰기 허용
		</td>
		<td class="tb_content">
			<asp:RadioButtonList ID="rblCanWriteBbs" runat="server" RepeatDirection="Horizontal" Width="200px">
				<asp:ListItem Value="True" Text="예"></asp:ListItem>
				<asp:ListItem Value="False" Text="아니오"></asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">
			RSS 공개
		</td>
		<td class="tb_content">
			<asp:RadioButtonList ID="rblPublicRSS" runat="server" RepeatDirection="Horizontal" Width="200px">
				<asp:ListItem Value="True" Text="예"></asp:ListItem>
				<asp:ListItem Value="False" Text="아니오"></asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr>
		<td colspan="2" class="tb_line"></td>
	</tr>
	<tr>
		<td class="tb_title">
			RSS 공개 아티클 갯수
		</td>
		<td class="tb_content">
			<asp:DropDownList ID="rblLimitRssCount" runat="server">
				<asp:ListItem Value="10">10개</asp:ListItem>
				<asp:ListItem Value="15">15개</asp:ListItem>
				<asp:ListItem Value="20">20개</asp:ListItem>
				<asp:ListItem Value="30">30개</asp:ListItem>
				<asp:ListItem Value="50">50개</asp:ListItem>
				<asp:ListItem Value="2147483647 ">제한 없음</asp:ListItem>
			</asp:DropDownList>
		</td>
	</tr>
	<tr>
		<td colspan="2" class="tb_line"></td>
	</tr>
	<tr>
		<td class="tb_title">
			마우스<br />오른쪽버튼<br />허용
		</td>
		<td class="tb_content">
			<asp:RadioButtonList ID="rblAllowMouseRightButton" runat="server" RepeatDirection="Horizontal" Width="200px">
				<asp:ListItem Value="True" Text="예"></asp:ListItem>
				<asp:ListItem Value="False" Text="아니오"></asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr>
		<td colspan="2" class="tb_line"></td>
	</tr>
</table>
<table style="width:100%">
	<tr>
		<td style="text-align:right;">
			<asp:LinkButton ID="lnkRegister" runat="server" OnClick="lnkRegister_Click">
				<img src="/Common/Images/btn_regist.gif" alt="등록" />
			</asp:LinkButton>
		</td>
	</tr>
</table>