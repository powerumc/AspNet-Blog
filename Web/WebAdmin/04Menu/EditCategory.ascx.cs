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
using Umc.Core.Data;
using Umc.Core.Modules.Category;
using Umc.Core.Modules.Category.Model;
using Umc.Core.WebAdmin;
using Umc.Core.Util;

public partial class WebAdmin_04Menu_EditCategory : WebAdminCommonTemplate
{
	public const string MESSAGE_NOT_LISTBOX_SELECTED = "message.not.listbox.selected";
	public const string MESSAGE_QUESTION_REMOVE_CATEGORY = "message.question.remove.category";

	CategoryModel modelTree, modelList;
	CategoryCodeModel cateCode;
	int lCodeIndex;

	protected void Page_Load(object sender, EventArgs e)
	{
		init();
		if( !IsPostBack) bind();
		ViewState["IsPostBack"] = "true";
	}

	private void init()
	{
		string msg = string.Format("if(confirm('{0}')) {1}; else return false;",
			MessageCode.GetMessageByCode(MESSAGE_QUESTION_REMOVE_CATEGORY),
			Page.GetPostBackEventReference(btnRemove));
		btnRemove.Attributes["onclick"] = msg;
		modelTree	= CategoryManager.GetInstance().GetMyCategorys(typeof(CategoryTreeView));
	}

	private void bind()
	{
		txtCategoryTitle.Text = string.Empty;

		treePreviewMenu.Nodes.Clear();
		lbCategory.Items.Clear();

		modelTree.Bind( treePreviewMenu );

		modelList	= CategoryManager.GetInstance().GetMyCategorys(typeof(CategoryListBox));
		modelList.Bind( lbCategory );

		ddlCategory.Items.Clear();
		ddlCategory.Items.Add( new ListItem("---선택---", "-1") );
		for (int i = 0; i < modelList.Count; i++)
		{
			if( modelList[i].CategoryStep == 1)
				ddlCategory.Items.Add( new ListItem(modelList[i].CategoryTitle, modelList[i].CategoryGroup.ToString() ));
		}

		lCodeIndex	= lbCategory.SelectedIndex;

		cateCode = CategoryManager.GetInstance().GetCategoryCodes( lCodeIndex);
		ddlCategoryL.Items.Clear();
		ddlCategoryL.Items.Add(new ListItem("---대분류---", "-1"));
		for (int i = 0; i < cateCode.Count; i++)
			ddlCategoryL.Items.Add(new ListItem(cateCode[i].CategoryTitle, cateCode[i].CategoryCode.ToString()));

		ddlCategoryM.Items.Clear();
		ddlCategoryM.Items.Add(new ListItem("---중분류---", "-1"));
		for (int i = 0; i < cateCode.CategoryMCode.Count; i++)
			ddlCategoryM.Items.Add(new ListItem(cateCode.CategoryMCode[i].CategoryTitle, cateCode.CategoryMCode[i].CategoryCode.ToString()));
	}

	// 나의 카테고리 선택할때
	protected void lbCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		CategoryModel cateModel		= modelTree[lbCategory.SelectedIndex];

		txtCategoryTitle.Text = cateModel.CategoryTitle.Replace("___", "");
		ddlCategoryL.SelectedValue	= cateModel.CategoryLCode.ToString();

		CategoryMCodeBind(int.Parse(ddlCategoryL.SelectedValue));
		ddlCategoryM.SelectedValue	= cateModel.CategoryMCode.ToString();

		ddlCategory.SelectedValue	= cateModel.CategoryGroup.ToString();

