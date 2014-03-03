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

using Umc.Core;
using Umc.Core.WebAdmin;
using Umc.Core.Util;
using Umc.Core.Modules.Blog;
using Umc.Core.Modules.Blog.Model;

public partial class WebAdmin_01Blog_ProfileInfo : WebAdminCommonTemplate
{
	BlogBaseModel model;
	protected void Page_Load(object sender, EventArgs e)
	{
		bind();
	}

	protected void bind()
	{
		model	= BlogManager.GetInstance().BlogBaseModel;

		rblPublicName.SelectedValue			= model.ProfileInfoModel.PublicName.ToString();
		rblPublicGender.SelectedValue		= model.ProfileInfoModel.PublicGender.ToString();
		rblPublicAddress.SelectedValue		= model.ProfileInfoModel.PublicAddress.ToString();
		rblPublicGuestBoard.SelectedValue	= model.ProfileInfoModel.PublicGuestBoard.ToString();
	}

	protected void lnkRegister_Click(object sender, EventArgs e)
	{
		model.ProfileInfoModel.PublicName		= bool.Parse(rblPublicName.SelectedValue);
		model.ProfileInfoModel.PublicGender		= bool.Parse(rblPublicGender.SelectedValue);
		model.ProfileInfoModel.PublicAddress	= bool.Parse(rblPublicAddress.SelectedValue);
		model.ProfileInfoModel.PublicGuestBoard	= bool.Parse(rblPublicGuestBoard.SelectedValue);

		string path = Utility.GetAbsolutePath(UmcConfiguration.Core["BlogXmlPath"]);
		BlogManager.GetInstance().WriteBlogBaseInfo(path, model);

		Utility.JS_Alert(sender, MessageCode.MESSAGE_SAVED);
	}
}
