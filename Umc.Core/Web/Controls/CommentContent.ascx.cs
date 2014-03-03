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
using Umc.Core.Modules.Article;
using Umc.Core.Authenticate;
using Umc.Core.Util;

namespace Umc.Core.Web.Controls
{
	public partial class CommentContent : UmcContentsCommonPage
	{
		protected TextBox txtUserName, txtPassword, txtContent, txtUserBlogUrl, txtConfirmBitmapHandler;
		protected DataList dlCommentList;
		protected System.Web.UI.HtmlControls.HtmlContainerControl divWriteComment;

		private int articleNo = -100;
		public int ArticleNo
		{
			set { articleNo = value; }
			get { return articleNo; }
		}

		private bool isWriteComment	= true;
		public bool IsWriteComment
		{
			get { return isWriteComment; }
			set { isWriteComment = value; }
		}

		private bool surelyVisible = false;
		public bool SurelyVisible
		{
			get { return surelyVisible; }
			set { surelyVisible = value; }
		}


		protected void Page_Load(object sender, EventArgs e)
		{
			initParam();

			if (IsPostBack) return;

			bind();
		}
		protected void initParam()
		{
			// 아티클 리스트 보기 일경우 댓글달기 안보임 || 댓글 허용 아님이면 안보임
			if ( GetParamInt(ArticleConst.PARAM_ARTICLENO) == -1 || !IsWriteComment)
				divWriteComment.Visible = false;

			if( SurelyVisible )
				divWriteComment.Visible	= true;

			articleNo = articleNo == -100 ? GetParamInt(ArticleConst.PARAM_ARTICLENO, -1) : articleNo;
		}

		protected void bind()
		{
			if (IsLogin)
			{
				txtUserName.Text		= CurrentUserInfo.NickName;
				txtUserBlogUrl.Text		= CurrentUserInfo.Homepage;
			}

			CommentBindModel bindModel	= CommentManager.GetInstance().GetCommentList(articleNo);
			dlCommentList.DataSource	= bindModel;
			dlCommentList.DataBind();
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
				Utility.JS_Alert(sender, CommentConst.MESSAGE_COMMENT_EMPTY_CONFIRM_VALIDATE_STRING ); return;
			}
			if (txtConfirmBitmapHandler.Text != (string)Session[Parameters.SESSION_CONFIRM_VALIDATE_STRING])
			{
				Utility.JS_Alert(sender, CommentConst.MESSAGE_COMMENT_NOT_EQUAL_CONFIRM_VALIDATE_STRING ); return;
			}

			CommentModel model	= new CommentModel(articleNo);
			model.UserEmail		= CurrentUserInfo.EMail;
			model.Password		= FormsAuthentication.HashPasswordForStoringInConfigFile(
									txtPassword.Text, AuthenticateConst.AUTHENTICATE_HASH_FORMAT);
			model.UserName		= txtUserName.Text;
			model.UserBlogUrl	= txtUserBlogUrl.Text;
			model.Content		= txtContent.Text;
			model.UserIP		= Request.UserHostAddress;

			CommentManager.GetInstance().InsertComment(model);

			Utility.JS_Alert(sender, CommentConst.MESSAGE_INSERT_COMMENT);

			bind();
			ClearControl();
		}

		protected void ClearControl()
		{
			txtUserName.Text				= string.Empty;
			txtContent.Text					= string.Empty;
			txtUserBlogUrl.Text				= string.Empty;
			txtConfirmBitmapHandler.Text	= string.Empty;
		}
		protected void dlCommentList_ItemDataBound(object sender, DataListItemEventArgs e)
		{
			if (!(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)) return;

			CommentModel model			= (CommentModel)e.Item.DataItem;

			HtmlTable tbComment			= (HtmlTable)e.Item.FindControl("tbComment");
			LinkButton lnkReply			= (LinkButton)e.Item.FindControl("lnkReply");
			LinkButton lnkRemove		= (LinkButton)e.Item.FindControl("lnkRemove");
			LinkButton lnkModify		= (LinkButton)e.Item.FindControl("lnkModify");
			HtmlTableCell tdComment		= (HtmlTableCell)e.Item.FindControl("tdComment");
			Label lblContent			= (Label)e.Item.FindControl("lblContent");
			HyperLink hpUserName		= (HyperLink)e.Item.FindControl("hpUserName");
			Literal ltrNewIcon			= (Literal)e.Item.FindControl("ltrNewIcon");

			lnkReply.OnClientClick = string.Format("openCommentReply({0},{1},{2},{3}); return false;",
				model.ArticleNo,
				model.CommentGroup,
				model.CommentStep,
				model.CommentOrder
				);
			lnkReply.Visible = true;


			if (IsLogin && model.UserEmail == CurrentUserInfo.EMail) // 자신의 글이라면..
			{
				lnkRemove.Visible	= true;
				lnkModify.Visible	= true;

				lnkRemove.OnClientClick = string.Format("return confirm('{0}');",
					UmcConfiguration.Message[CommentConst.MESSAGE_REALLY_REMOVE_COMMENT]);
			}
			else // 익명사용자면 비밀번호 확인
			{
				lnkRemove.OnClientClick = string.Format("openRemoveComment({0},{1}); return false;",
					model.ArticleNo,
					model.CommentNo);
			}

			lnkModify.OnClientClick = string.Format("opemModifyComment({0},{1}); return false;",
				model.ArticleNo,
				model.CommentNo);

			if (!IsLogin)
			{
				lnkRemove.Visible	= true;
				lnkModify.Visible	= true;
			}

			tdComment.Style["padding-left"] = ((int)(model.CommentStep * 50)).ToString() + "px";

			hpUserName.Text			= model.UserName;
			hpUserName.NavigateUrl	= model.UserBlogUrl != string.Empty ? "http://" + model.UserBlogUrl : string.Empty;
			hpUserName.Target		= "_parent";
			lblContent.Text			= Server.HtmlEncode(model.Content).Replace("\r\n", "<br>");
			ltrNewIcon.Text			= Parameters.ICON_NEW;
			ltrNewIcon.Visible		= model.NewIcon;
		}
		protected void dlCommentList_ItemCommand(object source, DataListCommandEventArgs e)
		{
			if (e.CommandName == "remove")
			{
				int commentNo = int.Parse(e.CommandArgument.ToString());
				if (CommentManager.GetInstance().RemoveComment(commentNo) == 0)
				{
					Utility.JS_Alert(source, CommentConst.MESSAGE_CAN_NOT_REMOVE_COMMENT);
				}
				else
				{
					Utility.JS_Alert(source, CommentConst.MESSAGE_REMOVE_COMMENT);
				}
			}
			bind();
		}
	}
}