<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CategoryContent.ascx.cs" Inherits="Common_Snap_Contents_CategoryContent" %>
<%@ Import Namespace="System.Data" %>
<asp:DataList ID="dlCategory" Width="500" runat="server" OnItemDataBound="dlCategory_ItemDataBound">
	<ItemTemplate>
			<tr>
				<td style="width:100px;">
					<%# ((DateTime)Eval("InsertDate")).ToString("yyyy-MM-dd") %>
				</td>
				<td style="width:100px;"> 
					<asp:HyperLink ID="hpCategoryMTitle" runat="server" Target="_parent"></asp:HyperLink>
				</td>
				<td>
					<asp:HyperLink ID="hpTitle" runat="server" Target="_top"></asp:HyperLink>
					<asp:Literal ID="ltrNewIcon"  runat="server"></asp:Literal>
				</td>
			</tr>
	</ItemTemplate>
</asp:DataList>
