<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleListContent.ascx.cs" Inherits="Common_Snap_Contents_ArticleListContent" %>
<%@ Register Assembly="Umc.Core" Namespace="Umc.Core.Web.Controls" TagPrefix="cc1" %>
<asp:PlaceHolder ID="phArticleList" runat="server"></asp:PlaceHolder>
<div class="paging">
	<cc1:UmcPager ID="UmcPager1" runat="server" OnPageIndexChanged="UmcPager1_PageIndexChanged" />
</div>