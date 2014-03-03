<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BreakerControl.ascx.cs" Inherits="WebAdmin_09Breaker_Controls_BreakerControl" %>
<br />
차단 리스트에 추가 되면 다음 세션부터 적용됩니다.<br />
<a href="<%= CurrentSitemapInfo.GetInitParam("page.breaker") %>">차단 페이지 미리보기</a>
<p />
<asp:PlaceHolder ID="phTemplate" runat="server"></asp:PlaceHolder>