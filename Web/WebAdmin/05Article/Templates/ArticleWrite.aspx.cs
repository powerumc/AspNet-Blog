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
using Umc.Core.Util;
using Umc.Core.Web;
using Umc.Core.WebAdmin;
using Umc.Core.Modules.Category;
using Umc.Core.Modules.Category.Model;
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Article.Model;
using Umc.Core.Modules.Trackback;
using Umc.Core.Modules.Blog;

public partial class WebAdmin_05Article_ArticleWrite : WebAdminTemplate
{
	CategoryModel categoryL;
	protected int articleNo;
	protected ArticleModel articleModel;

	// 등록할 수 없는 태그
	private string[] noTagList	= new string[] {
		"/", "?", ":", "&", "\\", "*", "^", "<", ">", "|", "#", "%","+",
		"..","...","....",
		"CON", "AUX", "PRN", "COM1", "LPT2"
	};

	#region 프로퍼티
	protected string ListQueryString
	{
		get
		{
			string url = string.Format("{0}?{1}={2}&{3}={4}",
				Request.Path,
				Parameters.PARAM_MODULE_ID, ModuleID,
				Parameters.PARAM_VIEWMODE, Parameters.VIEWMODE_LIST);

			return url;
		}
	}
	protected string ViewQueryString
	{
		get
		{
			string url = string.Format("{0}?{1}={2}&{3}={4}&{5}=",
				Request.Path,
				Parameters.PARAM_MODULE_ID, ModuleID,
				Parameters.PARAM_VIEWMODE, Parameters.VIEWMODE_VIEW,
				ArticleConst.PARAM_ARTICLENO
				);
			return url;
		}
	}
	#endregion

	protected void Page_Load(object sender, EventArgs e)
	{
		initParam();
		categoryL = CategoryManager.GetInstance().GetMyCategorys(typeof(CategoryListBox));

		if (!IsPostBack)
		{
			init();
			ddlCategoryL_SelectedIndexChanged(this, null);

			if( articleNo > 0 ) ddlCategoryM.SelectedValue = articleModel.CategoryID.ToString();
		}
	}

	// 파라메터 초기화
	private void initParam()
	{
		articleNo = GetParamInt(ArticleConst.PARAM_ARTICLENO, -1);
	}

	// 컨트롤 초기화
	private void init()
	{
		// FckEditor 초기화
		string sPath = Request.Url.AbsolutePath;
		sPath = "/FckEditor/";
		FCKeditor1.BasePath = sPath;

		FCKeditor1.Height = new Unit(400);
		FCKeditor1.UseBROnCarriageReturn = true;
		FCKeditor1.ImageBrowserURL = sPath + "editor/filemanager/browser/default/browser.html?Type=Image&Connector=connectors/aspx/connector.aspx";
		FCKeditor1.LinkBrowserURL = sPath + "editor/filemanager/browser/default/browser.html?Connector=connectors/aspx/connector.aspx";

		// 카테고리 데이터를 초기화
		ddlCategoryL.Items.Clear();
		for (int i = 0; i < categoryL.Count; i++)
		{
			if (categoryL[i].CategoryStep == 1)
			{
				ListItem item = new ListItem(categoryL[i].CategoryTitle, categoryL[i].CategoryGroup.ToString());
				ddlCategoryL.Items.Add(item);
			}
		}

		// 아티클 수정 모드일때 내용 초기화
		if (articleNo > 0 )
		{
			articleModel = ArticleManager.GetInstance().GetArticleByArticleNo(articleNo);

			txtTitle.Text					= articleModel.Title;
			txtTrackbackUrl.Text			= articleModel.TrackbackUrl;
			FCKeditor1.Value				= articleModel.Content;
			rblPublicFlag.SelectedValue		= articleModel.PublicFlag.ToString();
			rblPublicRss.SelectedValue		= articleModel.PublicRss.ToString();
			rblAllowComment.SelectedValue	= articleModel.AllowComment.ToString();
			rblAllowTrackback.SelectedValue	= articleModel.AllowTrackback.ToString();
			txtTag.Text						= TagModel.Parse( articleModel.Tag );

			dlAttachFile.DataSource			= articleModel.AttachFile;
			dlAttachFile.DataBind();

			ddlCategoryL.SelectedValue		= articleModel.CategoryGroup.ToString();
		}
	}

	// 에디터 창을 더 작게..
	protected void lnkMinusHeight_Click(object sender, EventArgs e)
	{
		double height = FCKeditor1.Height.Value;
		if (height > 200) height -= 100;

		FCKeditor1.Height = Unit.Parse(height.ToString());
		panelEditor.Update();
	}
	// 에디터 창을 더 크게..
	protected void lnkPlusHeight_Click(object sender, EventArgs e)
	{
		double height = FCKeditor1.Height.Value;
		if (height < 1000) height += 100;

		FCKeditor1.Height = Unit.Parse(height.ToString());
		panelEditor.Update();
	}