		if( cateModel.CategoryStep == 1 ) 
			ddlCategory.Enabled = false;
		else
			ddlCategory.Enabled = true;
	}

	// 카테고리 대분류 이벤트
	protected void ddlCategoryL_SelectedIndexChanged(object sender, EventArgs e)
	{
		ddlCategoryM.Items.Clear();

		CategoryMCodeBind( int.Parse( ddlCategoryL.SelectedValue));
	}

	// 카테고리 중분류를 바인딩
	private void CategoryMCodeBind( int mCode )
	{
		ddlCategoryM.Items.Clear();
		ddlCategoryM.Items.Add(new ListItem("---중분류---", "-1"));

		if( mCode == -1 ) return;
		CategoryCodeModel cateCode = CategoryManager.GetInstance().GetCategoryCodes(mCode);
		for (int i = 0; i < cateCode.CategoryMCode.Count; i++)
			ddlCategoryM.Items.Add(new ListItem(cateCode.CategoryMCode[i].CategoryTitle, cateCode.CategoryMCode[i].CategoryCode.ToString()));

		CategoryModel cateModel = modelTree[lbCategory.SelectedIndex];
		ddlCategoryM.SelectedValue = cateModel.CategoryMCode.ToString();
	}

	// 새 카테고리 추가
	protected void btnNewCategory_Click(object sender, ImageClickEventArgs e)
	{
		CategoryNodeValue nodeValue	= new CategoryNodeValue(-1, -1, -1, -1, -1);

		CategoryManager.GetInstance().InsertNewCategory( "Umc Category", nodeValue,1 );

		init();
		bind();
	}

	// 자식 카테고리 추가
	protected void btnLine_Click(object sender, ImageClickEventArgs e)
	{
		int currentIndex = lbCategory.SelectedIndex;
		if( !ListBoxSelectedCheck(sender) ) return;
		
		CategoryNodeValue nodeValue = CategoryNodeValue.Parse(lbCategory.SelectedValue);
		string title = txtCategoryTitle.Text;

		nodeValue.CategoryStep = 2;
		CategoryManager.GetInstance().InsertNewCategory("Umc Child Category", nodeValue, 2);

		init();
		bind();

		lbCategory.SelectedIndex = currentIndex;
		lbCategory_SelectedIndexChanged(sender, e);
	}

	// 등록 버튼
	protected void btnCategoryRegist_Click(object sender, ImageClickEventArgs e)
	{
		if (!ListBoxSelectedCheck(sender)) return;

		CategoryNodeValue nodeValue	= CategoryNodeValue.Parse(lbCategory.SelectedValue);
		string title				= txtCategoryTitle.Text;
		int lCode					= int.Parse(ddlCategoryL.SelectedValue);
		int mCode					= int.Parse(ddlCategoryM.SelectedValue);
		int group					= int.Parse(ddlCategory.SelectedValue);

		CategoryManager.GetInstance().UpdateCategoryNodeValue(title, nodeValue, lCode, mCode, group);

		init();
		bind();
	}

	// 삭제 버튼
	protected void btnRemove_Click(object sender, ImageClickEventArgs e)
	{
		if (!ListBoxSelectedCheck(sender)) return;

		CategoryNodeValue nodeValue = CategoryNodeValue.Parse(lbCategory.SelectedValue);

		CategoryManager.GetInstance().RemoveCategoryNode( nodeValue );

		init();
		bind();
	}

	private bool ListBoxSelectedCheck(object sender)
	{
		if (lbCategory.SelectedIndex == -1)
		{
			Utility.JS_Alert(sender, MESSAGE_NOT_LISTBOX_SELECTED);
			return false;
		}
		return true;
	}

	// 카테고리를 위로 이동
	protected void btnUp_Click(object sender, ImageClickEventArgs e)
	{
		int currentIndex	= lbCategory.SelectedIndex;
		bool result			= false;
		if (!ListBoxSelectedCheck(sender)) return;

		CategoryNodeValue nodeValue = CategoryNodeValue.Parse(lbCategory.SelectedValue);
		
		if( nodeValue.CategoryStep == 2 )
			result = CategoryManager.GetInstance().UpdateMoveCategoryChildNode(nodeValue, "up");
		else
			CategoryManager.GetInstance().UpdateMoveCategoryNode(nodeValue,"up");

		init();
		bind();

		lbCategory.SelectedIndex = currentIndex;
		if(result) lbCategory.SelectedIndex--;

		lbCategory_SelectedIndexChanged(sender, e);
	}

	// 카테고리를 아래로 이동
	protected void btnDown_Click(object sender, ImageClickEventArgs e)
	{
		int currentIndex	= lbCategory.SelectedIndex;
		bool result			= false;
		if (!ListBoxSelectedCheck(sender)) return;

		CategoryNodeValue nodeValue = CategoryNodeValue.Parse(lbCategory.SelectedValue); 
		
		if( nodeValue.CategoryStep == 2 )
			result = CategoryManager.GetInstance().UpdateMoveCategoryChildNode(nodeValue, "down");
		else
			CategoryManager.GetInstance().UpdateMoveCategoryNode(nodeValue, "down");

		init();
		bind();

		lbCategory.SelectedIndex = currentIndex;
		if (result) lbCategory.SelectedIndex++;

		lbCategory_SelectedIndexChanged( sender, e );
	}
}
