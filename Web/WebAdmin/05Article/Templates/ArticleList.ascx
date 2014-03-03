<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleList.ascx.cs" Inherits="WebAdmin_05Article_Templates_ArticleList" %>
<p />
<asp:DataList ID="dlArticleList" runat="server" Width="600">
	<ItemTemplate>
		<tr>
			<td style="width:100px">
				<%# Eval("InsertDate","{0:yyyy.MM.dd HH:mm}")%>
			</td>
			<td style="width:400px">
				<a href='<%=ViewQueryString%><%#Eval("ArticleNo")%>'><%# Eval("Title") %></a>				
			</td>
		</tr>
	</ItemTemplate>
</asp:DataList>