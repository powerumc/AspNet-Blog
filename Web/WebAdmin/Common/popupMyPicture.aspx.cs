using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

using Umc.Core;
using Umc.Core.WebAdmin;
using Umc.Core.Data;
using Umc.Core.Modules.Blog;
using Umc.Core.Util;

public partial class WebAdmin_Common_popupMyPicture : WebAdminTemplate
{
	string moduleID;
	protected void Page_Load(object sender, EventArgs e)
	{
		moduleID	= GetParamString("ModuleID");

		if (moduleID == null)
		{
			Response.Write("<script>self.close();</script>");
		}
	}
	protected void lnkRegister_Click(object sender, EventArgs e)
	{
		if (fileMyPicture.FileName != string.Empty)
		{
			FileInfo myPicture =
				RepositoryManager.GetInstance().SaveAs( moduleID, fileMyPicture.PostedFile );
			BlogManager.GetInstance().BlogBaseModel.BlogModel.Picture = string.Format("{0}/{1}/{2}",
				UmcConfiguration.Core["repository.dir"],
				moduleID,
				myPicture.Name
				);
		}

		Utility.JS_SelfClose(sender);
	}
}
