using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Umc.Core;
using Umc.Core.Authenticate;
using Umc.Core.Data;
using Umc.Core.Web;
using Umc.Core.Util;
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Article.Model;
using Umc.Core.Modules.Blog;
using Umc.Core.Modules.Comment;
using Umc.Core.Modules.Emoticon;
using Umc.Core.Modules.Trackback;

namespace Umc.Core.Web.Controls
{
	public partial class ArticleContent : UmcContentsCommonPage
	{
		protected Label lblInsertDate, lblTrackbackUrl;
		protected HyperLink hpTitle;
		protected DataList dlAttachFile, dlTrackbackList;
		protected Repeater dlTag;
		protected System.Web.UI.HtmlControls.HtmlContainerControl divContent, divTag, divTrackback, divArticleInfo;
		protected System.Web.UI.HtmlControls.HtmlTable tblArticle;
		protected Literal ltrCommentCount, ltrTrackbackCount;
		protected System.Web.UI.HtmlControls.HtmlAnchor aGoComment;
		protected PlaceHolder phComment;

		// 기본값은 -100
		private int articleNo		= -100;
		private ArticleModel model;

		public int ArticleNo
		{
			set { articleNo = value; }
			get { return articleNo; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			initParam();

			bind();
		}

		protected void initParam()
		{
			// 외부에서 값을 세팅한 경우 외부 아티클 번호를 사용한다.
			articleNo = articleNo == -100 ? GetParamInt(ArticleConst.PARAM_ARTICLENO, -1) : articleNo;
		}

		protected void bind()
		{
			model = ArticleManager.GetInstance().GetArticleByArticleNo(articleNo);

			if (model == null)
			{
				divTag.Visible			= false;
				divTrackback.Visible	= false;
				SetMessageContent(ArticleConst.MESSAGE_HAS_NOT_ARTICLE);
				return;
			}
			

			string tempContent = model.Content;
			if (BlogManager.GetInstance().BlogBaseModel.BlogModel.UseEmoticon)
			{
				List<EmoticonModel> bindModel = EmoticonManager.GetInstance().Model;
				for (int i = 0; i < bindModel.Count; i++)
				{
					string imgTag = string.Format("<img src=\"{0}/Emoticon/{1}\" alt=\"{2}\" style=\"vertical-align:middle;\" />",
						UmcConfiguration.Core["repository.dir"],
						bindModel[i].EmoticonValue,
						bindModel[i].Description);

					tempContent = tempContent.Replace(bindModel[i].EmoticonString, imgTag);
				}
			}

			hpTitle.Text			= model.Title;
			hpTitle.NavigateUrl		= Utility.MakeArticleUrl( model.ArticleNo );
			hpTitle.Target			= "_parent";
			lblInsertDate.Text		= ((DateTime)model.InsertDate).ToShortDateString();
			divContent.InnerHtml	= tempContent;

			// 비공개 아티클일 경우
			if (!model.PublicFlag && CurrentUserInfo.Level != LevelAttribute.ADMIN)
			{
				divTag.Visible = divTrackback.Visible = divContent.Visible = false;
				SetMessageContent(ArticleConst.MESSAGE_NOT_PERMIT_READ_ARTICLE);
				return;
			}

			// 트랙백이 허용될경우
			if (model.AllowTrackback)
			{
				lblTrackbackUrl.Text = Utility.MakeTrackbackUrl(articleNo);
				lblTrackbackUrl.Style.Add("cursor", "hand");
				lblTrackbackUrl.Attributes["onclick"] = "javascript:copyBlock(this)";
			}

			// 댓글달리 리스트 바인딩
			CommentContent commentTempalte	= (CommentContent)LoadControl( CommentConst.PARAM_COMMENT_CONTROL_PATH );
			commentTempalte.ArticleNo		= articleNo;
			commentTempalte.IsWriteComment	= 
				model.AllowComment && BlogManager.GetInstance().BlogBaseModel.PrivacyModel.CanWriteMemo;
			phComment.Controls.Add( commentTempalte );

			// 트랙백 리스트 바인딩
			dlTrackbackList.DataSource		= TrackbackManager.GetInstance().GetTrackbackList( articleNo );
			dlTrackbackList.DataBind();

			// 태그 바인딩
			dlTag.DataSource				= model.Tag;
			dlTag.DataBind();

			dlAttachFile.DataSource = model.AttachFile;
			dlAttachFile.DataBind();

			ltrCommentCount.Text			= model.CommentCount.ToString();
			ltrTrackbackCount.Text			= model.TrackbackCount.ToString();
			aGoComment.HRef					= Utility.MakeArticleUrl( model.ArticleNo ) + "#comment";
		}
	}
}