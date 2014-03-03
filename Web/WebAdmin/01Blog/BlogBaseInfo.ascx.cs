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

using Umc.Core.WebAdmin;
using Umc.Core.Modules.Blog;
using Umc.Core.Modules.Blog.Model;
using Umc.Core.Util;
using Umc.Core;
using Umc.Core.Data;

public partial class WebAdmin_01Blog_BlogBaseInfo : WebAdminCommonTemplate
{
	private BlogBaseModel model		= null;

	protected void Page_Load(object sender, EventArgs e)
	{
		bind();
	}

	private void bind()
	{
		model					= BlogManager.GetInstance().BlogBaseModel;
		txtTitle.Text			= model.BlogModel.Title;
		txtUrl.Text				= model.BlogModel.Url;
		txtEmail.Text			= model.BlogModel.EMail;

		txtName.Text			= model.BlogModel.Name;
		txtNickName.Text		= model.BlogModel.NickName;
		txtIntroduction.Text	= model.BlogModel.Introduction;
		ddlAddress.SelectedValue= model.BlogModel.Address;
		txtHobby.Text			= model.BlogModel.Hobby;
		ddlGender.SelectedValue	= ((BlogConst.Gender)model.BlogModel.Gender).ToString();

		rblAlram.SelectedValue		= model.BlogModel.Alarm.ToString();
		rblAutoClip.SelectedValue	= model.BlogModel.AutoClip.ToString();
		rblPostCount.SelectedValue	= model.BlogModel.PostCount.ToString();
		rblRecentComment.SelectedValue = model.BlogModel.RecentCommentListCount.ToString();
		rblRecentArticleCount.SelectedValue = model.BlogModel.RecentArticleListCount.ToString();
		rblUseEmoticon.SelectedValue		= model.BlogModel.UseEmoticon.ToString();
		ddlNewIcon.SelectedValue			= model.BlogModel.PeridoNewIcon.ToString();

		if (model.BlogModel.Picture != string.Empty)
			lblMyPicture.Text = BlogManager.GetInstance().GetMyPictureForImgTag();
		else
			lblMyPicture.Text = MessageCode.GetMessageByCode(BlogConst.MESSAGE_HAS_NOT_MYPICTURE);
	}

	protected void lnkRegister_Click(object sender, EventArgs e)
	{
		model.BlogModel.Title		= txtTitle.Text;
		model.BlogModel.Url			= txtUrl.Text;
		model.BlogModel.EMail		= txtEmail.Text;

		model.BlogModel.Name		= txtName.Text;
		model.BlogModel.NickName	= txtNickName.Text;
		model.BlogModel.Introduction= txtIntroduction.Text;
		model.BlogModel.Address		= ddlAddress.SelectedItem.Text;
		model.BlogModel.Hobby		= txtHobby.Text;

		model.BlogModel.Alarm		= bool.Parse(rblAlram.SelectedValue);
		model.BlogModel.AutoClip	= bool.Parse(rblAutoClip.SelectedValue);
		model.BlogModel.PostCount	= int.Parse(rblPostCount.SelectedValue);
		model.BlogModel.RecentCommentListCount	= int.Parse(rblRecentComment.SelectedValue);
		model.BlogModel.RecentArticleListCount	= int.Parse(rblRecentArticleCount.SelectedValue);
		model.BlogModel.UseEmoticon	= bool.Parse(rblUseEmoticon.SelectedValue);
		model.BlogModel.PeridoNewIcon= int.Parse(ddlNewIcon.SelectedValue);

		model.BlogModel.Gender		= (BlogConst.Gender)Enum.Parse(
			typeof(BlogConst.Gender), ddlGender.SelectedValue );

		string path	= Utility.GetAbsolutePath(UmcConfiguration.Core["BlogXmlPath"]);
		
		BlogManager.GetInstance().WriteBlogBaseInfo(path, model);

		Utility.JS_Alert(sender, MessageCode.MESSAGE_SAVED);

		
	}
}
