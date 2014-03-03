<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditCategory.ascx.cs" Inherits="WebAdmin_04Menu_EditCategory" %>
<%@ Import Namespace="System.Data" %>
<br />
<table style="width:100%" cellpadding="5" cellspacing="5">
	<tr>
		<!-- 미리보기 트리 -->
		<td style="width:200px;" valign="top">
			<img src="/webadmin/04menu/images/preview.gif" alt="미리보기" /><br />
			<asp:TreeView ID="treePreviewMenu" runat="server">
			</asp:TreeView>
		</td>
		<!-- 카테고리 편집 -->
		<td valign="top" style="width:300px;">
			<asp:ImageButton ID="btnNewCategory" runat="server" ImageUrl="/Webadmin/04menu/images/btn_newcategory.gif" OnClick="btnNewCategory_Click" />
			<asp:ImageButton ID="btnLine" runat="server" ImageUrl="/webadmin/04menu/images/btn_childCategory.gif" OnClick="btnLine_Click" />
			<br />
			<asp:ListBox ID="lbCategory" runat="server" Height="250px" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="lbCategory_SelectedIndexChanged"></asp:ListBox>
			<br />
			<asp:ImageButton ID="btnUp" runat="server" ImageUrl="/webadmin/04menu/images/btn_up.gif" OnClick="btnUp_Click" />
			<asp:ImageButton ID="btnDown" runat="server" ImageUrl="/webadmin/04menu/images/btn_down.gif" OnClick="btnDown_Click" />
			<asp:ImageButton ID="btnRemove" runat="server" ImageUrl="/webadmin/04menu/images/btn_remove.gif" OnClick="btnRemove_Click" />
			<br />
			<table style="width:300px;">
				<tr>
					<td>
						카테고리명</td>
					<td>
						<asp:TextBox ID="txtCategoryTitle" runat="server" BorderStyle="Groove" Width="150px"></asp:TextBox>
						<br />				
						<asp:DropDownList ID="ddlCategory" runat="server" Width="100px">
							<asp:ListItem Text="Root" Value="Root"></asp:ListItem>
						</asp:DropDownList>
						<asp:ImageButton ID="btnCategoryRegist" runat="server" ImageUrl="/common/images/btn_regist.gif"  style="vertical-align:bottom;" OnClick="btnCategoryRegist_Click"/>
					</td>
				</tr>
				<tr>
					<td>
						주제분류</td>
					<td>
						<asp:DropDownList ID="ddlCategoryL" runat="server" OnSelectedIndexChanged="ddlCategoryL_SelectedIndexChanged" AutoPostBack="True" Width="100px">
						</asp:DropDownList>
						<asp:DropDownList ID="ddlCategoryM" runat="server" Width="100px">
						</asp:DropDownList>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>