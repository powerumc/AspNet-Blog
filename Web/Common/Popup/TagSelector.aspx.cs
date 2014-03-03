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
using Umc.Core.WebAdmin;
using Umc.Core.Modules;
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Article.Model;

public partial class Common_Popup_TagSelector : WebAdminTemplate
{
	protected void Page_Load(object sender, EventArgs e)
	{
		bind();
	}

	private void bind()
	{
		TagBindModel bindModel		= ArticleManager.GetInstance().GetTagList();

		rptTagList.DataSource		= bindModel;
		rptTagList.DataBind();
	}
}
