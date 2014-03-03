<%@ Control Language="C#" AutoEventWireup="true" CodeFile="snapContent.ascx.cs" Inherits="Common_Snap_Templates_SnapContent" %>
<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
<%@ Import Namespace="Umc.Core.Modules.Snap" %>
<div>
			<ComponentArt:Snap ID="snap_Content" 
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
					  <td style="width:16px;padding:3px;cursor:move;" onmousedown="snap_Content.StartDragging(event);"><img src="/common/images/snap_icon.gif" alt="" width="16" height="16" /></td>
					  <td style="width:100%;padding:3px;font-size:11px;cursor:move;" onmousedown="snap_Content.StartDragging(event);">Contents</td>
					  <td style="width:15px;padding:1px;"><img onclick="snap_Content.ToggleExpand();" src="/common/images/toggle_expand.gif" alt="" width="15" height="14" style="cursor:pointer;" onmouseover="this.src='/common/images/toggle_expandHover.gif';" onmouseout="this.src='/common/images/toggle_expand.gif';" onmousedown="this.src='/common/images/toggle_expandActive.gif';" onmouseup="this.src='/common/images/toggle_expandHover.gif';" /></td>
					  <td style="width:15px;padding:1px;padding-right:3px;"><img onclick="snap_Content.ToggleMinimize();ToggleItemCheckedState(0);" src="/common/images/toggle_minimize.gif" alt="" width="15" height="14" style="cursor:pointer;" onmouseover="this.src='/common/images/toggle_minimizeHover.gif';" onmouseout="this.src='/common/images/toggle_minimize.gif';" onmousedown="this.src='/common/images/toggle_minimizeActive.gif';" onmouseup="this.src='/common/images/toggle_minimizeHover.gif';" /></td>
					</tr>
				  </table>
				  </Header>
				  <CollapsedHeader>
				  <table class="SnapHeaderCollapsed" cellspacing="0" cellpadding="0" border="0">
					<tr>
					  <td style="width:16px;padding:3px;cursor:move;" onmousedown="snap_Content.StartDragging(event);"><img src="/common/images/snap_icon.gif" alt="" width="16" height="16" /></td>
					  <td style="width:100%;padding:3px;font-size:11px;cursor:move;" onmousedown="snap_Content.StartDragging(event);">Contents</td>
					  <td style="width:15px;padding:1px;"><img onclick="snap_Content.ToggleExpand();" src="/common/images/collapsed_toggleExpand.gif" alt="" width="15" height="14" style="cursor:pointer;" onmouseover="this.src='/common/images/collapsed_toggleExpandHover.gif';" onmouseout="this.src='images/collapsed_toggleExpand.gif';" onmousedown="this.src='/common/images/collapsed_toggleExpandActive.gif';" onmouseup="this.src='images/collapsed_toggleExpandHover.gif';" /></td>
					  <td style="width:15px;padding:1px;padding-right:3px;"><img onclick="snap_Content.ToggleMinimize();ToggleItemCheckedState(0);" src="/common/images/collapsed_toggleMinimize.gif" alt="" width="15" height="14" style="cursor:pointer;" onmouseover="this.src='/common/images/collapsed_toggleMinimizeHover.gif';" onmouseout="this.src='images/collapsed_toggleMinimize.gif';" onmousedown="this.src='/common/images/collapsed_toggleMinimizeActive.gif';" onmouseup="this.src='/common/images/collapsed_toggleMinimizeHover.gif';" /></td>
					</tr>
				  </table>
				  </CollapsedHeader>
				<Content>
					<table width="100%" border="0" cellspacing="0" cellpadding="8" class="snap_Content">
						<tr>
							<td>
								
								Content End						
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
			
</div>		