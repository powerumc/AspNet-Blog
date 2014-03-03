<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MemberList.ascx.cs" Inherits="WebAdmin_06Member_Templates_MemberList" %>
<%@ Register Assembly="Umc.Core" Namespace="Umc.Core.Web.Controls" TagPrefix="cc1" %>
<asp:DropDownList ID="ddlPageSize" runat="server">
	<asp:ListItem Value="10">10개</asp:ListItem>
	<asp:ListItem Value="20">20개</asp:ListItem>
	<asp:ListItem Value="30">30개</asp:ListItem>
	<asp:ListItem Value="50">50개</asp:ListItem>
</asp:DropDownList>
<asp:DropDownList ID="ddlSearchKeyword" runat="server">
	<asp:ListItem Value="email">이메일</asp:ListItem>
	<asp:ListItem Value="name">이름</asp:ListItem>
	<asp:ListItem Value="nickname">닉네임</asp:ListItem>
	<asp:ListItem Value="level">레벨</asp:ListItem>
	<asp:ListItem Value="homepage">홈페이지</asp:ListItem>
</asp:DropDownList>
<asp:TextBox ID="txtSearchString" runat="server"></asp:TextBox>
<asp:LinkButton ID="lnkSearch" runat="server" OnClick="lnkSearch_Click">
	<img src="/common/images/btn_search.gif" alt="검색" style="vertical-align:baseline;" />
</asp:LinkButton>
<br />

<asp:DataList ID="dlList" runat="server" OnEditCommand="dlList_EditCommand" Width="100%" OnCancelCommand="dlList_CancelCommand" OnUpdateCommand="dlList_UpdateCommand" OnItemDataBound="dlList_ItemDataBound" OnItemCommand="dlList_ItemCommand">
	<HeaderTemplate>
		<tr>
			<td class="tb_title" style="width:50px;">번호</td>
			<td class="tb_title" style="width:80px;">이메일</td>
			<td class="tb_title" style="width:80px;">이름</td>
			<td class="tb_title" style="width:80px;">닉네임</td>
			<td class="tb_title" style="width:80px;">레벨</td>
			<td class="tb_title" style="width:150px;">홈페이지</td>
			<td class="tb_title" style="width:150px;">명령</td>
		</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr style="height:25px;">
			<td style="text-align:center;"><%= Num %></td>
			<td style="text-align:center;"><%# Eval("EMail") %></td>
			<td style="text-align:center;"><%# Eval("Name") %></td>
			<td style="text-align:center;"><%# Eval("NickName")%></td>
			<td style="text-align:center;"><%# Eval("Level")%></td>
			<td style="text-align:left;">
				<a href='http://<%# Eval("HomePage")%>' target="_blank">
					<%#Eval("HomePage")%>
				</a>
			</td>
			<td style="text-align:center;">
				<asp:LinkButton ID="lnkModify" runat="server" CommandName="Edit">
					<img src="/common/images/btn_modify.gif" alt="수정" />
				</asp:LinkButton>
				<asp:LinkButton ID="lnkRemove" runat="server" CommandName="Delete" CommandArgument='<%#Eval("EMail") %>'>
					<img src="/common/images/btn_delete.gif" alt="삭제" />
				</asp:LinkButton>
			</td>
		</tr>
		<tr>
			<td colspan="7" class="tb_line"></td>
		</tr>
	</ItemTemplate>
	<EditItemTemplate>
		<tr style="height:25px;">
			<td>&nbsp;</td>
			<td>
				<asp:TextBox ID="txtEMail" runat="server" Text='<%#Eval("EMail") %>' Width="80px"></asp:TextBox>
			</td>
			<td>
				<asp:TextBox ID="txtName" runat="server" Text='<%#Eval("Name") %>' Width="80px"></asp:TextBox>
			</td>
			<td>
				<asp:TextBox ID="txtNickName" runat="server" Text='<%#Eval("NickName") %>' Width="80px"></asp:TextBox>
			</td>
			<td>
				<asp:DropDownList ID="ddlLevel" runat="server" Width="80px"></asp:DropDownList>
			</td>
			<td style="text-align:left;">
				<asp:TextBox ID="txtHomePage" runat="server" Text='<%#Eval("HomePage") %>' Width="100px"></asp:TextBox>
			</td>
			<td style="text-align:center;">
				<asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" CommandArgument='<%#Eval("Email") %>'>
					<img src="/common/images/btn_OK.gif" alt="수정하기" />
				</asp:LinkButton>
				<asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel">
					<img src="/common/images/btn_cancel.gif" alt="취소" />
				</asp:LinkButton>
			</td>
		</tr>
		<tr>
			<td colspan="7" class="tb_line"></td>
		</tr>
	</EditItemTemplate>
</asp:DataList>
<br />
<div style="width:100%;text-align:center;">
	<cc1:UmcPager ID="Pager" runat="server" OnPageIndexChanged="Pager_PageIndexChanged" />
</div>