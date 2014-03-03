<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SnapBlogInfo.ascx.cs" Inherits="Common_Snap_Templates_SnapBlogInfo" %>
<%@ Import Namespace="Umc.Core.Modules.Blog" %>
<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
<script type="text/javascript">
	function nonPublicRss()
	{
		alert('RSS 비공개 입니다');
	}
</script>
			<ComponentArt:Snap id="snap_BlogInfo" 
				  DockingContainers="LeftColumn,RightColumn" 
				  CurrentDockingContainer="RightColumn" 
				  CurrentDockingIndex="3" 
				  CollapseDuration="300"
				  ExpandDuration="300"
				  DraggingStyle="GhostCopy"
				  DockingStyle="TransparentRectangle" 
						MinimizeDirectionElement="Menu1_0" 
						MinimizeDuration="250"
						MinimizeSlide="Linear"
				  MustBeDocked="True"
				  IsCollapsed="false"
				  runat="server">
				<Header>
				  <table class="SnapHeader" cellspacing="0" cellpadding="0" border="0">
					<tr>
					  <td style="width:16px;padding:3px;cursor:move;" onmousedown="snap_BlogInfo.StartDragging(event);"><img src="/common/images/snap_icon.gif" alt="" width="16" height="16" /></td>
					  <td style="width:100%;padding:3px;font-size:11px;cursor:move;" onmousedown="snap_BlogInfo.StartDragging(event);">방문자 정보</td>
					  <td style="width:15px;padding:1px;"><img onclick="snap_BlogInfo.ToggleExpand();" src="/common/images/toggle_expand.gif" alt="" width="15" height="14" style="cursor:pointer;" onmouseover="this.src='/common/images/toggle_expandHover.gif';" onmouseout="this.src='/common/images/toggle_expand.gif';" onmousedown="this.src='/common/images/toggle_expandActive.gif';" onmouseup="this.src='/common/images/toggle_expandHover.gif';" /></td>
					</tr>
				  </table>
				  </Header>
				  <CollapsedHeader>
				  <table class="SnapHeaderCollapsed" cellspacing="0" cellpadding="0" border="0">
					<tr>
					  <td style="width:16px;padding:3px;cursor:move;" onmousedown="snap_BlogInfo.StartDragging(event);"><img src="/common/images/snap_icon.gif" alt="" width="16" height="16" /></td>
					  <td style="width:100%;padding:3px;font-size:11px;cursor:move;" onmousedown="snap_BlogInfo.StartDragging(event);">방문자 정보</td>
					  <td style="width:15px;padding:1px;"><img onclick="snap_BlogInfo.ToggleExpand();" src="/common/images/collapsed_toggleExpand.gif" alt="" width="15" height="14" style="cursor:pointer;" onmouseover="this.src='/common/images/collapsed_toggleExpandHover.gif';" onmouseout="this.src='images/collapsed_toggleExpand.gif';" onmousedown="this.src='/common/images/collapsed_toggleExpandActive.gif';" onmouseup="this.src='images/collapsed_toggleExpandHover.gif';" /></td>
					 
					</tr>
				  </table>
				  </CollapsedHeader>
				<Content>
					<table width="100%" border="0" cellspacing="0" cellpadding="0" class="SnapContent">
						<tr>
							<td align="center">
								<asp:UpdatePanel ID="panelBlogInfo" runat="server">
									<ContentTemplate>
										<div>
										<span class="smalltext" style="font-family:돋움;font-size:11px;">총 방문자 : <%= totalCount %></span><br />
										<span class="smalltext" style="font-family:돋움;font-size:11px;">오늘 방문자 : <%= todayCount %></span><br />
										<span class="smalltext" style="font-family:돋움;font-size:11px;">주간 방문자 : <%= weekCount %></span><br />
										<span class="smalltext" style="font-family:돋움;font-size:11px;">이달 방문자 : <%= monthCount %></span>
										</div>
										<div style="width:90%;height:1px;" class="tb_line"></div>
										<div>
											<%
												string script;
												if( BlogManager.GetInstance().BlogBaseModel.PrivacyModel.PublicRSS )
													script	= "/common/rss.aspx";
												else
													script	= "javascript:nonPublicRss();";			
											%>
											<a href="<%= script %>">
												<img src="/common/images/rss.gif" alt="RSS 2.0" width="10" height="10" /> RSS 2.0
											</a>
										</div>
									</ContentTemplate>
								</asp:UpdatePanel>
							</td>
						</tr>				
					</table>
				</Content>
				<Footer>
				<table cellspacing="0" cellpadding="0" border="0">
				  <tr>
					<td><img src="/common/images/clear.gif" width="15" height="15" alt=""/></td>
				  </tr>
				</table>
				</Footer>
			</ComponentArt:Snap>