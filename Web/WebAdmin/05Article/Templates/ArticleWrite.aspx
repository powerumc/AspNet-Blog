<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArticleWrite.aspx.cs" Inherits="WebAdmin_05Article_ArticleWrite" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="Umc.Core.Util" %>
<%@ Import Namespace="Umc.Core.Modules.Article"%>
<%@ Import Namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>제목 없음</title>
	<link href="/Common/Css/global.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript">
		var lastFileCount	= 1;
		function add()
		{
			var len		= tblAttach.rows.length;
			
			var tr1		= tblAttach.insertRow( len );
			
			var td1		= tr1.insertCell(0);
			var fileID	= "file"+len.toString();
			td1.innerHTML = "<input type='file' id='"+ fileID +"' name='"+ fileID +"' style='width: 400px' /> <input type='image' src='/common/images/btn_xdelete.gif'  onclick='return del()'  />";
			lastFileCount++;		
			
			return false;
		}
		function del()
		{
			var currentElement		= window.event.srcElement;
			var currentTable		= currentElement.parentNode.parentNode.parentNode;
			var currentRowIndex		= currentElement.parentNode.parentNode.rowIndex;
			
			if( currentRowIndex > 0 )
				currentTable.deleteRow( currentRowIndex );
			else
				alert('처음 항목을 삭제할 수 없습니다');
				
			return false;
		}
		function beforeSubmit()
		{
			document.getElementById("fileCount").value = lastFileCount;
		}
		
		function tagSelect( tag )
		{
			var txtTag			= document.getElementById("<%= txtTag.ClientID %>");
			
			if ( txtTag.value.substring( txtTag.value.length - 1, txtTag.value.length ) == ',' || txtTag.value.length == 0)
				txtTag.value		+= tag;
			else
				txtTag.value		+= ','+tag;
		}
	</script>
    <div>
		<asp:ScriptManager ID="ScriptManager1" runat="server">
		</asp:ScriptManager>
		<input type="hidden" id="fileCount" name="fileCount" />
		<asp:UpdatePanel ID="panelCategory" runat="server">
			<ContentTemplate>
				<asp:LinkButton ID="lnkMinusHeight" runat="server" OnClick="lnkMinusHeight_Click">(-) 낮게</asp:LinkButton>&nbsp;&nbsp;
				<asp:LinkButton ID="lnkPlusHeight" runat="server" OnClick="lnkPlusHeight_Click">(+) 높게</asp:LinkButton>
				<br />
				<asp:DropDownList ID="ddlCategoryL" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoryL_SelectedIndexChanged"></asp:DropDownList>
				<asp:DropDownList ID="ddlCategoryM" runat="server">
				</asp:DropDownList>
			</ContentTemplate>
		</asp:UpdatePanel>
		제목 : <asp:TextBox ID="txtTitle" runat="server" Width="500"></asp:TextBox><br />
		트랙백 : <asp:TextBox ID="txtTrackbackUrl" runat="server" Width="350"></asp:TextBox>
		<asp:UpdatePanel ID="panelEditor" runat="server" UpdateMode="Conditional">
			<ContentTemplate>
				<FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server">
				</FCKeditorV2:FCKeditor>
			</ContentTemplate>
		</asp:UpdatePanel>
		<!-- 수정글일때 첨부파일 리스트 -->
		<asp:UpdatePanel ID="pnAttach" runat="server">
			<ContentTemplate>
				<asp:DataList ID="dlAttachFile" runat="server" OnItemCommand="dlAttachFile_ItemCommand">
					<ItemTemplate>
						<tr>
							<td>
								<a href='/common/download.aspx?<%= ArticleConst.PARAM_ATTACHFILE_NO %>=<%# Eval("FileNo") %>' target="_self">
										<%# Path.GetFileName((string)Eval("FilePath")) %>
									</a>
							</td>
							<td>
								<asp:LinkButton ID="lnkRemoveAttachFile" runat="server" OnClientClick="return confirm('정말로 삭제하시겠습니까?')" CommandName="removeAttach" CommandArgument='<%# Eval("FileNo") %>'>
									<img src="/common/images/btn_xdelete.gif" alt="삭제" />
								</asp:LinkButton>
							</td>
						</tr>
					</ItemTemplate>
				</asp:DataList>
			</ContentTemplate>
		</asp:UpdatePanel>
		<table id="tblAttach">
			<tr>
				<td>
					<input type="file" id="file1" name="file1" style="width: 400px" runat="server" />
					<input type="image" src="/common/images/btn_xdelete.gif" onclick="return del()" />
				</td>
				<td valign="bottom">
					<input type="image" src="/common/images/btn_xappend.gif" onclick="return add();" />
				</td>
			</tr>
		</table>
		<table style="width:100%">
			<tr>
				<td style="width:100px">태그</td>
				<td style="width:500px">
					<asp:TextBox ID="txtTag" runat="server" BorderStyle="Groove" Width="300px"></asp:TextBox>  콤마(,)로 구분
					&nbsp;&nbsp;&nbsp;
					<a href="javascript:openTagSelector();">태그 선택</a>	
				</td>
			</tr>
			<tr>
				<td>공개설정</td>
				<td >
					<asp:RadioButtonList ID="rblPublicFlag" runat="server" RepeatDirection="Horizontal">
						<asp:ListItem Value="True" Selected>공개</asp:ListItem>
						<asp:ListItem Value="False">비공개</asp:ListItem>
					</asp:RadioButtonList>
				</td>
			</tr>
			<tr>
				<td>RSS 공개</td>
				<td>
					<asp:RadioButtonList ID="rblPublicRss" runat="server" RepeatDirection="Horizontal">
						<asp:ListItem Value="True" Selected>공개</asp:ListItem>
						<asp:ListItem Value="False">비공개</asp:ListItem>
					</asp:RadioButtonList>
				</td>
			</tr>
			<tr>
				<td>댓글 허용</td>
				<td>
					<asp:RadioButtonList ID="rblAllowComment" runat="server" RepeatDirection="Horizontal">
						<asp:ListItem Value="True" Selected>허용</asp:ListItem>
						<asp:ListItem Value="False">허용하지 않음</asp:ListItem>
					</asp:RadioButtonList>
				</td>
			</tr>
			<tr>
				<td>트랙백 허용</td>
				<td>
					<asp:RadioButtonList ID="rblAllowTrackback" runat="server" RepeatDirection="Horizontal">
						<asp:ListItem Value="True" Selected>허용</asp:ListItem>
						<asp:ListItem Value="False">허용하지 않음</asp:ListItem>
					</asp:RadioButtonList>
				</td>
			</tr>
		</table>
		<!-- 등록 버튼 -->
		<table style="width:100%">
			<tr>
				<td align="right">
					<asp:LinkButton ID="lnkRegister" runat="server" OnClick="lnkRegister_Click">
						<img src="/common/images/btn_regist.gif" alt="등록" onclick="beforeSubmit()" />
					</asp:LinkButton>
				</td>
			</tr>
		</table>
    </div>
    </form>
</body>
</html>
