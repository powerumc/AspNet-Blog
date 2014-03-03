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

using Umc.Core.Modules.Blog;
using Umc.Core.Modules.Blog.Model;
using Umc.Core.Web;
using Umc.Core.Util;

public partial class Common_Snap_Contents_ProfileContent : UmcContentsCommonPage
{
	BlogBaseModel model;
	protected void Page_Load(object sender, EventArgs e)
	{
		bind();
	}

	private void bind()
	{
		model					= BlogManager.GetInstance().BlogBaseModel;
		imgPicture.ImageUrl		= model.BlogModel.Picture;
		lblName.Text			= model.BlogModel.Name;
		lblNickName.Text		= model.BlogModel.NickName;
		lblIntroduction.Text	= model.BlogModel.Introduction.Replace("\r\n","<br/>");
		lblAddress.Text			= model.BlogModel.Address;
		lblHobby.Text			= model.BlogModel.Hobby;
	}
}
