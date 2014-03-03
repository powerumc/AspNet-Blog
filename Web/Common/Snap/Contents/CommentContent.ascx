<%@ Control Language="C#" AutoEventWireup="true" Inherits="Umc.Core.Web.Controls.CommentContent" %>

<script runat="server">
	protected void lnkUpdate_Click(object sender, EventArgs e)
	{
		bind();
	}
</script>

<br />
<script type="text/javascript">
	var	commentUpdate<%= ArticleNo %>			= function()
	{
		document.getElementById("<%= lnkUpdate.ClientID %>").click();
	}
</script>
<asp:UpdatePanel ID="panelComment" runat="server">
	<ContentTemplate>
		<asp:LinkButton ID="lnkUpdate" runat="server" OnClick="lnkUpdate_Click"></asp:LinkButton>
		<asp:DataList ID="dlCommentList" runat="server" Width="100%" CssClass="tb_commentlist" CellPadding="5" CellSpacing="0" OnItemDataBound="dlCommentList_ItemDataBound" OnItemCommand="dlCommentList_ItemCommand">
			<ItemTemplate>
				<tr>
					<td id="tdComment" runat="server">
						<table id="tbComment" style="width:100%" runat="server">
							<tr>
								<td style="width:250px;">
									<a name="#<%#Eval("CommentNo") %>"></a>
									From. <asp:HyperLink ID="hpUserName" runat="server"></asp:HyperLink>   <%#Eval("InsertDate","{0:yyyy/MM/dd hh:mm}") %>
									&nbsp;<asp:Literal ID="ltrNewIcon" runat="server"></asp:Literal>
									
								</td>
								<td style="text-align:right;text-align:right">
									<asp:LinkButton ID="lnkReply" runat="server" Visible="false">Reply</asp:LinkButton>&nbsp;
									<asp:LinkButton ID="lnkRemove" runat="server" Visible="false" CommandName="remove" CommandArgument='<%#Eval("CommentNo") %>'>Delete</asp:LinkButton>&nbsp;
									<asp:LinkButton ID="lnkModify" runat="server" Visible="false">Modify</asp:LinkButton>
									
								</td>
							</tr>
							<tr>
								<td colspan="2">
									<asp:Label ID="lblContent" runat="server"></asp:Label>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</ItemTemplate>
		</asp:DataList>
	<br />
	<a name="#comment"></a>
	<div style="text-align:center;" id="divWriteComment" runat="server">
	<table class="tb_comment">
		<tr>
			<td class="tb_title" style="width:100px;">이름</td>
			<td>
				<asp:TextBox ID="txtUserName" runat="server" BorderStyle="Groove"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td class="tb_title">비밀번호</td>
			<td>
				<asp:TextBox ID="txtPassword" runat="server" BorderStyle="groove" TextMode="password"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td class="tb_title">블로그 주소</td>
			<td>
				http://
				<asp:TextBox ID="txtUserBlogUrl" runat="server" BorderStyle="Groove" Width="366px"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td class="tb_title">내용</td>
			<td>
				<asp:TextBox ID="txtContent" runat="server" Rows="5" Columns="80" TextMode="MultiLine" style="width:80%" BorderStyle="Groove"></asp:TextBox>
				
			</td>
		</tr>
		<tr>
			<td class="tb_title"><img src="/common/ConfirmBitmapHandler.ashx" alt="인증번호" /></td>
			<td>
				<asp:TextBox ID="txtConfirmBitmapHandler" runat="server"></asp:TextBox>
				<asp:ImageButton ID="btnRegister" runat="server" ImageUrl="/common/images/btn_regist.gif" OnClick="btnRegister_Click" ImageAlign="Bottom" />
			</td>
		</tr>
	</table>
	</div>
	</ContentTemplate>
</asp:UpdatePanel>
<br style='line-height:57px;' />