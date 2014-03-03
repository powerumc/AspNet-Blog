<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RemoveTag.ascx.cs" Inherits="WebAdmin_03Tag_RemoveTag" %>
<div style="width:500px;">
<asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound" OnItemCommand="rptList_ItemCommand">
	<ItemTemplate>
		<asp:LinkButton ID="lnkTagName" runat="server" CssClass="tagcloud" CommandName="removeTag" CommandArgument='<%# Eval("TagName") %>'></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
	</ItemTemplate>
</asp:Repeater>
</div>