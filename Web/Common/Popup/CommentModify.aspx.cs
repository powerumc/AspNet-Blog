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
using Umc.Core.Modules.Comment;
using Umc.Core.Modules.Comment.Model;
using Umc.Core.Util;
using Umc.Core.Authenticate;

public partial class Common_Popup_CommentModify : UmcBlogBasePage
{
	private int articleNo;
	private int commentNo;
	private CommentModel model;
	private string script = string.Empty;

	protected void Page_Load(object sender, EventArgs e)
	{
		initParam();

		if( IsPostBack) return;

		bind();
	}

	private void initParam()
	{
		articleNo		= GetParamInt("articleNo", -1);
		commentNo		= GetParamInt("commentNo", -1);
		
		model = CommentManager.GetInstance().GetComment(commentNo);

		if (commentNo == -1 || model == null || model.UserEmail != CurrentUserInfo.EMail)
		{
			script = string.Format("alert('{0}'); self.close();", UmcConfiguration.Message[CommentConst.MESSAGE_ERROR_VALIEDATE_PARAM]);
			Utility.JsCall(this, script);
		}
	}

	private void bind()
	{
		

		if (!IsLogin)
		{
			pnPassword.Visible	= true;
			pnModify.Visible	= false;
		}
		else
		{
			pnPassword.Visible	= false;
			pnModify.Visible	= true;
			controlBind();
		}
	}

	private void controlBind()
	{
		txtUserName.Text		= model.UserName;
		txtUserBlogUrl.Text		= model.UserBlogUrl;
		txtContent.Text			= model.Content;
	}
	protected void ibCheckPassword_Click(object sender, ImageClickEventArgs e)
	{
		string password = FormsAuthentication.HashPasswordForStoringInConfigFile(
							txtCheckPassword.Text, AuthenticateConst.AUTHENTICATE_HASH_FORMAT);

		if (model.Password == password)
		{
			pnPassword.Visible	= false;
			pnModify.Visible	= true;
			controlBind();
		}
		else
		{
			script = string.Format("alert('{0}'); self.close();", UmcConfiguration.Message[CommentConst.MESSAGE_NOT_EQUAL_PASSWORD]);
			Utility.JsCall(sender, script);
		}
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

		model.CommentNo		= commentNo;
		model.UserName		= txtUserName.Text;
		model.Password		= FormsAuthentication.HashPasswordForStoringInConfigFile(
							txtPassword.Text, AuthenticateConst.AUTHENTICATE_HASH_FORMAT);
		model.Content		= txtContent.Text;
		model.UserBlogUrl	= txtUserBlogUrl.Text;

		CommentManager.GetInstance().UpdateComment( model );

		string message		= UmcConfiguration.Message[ CommentConst.MESSAGE_COMMENT_UPDATE_COMMENT ];
		string script		= string.Format("alert('{0}'); opener.commentUpdate"+articleNo+"(); self.close();", message );
		Utility.JsCall( sender, script );
	}
}
