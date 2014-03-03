<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TagList.ascx.cs" Inherits="Common_Snap_Contents_TagList" %>
<%@ Import Namespace="System.Data" %>
<asp:DataList ID="dlTagList" Width="500" runat="server" OnItemDataBound="dlTagList_ItemDataBound">
	<ItemTemplate>
			<tr>
				<td style="width:100px;">
					<%# ((DateTime)Eval("InsertDate")).ToString("yyyy-MM-dd") %>
				</td>
				<td style="width:100px;">
					<%# Eval("CategoryMTitle") %>
				</td>
				<td>
					<asp:HyperLink ID="hpTitle" runat="server" Target="_top"></asp:HyperLink>
					<asp:Literal ID="ltrNewIcon" runat="server"></asp:Literal>
				</td>
			</tr>
	</ItemTemplate>
</asp:DataList>
