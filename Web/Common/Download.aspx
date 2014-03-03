<%@ Page Language="C#" Inherits="Umc.Core.Web.UmcBlogBasePage" %>
<%@ Import Namespace="Umc.Core.Modules.Article" %>
<%@ Import Namespace="Umc.Core.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
	private void Page_Load(object sender, EventArgs e)
	{
		int fileNo	= GetParamInt( ArticleConst.PARAM_ATTACHFILE_NO, -1 );
		
		if( fileNo == -1 )
		{
			downError();
			return;
		}

		string path = RepositoryManager.GetInstance().RepositoryDirectory + "\\" + ArticleManager.GetInstance().GetAttachFileByFileNo(fileNo).FilePath.Replace("/","\\");

		Response.ContentType = "application/unknown";
		Response.Clear();
		Response.AddHeader("Content-Disposition", "attachment;filename=" + System.IO.Path.GetFileName(path));
		Response.WriteFile(path);
		Response.Flush();
		Response.End();
	}

	private void downError()
	{
		
	}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>제목 없음</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
