<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleWrite.ascx.cs" Inherits="WebAdmin_05Article_ArticleWrite" %>
<%@ Import Namespace="Umc.Core.Util" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<%
	if (categoryL.Count == 0)
	{
		Utility.JsCall(this, "alert('카테고리가 등록되지 않았습니다. 카테고리를 등록하세요'); go.history(-1);");
		return;
	}
	else
	{
%>

<iframe src="/Webadmin/05Article/templates/ArticleWrite.aspx<%=Request.Url.Query%>" width="100%" frameborder="0" width="100%"  height="300" scrolling="no" onload="resizeFrame(this)">
</iframe>
<%
	}
%>