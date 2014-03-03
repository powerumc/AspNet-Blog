<%@ Control Language="C#" AutoEventWireup="true" Inherits="Umc.Core.Web.Controls.ArticleContent" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="Umc.Core.Util" %>
<%@ Import Namespace="Umc.Core.Modules.Article"%>
<table style="width:100%" id="tblArticle" runat="server">
	<tr>
		<td style="width:80%">
			<asp:HyperLink ID="hpTitle" runat="server" Font-Size="30px"></asp:HyperLink>
		</td>
		<td style="width:20%">
			<asp:Label ID="lblInsertDate" runat="server" Font-Size="20px" Font-Bold="true"></asp:Label>
		</td>
	</tr>
	<tr>
		<td colspan="2" class="tb_line" style="height:2px;"></td>
	</tr>
	<tr>
		<td colspan="2" style="text-align:left;">
			<asp:DataList ID="dlAttachFile" runat="server">
				<ItemTemplate>
					<tr>
						<td>
							<a href='/common/download.aspx?<%= ArticleConst.PARAM_ATTACHFILE_NO %>=<%# Eval("FileNo") %>' class="download">
								<img src="/common/images/ico_disk.gif" alt="다운로드" /> <%# Path.GetFileName(Eval("FilePath").ToString()) %>
							</a>
						</td>
					</tr>
				</ItemTemplate>
			</asp:DataList>
		</td>
	</tr>
	<tr>
		<td colspan="2" style="height:10px;"></td>
	</tr>
</table>
<div id="divContent" runat="server"></div>
<br />
<br />
<div id="divTag" runat="server" class="tag">
태그 : 
	<asp:Repeater ID="dlTag" runat="server">
		<ItemTemplate>
			<a href='<%#Utility.MakeTagUrl(Eval("TagName","{0}")) %>' rel="tag" target="_top"><%# Eval("TagName") %></a>&nbsp;&nbsp;&nbsp;
		</ItemTemplate>
	</asp:Repeater>
</div>
<br />
<div class="trackback" id="divTrackback" runat="server">
	트랙백 주소 : <asp:Label ID="lblTrackbackUrl" runat="server"></asp:Label>
</div>
<br />
<div id="divArticleInfo" runat="server" class="tag">
<a id="aGoComment" runat="server" target="_parent">
	댓글 ( <asp:Literal ID="ltrCommentCount" runat="server"></asp:Literal>개 )
</a>
&nbsp;&nbsp;&nbsp;
<a href="javascript:openTrackback('<%= ArticleNo %>');">
트랙백 ( <asp:Literal ID="ltrTrackbackCount" runat="server"></asp:Literal>개 )
</a>
	<div id="divTrackback_<%= ArticleNo %>" style="display:none;">
		<asp:DataList ID="dlTrackbackList" runat="server">
			<ItemTemplate>
				<tr>
					<td style="width:100px;text-align:right;padding-right:10px;">Trackback From.</td>
					<td>
						<%# Eval("Blog_Name") %> / <%# Eval("InsertDate","{0:yyyy-MM-dd hh:mm}") %>
					</td>
				</tr>
				<tr>
					<td style="text-align:right;padding-right:10px;">Subject</td>
					<td>
						<a href='<%# Eval("Url") %>' target="_blank">
						<%# Eval("Title") %>
						</a>
					</td>
				</tr>
			</ItemTemplate>
		</asp:DataList>
	</div>
</div>

<asp:PlaceHolder ID="phComment" runat="server"></asp:PlaceHolder>
