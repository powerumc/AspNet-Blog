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

public partial class Common_Popup_CheckCommentPassword : UmcBlogBasePage
{
	private int articleNo;
	private int commentNo;

	protected void Page_Load(object sender, EventArgs e)
	{
		initParam();
	}

	private void initParam()
	{
		articleNo		= GetParamInt("articleNo", -1);
		commentNo		= GetParamInt( "commentNo", -1 );
	}
	protected void ibCheck_Click(object sender, ImageClickEventArgs e)
	{
		CommentModel model	= CommentManager.GetInstance().GetComment(commentNo);

		string script		= string.Empty;

		if (commentNo == -1 || model == null)
		{
			script = string.Format("alert('{0}'); self.close();", UmcConfiguration.Message[CommentConst.MESSAGE_ERROR_VALIEDATE_PARAM]);
			Utility.JsCall( sender, script );
		}

		string password = FormsAuthentication.HashPasswordForStoringInConfigFile(
							txtPassword.Text, AuthenticateConst.AUTHENTICATE_HASH_FORMAT);

		if (model.Password == password)
		{
			if (CommentManager.GetInstance().RemoveComment(commentNo) == 0)
			{
				script = string.Format("alert('{0}'); self.close();", UmcConfiguration.Message[CommentConst.MESSAGE_CAN_NOT_REMOVE_COMMENT]);
			}
			else
			{
				script = string.Format("alert('{0}'); opener.commentUpdate"+articleNo+"();self.close();", UmcConfiguration.Message[CommentConst.MESSAGE_REMOVE_COMMENT]);
			}
		}
		else
		{
			script = string.Format("alert('{0}'); self.close();", UmcConfiguration.Message[CommentConst.MESSAGE_NOT_EQUAL_PASSWORD]);
		}

		Utility.JsCall( sender, script );
	}
}
