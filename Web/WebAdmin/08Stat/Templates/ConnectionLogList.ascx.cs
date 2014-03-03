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
using Umc.Core.Modules.Stat;
using Umc.Core.Modules.Breaker;

public partial class WebAdmin_08Stat_Templates_ConnectionLogList : WebAdminCommonTemplate
{
	protected void Page_Load(object sender, EventArgs e)
	{
		initParam();

		if( IsPostBack) return;

		bind();
	}

	protected int CurrentPage
	{
		get { return UmcPager1.CurrentPageIndex; }
		set { UmcPager1.CurrentPageIndex = value; }
	}
	protected int PageSize
	{
		get { return UmcPager1.PageSize; }
		set { UmcPager1.PageSize = value; }
	}
	protected string SearchKeyword
	{
		get { return ddlSearchKeyword.SelectedValue; }
	}
	protected string SearchString
	{
		get { return txtSearchString.Text; }
	}

	private void initParam()
	{
	}

	private void bind()
	{
		UmcPager1.PageSize = int.Parse(ddlPageSize.SelectedValue);

		DataSet ds = StatManager.GetInstance().GetConnectionLogList( CurrentPage, PageSize, SearchKeyword, SearchString );

		UmcPager1.RecordCount	= int.Parse(ds.Tables[0].Rows[0][0].ToString() );
		
		dlList.DataSource = ds.Tables[1];
		dlList.DataBind();
	}
	protected void UmcPager1_PageIndexChanged(object sender, Umc.Core.Web.Controls.PageIndexChangedEventArgs e)
	{
		CurrentPage		= e.NewPageIndex;

		bind();
	}
	protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
	{
		UmcPager1.PageSize	= int.Parse(ddlPageSize.SelectedValue);
		bind();
	}
	protected void lnkSearch_Click(object sender, EventArgs e)
	{
		bind();
	}
	protected void dlList_ItemCommand(object source, DataListCommandEventArgs e)
	{
		if (e.CommandName == "breaker")
		{
			BreakerModel breakerModel	= new BreakerModel();
			breakerModel.UserIP			= e.CommandArgument.ToString();

			if (BreakerManager.GetInstance().InsertBreaker(breakerModel) == -1)
			{
				Umc.Core.Util.Utility.JS_Alert(this, BreakerConst.MESSAGE_BREAKER_ALREADY_INSERT);
			}
			else
			{
				Umc.Core.Util.Utility.JS_Alert(this, BreakerConst.MESSAGE_BREAKER_INSERT);
			}
		}
		else if (e.CommandName == "unbreaker")
		{
			if (BreakerManager.GetInstance().RemoveBreaker(e.CommandArgument.ToString()))
			{
				Umc.Core.Util.Utility.JS_Alert(this, BreakerConst.MESSAGE_BREAKER_REMOVE);
			}
			else
			{
				Umc.Core.Util.Utility.JS_Alert(this, BreakerConst.MESSAGE_BREAKER_CAN_NOT_REMOVE);
			}
		}
		bind();
	}
	protected void dlList_ItemDataBound(object sender, DataListItemEventArgs e)
	{
		if( !(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem ) ) return;

		DataRowView row					= (DataRowView)e.Item.DataItem;
		bool BreakerFlag				= bool.Parse(row["BreakerFlag"].ToString());

		LinkButton lnkBreaker			= (LinkButton)e.Item.FindControl("lnkBreaker");
		LinkButton lnkUnBreaker			= (LinkButton)e.Item.FindControl("lnkUnBreaker");

		if (BreakerFlag)
		{
			lnkUnBreaker.Visible		= true;
		}
		else
		{
			lnkBreaker.Visible			= true;
		}
	}
}
