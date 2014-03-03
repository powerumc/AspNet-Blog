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
using Umc.Core.Web;
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Comment;
using Umc.Core.Modules.Comment.Model;
using Umc.Core.Util;
using Umc.Core.Authenticate;

public partial class Common_Popup_CommentReply : UmcBlogBasePage
{
	private int articleNo;
	private int group;
	private int step;
	private int order;

	protected void Page_Load(object sender, EventArgs e)
	{
		initParam();

		if( IsPostBack ) return;

		bind();
	}

	protected override void Render(HtmlTextWriter writer)
	{
		base.Render(writer);
	}

	protected void initParam()
	{
		articleNo		= GetParamInt("articleNo");
		group			= GetParamInt("group");
		step			= GetParamInt("step");
		order			= GetParamInt("order");
	}

	protected void bind()
	{
		txtUserName.Text		= CurrentUserInfo.NickName;
		txtUserBlogUrl.Text		= CurrentUserInfo.Homepage;
	}

	protected void btnRegister_Click(object sender, ImageClickEventArgs e)
	{
		if (txtUserName.Text == string.Empty )
		{
			Utility.JS_Alert(sender, CommentConst.MESSAGE_COMMENT_EMPTY_NAME); return;
		}
		if (txtPassword.Text == string.Empty)
		{
			Utility.JS_Alert(sender, CommentConst.MESSAGE_COMMENT_EMPTY_PASSWORD); return;
		}
		if (txtContent.Text == string.Empty)
		{
			Utility.JS_Alert(sender, CommentConst.MESSAGE_COMMENT_EMPTY_CONTENT); return;
		}
		if (txtConfirmBitmapHandler.Text == string.Empty)
		{
			Utility.JS_Alert(sender, CommentConst.MESSAGE_COMMENT_EMPTY_CONFIRM_VALIDATE_STRING); return;
		}
		if (txtConfirmBitmapHandler.Text != (string)Session[Parameters.SESSION_CONFIRM_VALIDATE_STRING])
		{
			Utility.JS_Alert(sender, CommentConst.MESSAGE_COMMENT_NOT_EQUAL_CONFIRM_VALIDATE_STRING); return;
		}

		CommentModel model = new CommentModel(articleNo);
		model.CommentGroup	= group;
		model.CommentStep	= step;
		model.CommentOrder	= order;
		model.UserEmail = CurrentUserInfo.EMail;
		model.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(
							txtPassword.Text, AuthenticateConst.AUTHENTICATE_HASH_FORMAT);
		//model.BoardName = boardName;
		model.UserName = txtUserName.Text;
		model.UserBlogUrl = txtUserBlogUrl.Text;
		model.Content = txtContent.Text;
		model.UserIP = Request.UserHostAddress;
		model.CommentType	= CommentAttribute.Reply;

		CommentManager.GetInstance().InsertComment(model);

		Utility.JsCall(sender, "opener.commentUpdate"+ articleNo + "(); self.close();");
	}
}
