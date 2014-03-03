using System;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Umc.Core.WebAdmin;
using Umc.Core.Modules.Blog;
using Umc.Core.Modules.Blog.Model;
using Umc.Core.Util;
using Umc.Core.WebAdmin.Sitemap;

public partial class WebAdmin_CommonPlaceHolder : WebAdminCommonTemplate
{
	private ISitemap _sitemap;

	protected void Page_Load(object sender, EventArgs e)
	{
		
	}

	/// <summary>
	/// Sitemap 을 받아서 컨트롤과 Title 을 초기화에 사용된다
	/// </summary>
	public ISitemap Sitemap
	{
		get { return _sitemap; }
		set { _sitemap = value; }
	}

	/// <summary>
	/// Sitemap 의 ModuleID 값
	/// </summary>
	public string ModuleID
	{
		get { return lblModuleID.Text; }
	}

	/// <summary>
	/// UpdatePanel 을 갱신한다
	/// </summary>
	public void Update()
	{
		if(Sitemap == null) return;

		string path	= Sitemap.ViewControl;

		if (path!=null && path != string.Empty)
		{
			this.PlaceHolder1.Controls.Add(
				LoadControl( path ) );
		}
		lblSitemapPath.Text = SitemapManager.GetInstance().GetNavigateString(_sitemap);
		lblModuleID.Text	= _sitemap.ID;

		//this.panelCommonMainPlace.Update();
	}

	/// <summary>
	/// 콘트롤이 들어갈 PlaceHolder를 Clear 한다
	/// </summary>
	public void Clear()
	{
		this.PlaceHolder1.Controls.Clear();
	}
}
