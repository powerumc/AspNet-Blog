<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SnapContent.aspx.cs" Inherits="Common_Snap_Templates_SnapContent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>제목 없음</title>
    <link href="/Common/Css/Snap.css" rel="stylesheet" type="text/css" />
	<link href="/Common/Css/baseStyle.css" rel="stylesheet" type="text/css" />
	<link href="/Common/Css/global.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="/Common/JS/Blog.js"></script>
	<script type="text/javascript" src="/Common/Js/greybox/AJS.js"></script>
	<script type="text/javascript" src="/Common/Js/greybox/AJS_fx.js"></script>
	<script type="text/javascript" src="/Common/Js/greybox/gb_scripts.js"></script>
	<link href="/Common/Js/greybox/gb_styles.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript">
		function goComment(commentNo)
		{
			var endIndex	= location.href.indexOf("#");
			if( endIndex == -1 ) endIndex = location.href.length;
			var url	= location.href.substring(0, endIndex);
			location.href = url + "#" + commentNo.toString();
		}

		function openTrackback( articleNo )
		{
			var divTrackbackList	= document.getElementById( "divTrackback_"+articleNo );
			
			if( divTrackbackList.style.display == "block" )
				divTrackbackList.style.display = "none";
			else
				divTrackbackList.style.display = "block";
		}
	</script>
</head>

<body>
    <form id="form1" runat="server">
    <div style="overflow-x:auto;padding:0px 10px 0px 10px;">
		<asp:ScriptManager ID="ScriptManager1" runat="server">
		</asp:ScriptManager>
		<asp:PlaceHolder ID="placeholder1" runat="server"></asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
