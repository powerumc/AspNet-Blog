<%@ Control Language="C#" ClassName="snapProfile" Inherits="Umc.Core.Web.UmcContentsCommonPage" %>
<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
<%@ Import Namespace="Umc.Core" %>
<%@ Import Namespace="Umc.Core.Web" %>
<%@ Import Namespace="Umc.Core.Data" %>
<%@ Import Namespace="Umc.Core.Modules.Blog" %>
<%@ Import Namespace="Umc.Core.Modules.Blog.Model" %>
<%@ Import Namespace="Umc.Core.Modules.Snap" %>

<script runat="server">
	protected void Page_Load(object sender, EventArgs e)
	{
		bind();
	}

	private void bind()
	{
		BlogBaseModel model = BlogManager.GetInstance().BlogBaseModel;
		
		// 이미지는 160 x 130 으로 표시된다.
		imgMyPicture.ImageUrl		= model.BlogModel.Picture;
		lblNickName.Text			= model.BlogModel.NickName;
	}

	protected void lnkViewProfile_Click(object sender, EventArgs e)
	{
		((UmcBlogBasePage)Page).ContentViewControl = SnapConst.SNAP_TEMPLATE_PROFILE;
		((UmcBlogBasePage)Page).Update();
	}
</script>
			<ComponentArt:Snap id="snap_Profile" 
				  DockingContainers="LeftColumn,RightColumn" 
				  CurrentDockingContainer="LeftColumn" 
				  CurrentDockingIndex="0" 
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
					  <td style="width:16px;padding:3px;cursor:move;" onmousedown="snap_Profile.StartDragging(event);"><img src="/common/images/snap_icon.gif" alt="" width="16" height="16" /></td>
					  <td style="width:100%;padding:3px;font-size:11px;cursor:move;" onmousedown="snap_Profile.StartDragging(event);">프로필</td>
					  <td style="width:15px;padding:1px;"><img onclick="snap_Profile.ToggleExpand();" src="/common/images/toggle_expand.gif" alt="" width="15" height="14" style="cursor:pointer;" onmouseover="this.src='/common/images/toggle_expandHover.gif';" onmouseout="this.src='/common/images/toggle_expand.gif';" onmousedown="this.src='/common/images/toggle_expandActive.gif';" onmouseup="this.src='/common/images/toggle_expandHover.gif';" /></td>
					</tr>
				  </table>
				  </Header>
				  <CollapsedHeader>
				  <table class="SnapHeaderCollapsed" cellspacing="0" cellpadding="0" border="0">
					<tr>
					  <td style="width:16px;padding:3px;cursor:move;" onmousedown="snap_Profile.StartDragging(event);"><img src="/common/images/snap_icon.gif" alt="" width="16" height="16" /></td>
					  <td style="width:100%;padding:3px;font-size:11px;cursor:move;" onmousedown="snap_Profile.StartDragging(event);">프로필</td>
					  <td style="width:15px;padding:1px;"><img onclick="snap_Profile.ToggleExpand();" src="/common/images/collapsed_toggleExpand.gif" alt="" width="15" height="14" style="cursor:pointer;" onmouseover="this.src='/common/images/collapsed_toggleExpandHover.gif';" onmouseout="this.src='images/collapsed_toggleExpand.gif';" onmousedown="this.src='/common/images/collapsed_toggleExpandActive.gif';" onmouseup="this.src='images/collapsed_toggleExpandHover.gif';" /></td>
					</tr>
				  </table>
				  </CollapsedHeader>
				<Content>
					<table width="100%" border="0" cellspacing="0" cellpadding="8" class="SnapContent">
						<tr>
							<td>
								<asp:Image ID="imgMyPicture" runat="server" Width="160px" Height="130px" />
								<asp:Label ID="lblNickName" runat="server"></asp:Label>
								<br />
								<asp:UpdatePanel ID="panelProfile" runat="server">
									<ContentTemplate>
										<table style="width:100%">
											<tr>
												<td style="text-align:left;">
													<a href="javascript:setContent('<%=SnapModel.ID %>');" class="smalltext" style="font-family:돋움;font-size:11px;">프로필</a>
														<img src="/common/images/ico_bullet_red.gif" alt="" />
													</a>
												</td>
												<td style="text-align:right;">
													<a href="/WebAdmin/" class="smalltext" style="font-family:돋움;font-size:11px;">관리</a>
												</td>
											</tr>
										</table>
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