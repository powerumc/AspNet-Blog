<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TagSelector.aspx.cs" Inherits="Common_Popup_TagSelector" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>태그 선택</title>
    <script type="text/javascript">
		var select =		function(obj)
		{
			opener.tagSelect( obj.innerText );
			self.close();
		}
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:Repeater ID="rptTagList" runat="server">
		<ItemTemplate>
			<a href="#" onclick="select( this );" class="smalltagcloud"><%# Eval("TagName") %></a>&nbsp;&nbsp;&nbsp;
		</ItemTemplate>
</asp:Repeater>
    </div>
    </form>
</body>
</html>
