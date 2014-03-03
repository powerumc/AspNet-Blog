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

using Umc.Core.Web;
using Umc.Core.Modules.Category;
using Umc.Core.Modules.Category.Model;
using Umc.Core.Modules.Snap;
using Umc.Core.Util;

public partial class Common_Snap_Templates_SnapCategory : UmcContentsCommonPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if(!IsPostBack) bind();
	}

	private void bind()
	{
		CategoryModel model	= CategoryManager.GetInstance().GetMyCategorys(typeof(CategoryTreeView));

		TreeView treeview = (TreeView)((System.Web.UI.UpdatePanel)snap_Category.FindControl("panelCategory")).FindControl("treeCategory");

		model.Bind( treeview );

		treeview.CollapseAll();
	}

	protected void treeCategory_SelectedNodeChanged(object sender, EventArgs e)
	{
		ContentViewControl			= SnapConst.SNAP_TEMPLATE_CATEGORY;
		CurrentCategoryNodeValue	= CategoryNodeValue.Parse(treeCategory.SelectedValue);
		Update();	
	}
}
