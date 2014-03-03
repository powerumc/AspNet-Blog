<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BreakerList.ascx.cs" Inherits="WebAdmin_09Breaker_Templates_BreakerList" %>
<%@ Import Namespace="Umc.Core" %>
<script type="text/javascript">
	function breakerUpdate()
	{
		<%= Page.GetPostBackEventReference(lnkBreakerUpdate) %>;
	}
</script>
<asp:LinkButton ID="lnkBreakerUpdate" runat="server" OnClick="lnkBreakerUpdate_Click"></asp:LinkButton>
<asp:DataList ID="dlBreakerList" runat="server" OnItemCommand="dlBreakerList_ItemCommand" OnItemDataBound="dlBreakerList_ItemDataBound">
	<HeaderTemplate>
		<tr>
			<td style="width:50px;" class="tb_title">번호</td>
			<td style="width:150px;" class="tb_title">아이피</td>
			<td style="width:100px;" class="tb_title">차단날짜</td>
			<td style="width:150px" class="tb_title">명령</td>
		</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr>
			<td style="text-align:center;">
				<%# Eval("SeqNo") %>
			</td>
			<td>
				<%# Eval("UserIP") %>
			</td>
			<td>
				<%# Eval("InsertDate","{0:yyyy/MM/dd hh:mm}") %>
			</td>
			<td>
				<asp:LinkButton ID="lnkUnBreaker" runat="server" CommandName="unbreaker" CommandArgument='<%# Eval("UserIP") %>'>해제</asp:LinkButton>
			</td>
		</tr>
	</ItemTemplate>
</asp:DataList>
<br style="line-height:30px;" />
<a href="<%= CurrentSitemapInfo.GetInitParam( Parameters.TEMPLATE_POPUP ) %>" title="차단 아이피 등록" rel="gb_page_center[300,150]">
	<img src="/Common/images/btn_regist.gif" alt="차단아이피 등록" />
</a>
