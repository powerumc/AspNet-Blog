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
using Umc.Core.Modules;
using Umc.Core.Modules.Comment;
using Umc.Core.Modules.Blog;
using Umc.Core.Web;
using Umc.Core.Web.Controls;

public partial class Common_Snap_Contents_GuestBoardContent : UmcContentsCommonPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		// 댓글달기
		CommentContent commentTempalte	= (CommentContent)LoadControl(CommentConst.PARAM_COMMENT_CONTROL_PATH);
		commentTempalte.ArticleNo		= BlogManager.GetInstance().BlogBaseModel.PrivacyModel.GuestBoardArticleNo;
		commentTempalte.IsWriteComment = 
			commentTempalte.SurelyVisible = 
			BlogManager.GetInstance().BlogBaseModel.PrivacyModel.CanWriteGuestBoard;

		this.Controls.Add(commentTempalte);
	}
}
