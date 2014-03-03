<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommonPlaceHolder.ascx.cs" Inherits="WebAdmin_CommonPlaceHolder" %>
<asp:UpdatePanel ID="panelCommonMainPlace" runat="server" >
	<ContentTemplate>
		<asp:Label ID="lblSitemapPath" runat="server"></asp:Label>&nbsp;&nbsp;
		Module ID : <asp:Label ID="lblModuleID" runat="server"></asp:Label>
		<br />
		<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
	</ContentTemplate>
</asp:UpdatePanel>