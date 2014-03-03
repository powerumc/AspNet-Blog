using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Umc.Core.WebAdmin;
using Umc.Core.Modules.Emoticon;

public partial class WebAdmin_07Emoticon_Templates_EmoticonList : WebAdminCommonTemplate
{
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
		List<EmoticonModel> bindModel	= new List<EmoticonModel>();

		bindModel						= EmoticonManager.GetInstance().Model;

		dlList.DataSource				= bindModel;
		dlList.DataBind();
	}

	protected string EmoticonImage(string fileName)
	{
		return string.Format("{0}/Emoticon/{1}",
			Umc.Core.UmcConfiguration.Core["repository.dir"],
			fileName);
	}


	protected void lnkWriteOK_Click(object sender, EventArgs e)
	{
		
	}
	protected void dlList_ItemCommand(object source, DataListCommandEventArgs e)
	{
		int seqNo		=int.Parse(e.CommandArgument.ToString());

		if (e.CommandName == "remove")
		{
			EmoticonManager.GetInstance().RemoveEmoticon( seqNo );
		}

		EmoticonManager.GetInstance().Dispose();
		Response.Redirect( Request.Url.ToString() );
	}
	protected void dlList_ItemDataBound(object sender, DataListItemEventArgs e)
	{
		if( !(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem )) return;

		LinkButton lnkRemove			= (LinkButton)e.Item.FindControl("lnkRemove");

		lnkRemove.Attributes["onclick"]	= string.Format("return confirm('{0}');",
			Umc.Core.UmcConfiguration.Message[EmoticonConst.MESSAGE_EMOTICON_REMOVE_REALLY ]);
	}
	protected void lnkRefresh_Click(object sender, EventArgs e)
	{
		// 처음에는 리프래쉬 없도록 하였으나, 리프레쉬가 없게되면 UpdatePanel의 update 이벤트 이후
		// GreyBox 스크립트가 두번째 부터 먹지않는다.
		EmoticonManager.GetInstance().Dispose();
		Response.Redirect(Request.Url.ToString());
	}
}
