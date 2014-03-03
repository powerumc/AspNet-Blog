<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"  %>
<%@ Import Namespace="Umc.Core.Modules.Blog" %>
<%@ Import Namespace="Umc.Core.WebAdmin.Sitemap" %>
<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title runat="server"></title>
    <link rel="alternate" type="application/rss+xml" title="블로그 글 목록" href="http://umc.pe.kr/common/rss.aspx" />
    <link href="/common/js/lightbox/lightbox.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="/common/js/lightbox/lightbox.js"></script>
	<script type="text/javascript">
		//<![CDATA[    
		function ToggleSnapMinimize(SnapObject, MenuItemIndex)
		{
		  SnapObject.toggleMinimize();
		  ToggleItemCheckedState(MenuItemIndex); 
		}    
	      
		function ToggleItemCheckedState(MenuItemIndex)
		{
		  var item = Menu1.get_items().getItem(0).get_items().getItem(MenuItemIndex); 
			if (item.getProperty('Look-LeftIconUrl') == 'check.gif')
			{
				item.setProperty('Look-LeftIconUrl','clear.gif');
			}
			else
			{
				item.setProperty('Look-LeftIconUrl','check.gif');
			}
			item.get_parentMenu().render();
		}
		
		function mainUpdate()
		{
			document.getElementById("spanLogin").style.display ='none';
			document.getElementById("<%= lnkMainUpdate.ClientID %>").click();
		}
		
		//]]>
    </script>
    <script src="http://www.google-analytics.com/urchin.js" type="text/javascript">
	</script>
	<script type="text/javascript">
		_uacct = "UA-2231579-1";
		urchinTracker();
	</script>
</head>
<body>
    <form id="form1" runat="server">
		<asp:ScriptManager ID="ScriptManager1" runat="server">
		</asp:ScriptManager>
		<div style="background-image:url(/common/images/background.jpg);background-attachment:fixed;">
			<!-- 메인 페이지 시작 -->
			<table style="width:1100px;">
				<tr style="height:100px;">
					<td colspan="3">
						<asp:HyperLink ID="hpBlogTitle" runat="server" CssClass="blogtitle"></asp:HyperLink>
					</td>
				</tr>
				<tr style="height:20px;">
					<!-- 최소화 메뉴 -->
					<td style="width:180px;">&nbsp;</td>
					<td style="width:100px;text-align:left;">
						<asp:UpdatePanel ID="panelSnapSave" runat="server">
							<ContentTemplate>
								<asp:LinkButton ID="lnkSnapSave" runat="server" OnClick="lnkSnapSave_Click">내설정 저장하기</asp:LinkButton>
							</ContentTemplate>
						</asp:UpdatePanel>
						
					</td>
					<td style="text-align:right;width:820px;">
						<asp:UpdatePanel ID="panelWelcome" runat="server" RenderMode="Inline">
							<ContentTemplate>
								<% if( IsLogin ) { %>
									<%= CurrentUserInfo.Name %> 님 안녕하세요.&nbsp;&nbsp;&nbsp;&nbsp;
								<% } %>
							</ContentTemplate>
						</asp:UpdatePanel>
						<span id="spanLogin" style="display:<%= IsLogin ? "none" : "inline" %>">
							<a href="<%= SitemapManager.GetInstance().GetSitemapByID("ADMIN1").GetInitParam("page.user.login") %>" title="로그인" rel="gb_page_center[400,150]">로그인</a>&nbsp;&nbsp;&nbsp;
						</span>
						<asp:UpdatePanel ID="panelTopMenu" runat="server" RenderMode="Inline">
							<ContentTemplate>
								<asp:LinkButton ID="lnkMainUpdate" runat="server"></asp:LinkButton>
								<% if( IsLogin ) { %>
								<asp:LinkButton ID="lnkLogout" runat="server" OnClick="lnkLogout_Click">로그아웃</asp:LinkButton>&nbsp;&nbsp;&nbsp;
								<% } %>
								<% if( !IsLogin ) { %>				
								<asp:LinkButton ID="lnkUserJoin" runat="server" OnClientClick="setContent('UserJoin'); return false;">회원가입</asp:LinkButton>&nbsp;&nbsp;&nbsp;
								
								&nbsp;&nbsp;&nbsp;
								<% } %>
								<asp:LinkButton ID="lnkGuestBoard" runat="server" OnClientClick="setContent('GuestBoard'); return false;">방명록</asp:LinkButton>
							</ContentTemplate>
						</asp:UpdatePanel>
					</td>
				</tr>
			</table>
			<table style="width:1100px;">
				<tr>
					<td id="LeftColumn" valign="top"></td>
					<td id="" valign="top" style="background-color:White;padding:0 0 0 0;">
							<table class="SnapHeader" cellspacing="0" cellpadding="0" border="0">
								<tr>
								  <td style="width:16px;padding:3px;"><img src="/common/images/snap_icon.gif" alt="" width="16" height="16" /></td>
								  <td style="width:100%;padding:3px;font-size:11px;" />Contents</td>
								  <td style="width:15px;padding:1px;"></td>
								  <td style="width:15px;padding:1px;padding-right:3px;"></td>
								</tr>
							</table>
							<br />
							<iframe id="iframeContent" src="<%=CurrentIframeControl %>" frameborder="0" width="100%"  height="300" scrolling="no" onload="resizeFrame(this)"></iframe>			  
							<asp:UpdatePanel ID="panelContent" runat="server">
								<ContentTemplate>
									<asp:PlaceHolder ID="placeContent" runat="server"></asp:PlaceHolder>	
								</ContentTemplate>
							</asp:UpdatePanel>
					</td>
					<td id="RightColumn" valign="top"></td>
				</tr>
			</table>
			<!-- 메인 페이지 끝 -->
			<asp:PlaceHolder ID="phSnaps" runat="server"></asp:PlaceHolder>
			<asp:PlaceHolder ID="ph_Profile" runat="server"></asp:PlaceHolder>
			<asp:PlaceHolder ID="ph_Category" runat="server"></asp:PlaceHolder>
			<asp:PlaceHolder ID="ph_RecentComment" runat="server"></asp:PlaceHolder>
			<asp:PlaceHolder ID="ph_RecentArticle" runat="server"></asp:PlaceHolder>
			<asp:PlaceHolder ID="ph_Calendar" runat="server"></asp:PlaceHolder>
			<asp:PlaceHolder ID="ph_BlogInfo" runat="server"></asp:PlaceHolder>
					
			<!-- Content Snap -->
		</div>
    </form>
</body>
</html>
<script type="text/javascript">
			var endIndex = location.href.indexOf("#");
		
			if( endIndex > 0 )
			{
				var len		= location.href.length;
				var goNo	= location.href.substring(endIndex+1, len);
			
				var f		= document.getElementById("iframeContent");
				f.src		= f.src + "#" + goNo;
			}
</script>
<script type="text/javascript" src="http://sitelog.nesolution.com/sitelog.js"></script>