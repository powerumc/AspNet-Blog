<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProfileContent.ascx.cs" Inherits="Common_Snap_Contents_ProfileContent" %>
<%@ Import Namespace="Umc.Core.Modules.Snap" %>
<table style="width:100%">
	<tr>
		<td style="text-align:left;" class="content_title">
			내 프로필
		</td>
	</tr>
	<tr>
		<td class="tb_line"></td>
	</tr>
</table>
<table style="width:100%;" class="content_table1">
	<tr>
		<td style="text-align:center;">
			<asp:Image ID="imgPicture" runat="server" />
			<table style="width:80%;padding-left:100px;font-size:15px;text-align:left;">
				<tr>
					<td class="tb_title">
						이  름 : 
					</td>
					<td>
						<asp:Label ID="lblName" runat="server"></asp:Label>
					</td>
				</tr>
				<tr>
					<td class="tb_title">
						닉네임 : 
					</td>
					<td>
						<asp:Label ID="lblNickName" runat="server"></asp:Label>
					</td>
				</tr>
				<tr>
					<td class="tb_title">
						머릿말 : 
					</td>
					<td>
						<asp:Label ID="lblIntroduction" runat="server"></asp:Label>
					</td>
				</tr>
				<tr>
					<td class="tb_title">
						사는곳 : 
					</td>
					<td>
						<asp:Label ID="lblAddress" runat="server"></asp:Label>
					</td>
				</tr>
				<tr>
					<td class="tb_title">
						취  미 : 
					</td>
					<td>
						<asp:Label ID="lblHobby" runat="server"></asp:Label>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>