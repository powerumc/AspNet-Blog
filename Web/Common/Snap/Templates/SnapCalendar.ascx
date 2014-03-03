<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SnapCalendar.ascx.cs" Inherits="Common_Snap_Templates_SnapCalendar" %>
<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
			<ComponentArt:Snap id="snap_Calendar" 
				  DockingContainers="LeftColumn,RightColumn" 
				  CurrentDockingContainer="LeftColumn" 
				  CurrentDockingIndex="2" 
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
					  <td style="width:16px;padding:3px;cursor:move;" onmousedown="snap_Calendar.StartDragging(event);"><img src="/common/images/snap_icon.gif" alt="" width="16" height="16" /></td>
					  <td style="width:100%;padding:3px;font-size:11px;cursor:move;" onmousedown="snap_Calendar.StartDragging(event);">달력</td>
					  <td style="width:15px;padding:1px;"><img onclick="snap_Calendar.ToggleExpand();" src="/common/images/toggle_expand.gif" alt="" width="15" height="14" style="cursor:pointer;" onmouseover="this.src='/common/images/toggle_expandHover.gif';" onmouseout="this.src='/common/images/toggle_expand.gif';" onmousedown="this.src='/common/images/toggle_expandActive.gif';" onmouseup="this.src='/common/images/toggle_expandHover.gif';" /></td>
					</tr>
				  </table>
				  </Header>
				  <CollapsedHeader>
				  <table class="SnapHeaderCollapsed" cellspacing="0" cellpadding="0" border="0">
					<tr>
					  <td style="width:16px;padding:3px;cursor:move;" onmousedown="snap_Calendar.StartDragging(event);"><img src="/common/images/snap_icon.gif" alt="" width="16" height="16" /></td>
					  <td style="width:100%;padding:3px;font-size:11px;cursor:move;" onmousedown="snap_Calendar.StartDragging(event);">달력</td>
					  <td style="width:15px;padding:1px;"><img onclick="snap_Calendar.ToggleExpand();" src="/common/images/collapsed_toggleExpand.gif" alt="" width="15" height="14" style="cursor:pointer;" onmouseover="this.src='/common/images/collapsed_toggleExpandHover.gif';" onmouseout="this.src='images/collapsed_toggleExpand.gif';" onmousedown="this.src='/common/images/collapsed_toggleExpandActive.gif';" onmouseup="this.src='images/collapsed_toggleExpandHover.gif';" /></td>
					</tr>
				  </table>
				  </CollapsedHeader>
				<Content>
					<table width="100%" border="0" cellspacing="0" cellpadding="0" class="SnapContent">
						<tr>
							<td align="center">
								<asp:UpdatePanel ID="panelCalendar" runat="server">
									<ContentTemplate>
										<asp:Calendar ID="cldCalendar" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="120px" NextPrevFormat="FullMonth" Width="160px" OnSelectionChanged="cldCalendar_OnSelectionChanged" OnDayRender="cldCalendar_DayRender" OnVisibleMonthChanged="cldCalendar_VisibleMonthChanged" >
											<SelectedDayStyle BackColor="#333399" ForeColor="White" />
											<TodayDayStyle BackColor="#CCCCCC" />
											<OtherMonthDayStyle ForeColor="#999999" />
											<NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
											<DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
											<TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
										</asp:Calendar>
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