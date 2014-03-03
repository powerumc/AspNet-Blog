<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TagCloud.ascx.cs" Inherits="WebAdmin_03Tag_TagCloud" %>
<div style="width:500px;">
<asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
	<ItemTemplate>
		<asp:HyperLink ID="hpTagName" runat="server" CssClass="tagcloud"></asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;
	</ItemTemplate>
</asp:Repeater>
</div>