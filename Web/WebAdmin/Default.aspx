<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="WebAdmin_Default" %>

<%@ Register Src="CommonPlaceHolder.ascx" TagName="CommonPlaceHolder" TagPrefix="uc2" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>제목 없음</title>
</head>
<body>
    <form id="form1" runat="server">
		<asp:ScriptManager ID="ScriptManager1" runat="server">
		</asp:ScriptManager>
    <div>
		<table border="0" cellpadding="0" cellspacing="0" style="width: 1000px;">
			<tr>
				<td colspan="2" style="height: 100px">
				</td>
			</tr>
			<tr>
				<!-- 트리메뉴 -->
				<td style="width: 200px" valign="top">
					<asp:UpdatePanel ID="panelMenu" runat="server" UpdateMode="Conditional">
						<ContentTemplate>
							<asp:TreeView ID="treeMenu" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" OnSelectedNodeChanged="treeMenu_SelectedNodeChanged">
								<ParentNodeStyle Font-Bold="False" />
								<HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
								<SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
									VerticalPadding="0px" />
								<NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
									NodeSpacing="0px" VerticalPadding="2px" />
							</asp:TreeView>
						</ContentTemplate>
					</asp:UpdatePanel>
				</td>
				<!-- 트리메뉴 끝 -->
				<!-- MainPlace -->
				<td valign="top" id="tdTemp" runat="server">
					<uc2:CommonPlaceHolder ID="CommonMainPlace" runat="server" />
				</td>
				<!-- MainPlace 끝 -->
			</tr>
		</table>
    </div>
    <span id="toolTipBox" style="position:absolute;"></span>
    </form>
</body>
</html>
