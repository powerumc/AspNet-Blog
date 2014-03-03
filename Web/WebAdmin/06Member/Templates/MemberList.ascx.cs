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
using Umc.Core.Authenticate;

public partial class WebAdmin_06Member_Templates_MemberList : WebAdminCommonTemplate
{
	UserInfoBindModel bindModel;

	protected void Page_Load(object sender, EventArgs e)
	{
		initParam();

		if( IsPostBack ) return;

		bind();

	}

	private void initParam()
	{
	}

	private void bind()
	{
		bindModel			= Authenticator.GetInstance().GetUserList( 
			Pager.CurrentPageIndex,
			PageSize,
			SearchKeyword,
			SearchString );

		num					= bindModel.TotalCount - ( Pager.CurrentPageIndex * PageSize );
		Pager.RecordCount	= bindModel.TotalCount;
		Pager.PageSize		= PageSize;

		dlList.DataSource	= bindModel;
		dlList.DataBind();
	}

	public int PageSize
	{
		get { return int.Parse(ddlPageSize.SelectedValue); }
	}
	public string SearchKeyword
	{
		get { return ddlSearchKeyword.SelectedValue; }
	}
	public string SearchString
	{
		get { return txtSearchString.Text; }
	}

	private int num;
	protected int Num
	{
		get { return num--; }
	}
	protected void dlList_EditCommand(object source, DataListCommandEventArgs e)
	{
		UserInfo model = (UserInfo)dlList.Items[e.Item.ItemIndex].DataItem;
		dlList.EditItemIndex = e.Item.ItemIndex;
		
		bind();

		DropDownList ddlLevel = (DropDownList)dlList.Items[e.Item.ItemIndex].FindControl("ddlLevel");
		ddlLevel.DataSource = Authenticator.GetInstance().GetMemberLevelRole();
		ddlLevel.DataBind();
		
	}
	protected void dlList_CancelCommand(object source, DataListCommandEventArgs e)
	{
		dlList.EditItemIndex = -1;
		bind();
	}
	protected void dlList_UpdateCommand(object source, DataListCommandEventArgs e)
	{
		string oldEmail = e.CommandArgument.ToString();

		TextBox txtEMail		= (TextBox)e.Item.FindControl("txtEMail");
		TextBox txtName			= (TextBox)e.Item.FindControl("txtName");
		TextBox txtNickName		= (TextBox)e.Item.FindControl("txtNickName");
		TextBox txtHomePage		= (TextBox)e.Item.FindControl("txtHomePage");
		DropDownList ddlLevel	= (DropDownList)e.Item.FindControl("ddlLevel");

		UserInfo userInfo		= UserInfo.CreateUser( txtEMail.Text );
		userInfo.Name			= txtName.Text;
		userInfo.NickName		= txtNickName.Text;
		userInfo.Homepage		= txtHomePage.Text;
		userInfo.Level			= (LevelAttribute)Enum.Parse( typeof( LevelAttribute ), ddlLevel.SelectedItem.Text );

		Authenticator.GetInstance().UpdateUserInfo( oldEmail, userInfo );

		dlList.EditItemIndex	= -1;
		bind();
	}
	protected void dlList_ItemDataBound(object sender, DataListItemEventArgs e)
	{
		if( !(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem) ) return;

		LinkButton lnkRemove = (LinkButton)e.Item.FindControl("lnkRemove");

		lnkRemove.OnClientClick = string.Format("return confirm('정말로 삭제하시겠습니까?');");
	}
	protected void dlList_ItemCommand(object source, DataListCommandEventArgs e)
	{
		if (e.CommandName == "Delete")
		{
			Authenticator.GetInstance().RemoveUserInfo( e.CommandArgument.ToString() );

			bind();
		}
	}
	protected void lnkSearch_Click(object sender, EventArgs e)
	{
		bind();
	}
	protected void Pager_PageIndexChanged(object sender, Umc.Core.Web.Controls.PageIndexChangedEventArgs e)
	{
		Pager.CurrentPageIndex = e.NewPageIndex;

		bind();
	}
}
