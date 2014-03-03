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

public partial class WebAdmin_05Article_ArticleWrite : WebAdminCommonTemplate
{
	protected CategoryModel categoryL	= null;

	protected void Page_Load(object sender, EventArgs e)
	{
		categoryL = CategoryManager.GetInstance().GetMyCategorys(typeof(CategoryListBox));
	
	}
}