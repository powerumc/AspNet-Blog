<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmoticonList.ascx.cs" Inherits="WebAdmin_07Emoticon_Templates_EmoticonList" %>
<%@ Import Namespace="Umc.Core" %>
<script type="text/javascript">
	var update			= function()
	{
		document.getElementById("<%= lnkRefresh.ClientID %>").click();
	}
</script>
<asp:LinkButton ID="lnkRefresh" runat="server" OnClick="lnkRefresh_Click">새로고침</asp:LinkButton>
<p />
<asp:DataList ID="dlList" runat="server" OnItemCommand="dlList_ItemCommand" OnItemDataBound="dlList_ItemDataBound" Width="100%">
	<HeaderTemplate>
		<tr>
			<td class="tb_title" style="width:50px;">번호</td>
			<td class="tb_title" style="width:80px;">텍스트</td>
			<td class="tb_title" style="width:150px;">이미지</td>
			<td class="tb_title" style="width:100px;">설명</td>
			<td class="tb_title" style="width:100px;">날짜</td>
			<td class="tb_title">명령</td>
		</tr>
	</HeaderTemplate>
	<ItemTemplate>
		<tr style="height:25px;">
			<td><%# Eval("SeqNo") %></td>
			<td><%# Eval("EmoticonString") %></td>
			<td><img src='<%# EmoticonImage( (string)Eval("EmoticonValue") ) %>' alt="" /></td>
			<td><%# Eval("Description") %></td>
			<td><%# ((DateTime)Eval("Insertdate")).ToShortDateString() %></td>
			<td>
				<asp:LinkButton ID="lnkRemove" runat="server" CommandName="remove" CommandArgument='<%# Eval("SeqNo") %>'>
					<img src="/Common/Images/btn_delete.gif" alt="삭제" />
				</asp:LinkButton>
				<a href='<%= CurrentSitemapInfo.GetInitParam( Parameters.TEMPLATE_POPUP )  %>?seqNo=<%# Eval("SeqNo") %>' title="이모티콘" rel="gb_page_center[300,250]">
					<img src="/Common/Images/Btn_modify.gif" alt="수정" />
				</a>
			</td>
		</tr>
	</ItemTemplate>
</asp:DataList>
<div style="width:100%">
	<a href="<%= CurrentSitemapInfo.GetInitParam( Parameters.TEMPLATE_POPUP ) %>" title="이모티콘" rel="gb_page_center[300, 250]">
		<img src="/Common/Images/btn_regist.gif" alt="등록" />
	</a>
</div>