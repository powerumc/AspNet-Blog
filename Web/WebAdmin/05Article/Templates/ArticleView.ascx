<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleView.ascx.cs" Inherits="WebAdmin_05Article_Templates_ArticleView" %>
<hr />
<div style="text-align:right;">
<asp:LinkButton ID="lnkRemoveArticle" runat="server" OnClick="lnkRemoveArticle_Click">
	<img src="/common/images/btn_delete.gif" alt="삭제" />
</asp:LinkButton>
<asp:HyperLink id="hpWrite" runat="server">
	<img src="/common/images/btn_modify.gif" alt="수정" />
</asp:HyperLink>
</div>