	protected void ddlCategoryL_SelectedIndexChanged(object sender, EventArgs e)
	{
		//CategoryNodeValue node = CategoryNodeValue.Parse(ddlCategoryL.SelectedValue);

		int group		= int.Parse( ddlCategoryL.SelectedValue );

		ddlCategoryM.Items.Clear();
		 
		for (int i = 0; i < categoryL.Count; i++)
		{
			if ( group == categoryL[i].CategoryGroup &&
				categoryL[i].CategoryStep > 1)
			{
				ListItem item = new ListItem(categoryL[i].CategoryTitle, categoryL[i].CategoryID.ToString());
				ddlCategoryM.Items.Add(item);
			}
		}

		
	}

	protected void lnkRegister_Click(object sender, EventArgs e)
	{
		if (txtTitle.Text.Length == 0)
		{
			Utility.JS_Alert(sender, MessageCode.GetMessageByCode("message.no.title"));
			return;
		}
		if (FCKeditor1.Value.Length == 0)
		{
			Utility.JS_Alert(sender, MessageCode.GetMessageByCode("message.no.content"));
			return;
		}
		bool tagValidate = true;
		foreach (string noTag in noTagList)
		{
			if (txtTag.Text.IndexOf(noTag) != -1)
			{
				tagValidate = false;
				break;
			}
		}
		if (!tagValidate)
		{
			Utility.JS_Alert(sender, MessageCode.GetMessageByCode("message.article.notaglist"));
			return;
		}

		HttpFileCollection fileCollection	= Request.Files;
		//CategoryNodeValue node				= CategoryNodeValue.Parse( ddlCategoryM.SelectedValue );

		ArticleModel model	= new ArticleModel();
		model.CategoryID	= int.Parse( ddlCategoryM.SelectedValue );
		model.Title			= txtTitle.Text;
		model.Content		= FCKeditor1.Value;
		model.TrackbackUrl	= txtTrackbackUrl.Text;
		model.PublicFlag	= bool.Parse( rblPublicFlag.SelectedValue );
		model.PublicRss		= bool.Parse( rblPublicRss.SelectedValue );
		model.AllowComment	= bool.Parse( rblAllowComment.SelectedValue );
		model.AllowTrackback= bool.Parse( rblAllowTrackback.SelectedValue );

		string[] tags	= txtTag.Text.Split(',');

		foreach (string tag in tags)
		{
			model.Tag.Add( new TagModel(tag) );
		}

		// 아티클 수정모드라면 다른곳으로 분기
		if (articleNo > 0)
		{
			updateArticle( model );
			return;
		}

		int seqNo = ArticleManager.GetInstance().InsertArticle( model, fileCollection );

		TrackbackModel trackbackModel	= new TrackbackModel();
		trackbackModel.ArticleNo		= seqNo;
		trackbackModel.Blog_Name		= BlogManager.GetInstance().BlogBaseModel.BlogModel.Title;
		trackbackModel.Title			= model.Title;
		trackbackModel.Exceprt			= model.Content;
		trackbackModel.Url				= Utility.MakeArticleUrl( seqNo );
		trackbackModel.UserIP			= Request.UserHostAddress;

		// 트랙백 보내는 아티클이면..
		if (txtTrackbackUrl.Text.Length > 0)
		{
			TrackbackManager.GetInstance().SendTrackback( txtTrackbackUrl.Text, trackbackModel );
		}

		string script = string.Format("alert('{0}'); location.href='{1}';",
		        UmcConfiguration.Message[ArticleConst.MESSAGE_ARTICLE_REGIST],
		        ListQueryString);
		Utility.JsCall( sender, script );
	}
	protected void dlAttachFile_ItemCommand(object source, DataListCommandEventArgs e)
	{
		//첨부파일을 삭제한다.
		if (e.CommandName == "removeAttach")
		{
			int fileNo	= int.Parse(e.CommandArgument.ToString());
			ArticleManager.GetInstance().RemoveAttachFileByFileNo( fileNo );

			init();
		}
	}

	private void updateArticle(ArticleModel model)
	{
		model.ArticleNo						= articleNo;
		HttpFileCollection fileCollection	= Request.Files;
		bool succ = ArticleManager.GetInstance().UpdateArticle( model, fileCollection );

		string script = string.Empty;

		if( succ )
			script = string.Format("alert('{0}'); location.href='{1}{2}';",
				UmcConfiguration.Message[ArticleConst.MESSAGE_UPDATE_SUCCESS],
				ViewQueryString, 
				articleNo.ToString());
		else
			script = string.Format("alert('{0}'); location.href='{1}{2}';",
				UmcConfiguration.Message[ArticleConst.MESSAGE_UPDATE_FAIL],
				ViewQueryString, 
				articleNo.ToString());

		Utility.JsCall( this, script );
	}

	
}
