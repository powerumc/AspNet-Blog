<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConnectionLogList.ascx.cs" Inherits="WebAdmin_08Stat_Templates_ConnectionLogList" %>
<%@ Register Assembly="Umc.Core" Namespace="Umc.Core.Web.Controls" TagPrefix="cc1" %>
<%@ Import Namespace="Umc.Core.Util" %>
<asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
	<asp:ListItem Value="15">15개씩</asp:ListItem>
	<asp:ListItem Value="30">30개씩</asp:ListItem>
	<asp:ListItem Value="50">50개씩</asp:ListItem>
	<asp:ListItem Value="100">100개씩</asp:ListItem>
	<asp:ListItem Value="1000">1000개씩</asp:ListItem>
</asp:DropDownList>
<asp:DropDownList ID="ddlSearchKeyword" runat="server">
	<asp:ListItem Value="ip">아이피</asp:ListItem>
	<asp:ListItem Value="url">접속경로</asp:ListItem>
	<asp:ListItem Value="date">날짜</asp:ListItem>
</asp:DropDownList>
&nbsp;<asp:TextBox ID="txtSearchString" runat="server"></asp:TextBox>
&nbsp;
<asp:LinkButton ID="lnkSearch" runat="server" OnClick="lnkSearch_Click">
	<img src="/common/images/btn_search.gif" alt="검색" />
</asp:LinkButton>
<br />
<asp:DataList ID="dlList" runat="server" OnItemCommand="dlList_ItemCommand" OnItemDataBound="dlList_ItemDataBound">
	<HeaderTemplate>
		<tr>
			<td style="width:50px;" class="tb_title">번호</td>
			<td style="width:200px;" class="tb_title">날짜</td>
			<td style="width:100px" class="tb_title">세션 아이디</td>
			<td style="width:200px;" class="tb_title">접속 경로</td>
			<td style="width:100px;" class="tb_title">접속 아이피</td>
			<td style="width:100px;" class="tb_title">명령</td>
		</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr style="height:25px;">
			<td style="text-align:center;">
				<%# Eval("SeqNO") %>
			</td>
			<td style="text-align:center;">
				<%# Eval("InsertDate","{0:yyyy/MM/dd hh:mm:ss}") %>
			</td>
			<td style="text-align:center;">
				<%# Eval("SessionID") %>
			</td>
			<td onmouseover='if( "<%# Eval("UrlReferrer") %>" != "" ) toolTip("<%# Eval("UrlReferrer") %>", this)' >
				<div style="width:200px;"><%# Utility.CutString( Eval("UrlReferrer").ToString(), 35) %></div>
			</td>
			<td style="text-align:center;">
				<%# Eval("UserIP") %>
			</td>
			<td style="text-align:left;">
				<asp:LinkButton ID="lnkBreaker" runat="server" CommandName="breaker" CommandArgument='<%# Eval("UserIP") %>' Visible="false">차단</asp:LinkButton>  <asp:LinkButton ID="lnkUnBreaker" runat="server" CommandName="unbreaker" CommandArgument='<%# Eval("UserIP") %>' Visible="false">해제</asp:LinkButton>
			</td>
		</tr>
		<tr>
			<td colspan="6" style="height:1px;" class="tb_line"></td>
		</tr>
	</ItemTemplate>
</asp:DataList>
<br />
<div style="width:100%;text-align:center;">
<cc1:UmcPager ID="UmcPager1" runat="server" OnPageIndexChanged="UmcPager1_PageIndexChanged" />
</div>