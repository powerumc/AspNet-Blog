using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Umc.Core.Authenticate;
using Umc.Core.WebAdmin.Sitemap;

namespace Umc.Core.WebAdmin 
{
	/// <summary>
	/// 관리자 사이트 Main Page Template
	/// aspx 페이지는 현재 클래스를 상속받으세요
	/// </summary>
	public class WebAdminTemplate : System.Web.UI.Page
	{
		protected string ModuleID
		{
			get
			{
				return GetParamString(Parameters.PARAM_MODULE_ID);
			}
		}

		protected ISitemap sitemap;
		private ISitemap _currentSitemapInfo;

		public ISitemap CurrentSitemapInfo
		{
			get { return _currentSitemapInfo; }
			set { _currentSitemapInfo = value; }
		}

		public SItemapModule CurrentModuleInfo
		{
			get { return (SItemapModule)CurrentSitemapInfo; }
		}

		public UserInfo CurrentUserInfo
		{
			get { return Authenticator.GetInstance().GetUserInfo(Context); }
		}

		protected void AddNodes(ISitemap sitemap, Sitemap_Node node)
		{
			IEnumerator currentSitemap = sitemap.GetEnumerator();

			while (currentSitemap.MoveNext())
			{
				ISitemap newSitemap = (ISitemap)currentSitemap.Current;
				Sitemap_Node newNode = new Sitemap_Node(newSitemap);
				newNode.NavigateUrl	 = string.Format("{0}?id={1}",Request.Path,newSitemap.ID);
				if(CurrentSitemapInfo != null && CurrentSitemapInfo.ID == newSitemap.ID ) newNode.Selected = true;
				node.ChildNodes.Add(newNode);
				AddNodes(newSitemap, newNode);
			}
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			if( CurrentUserInfo.Level != LevelAttribute.ADMIN )
				Response.Redirect( SitemapManager.GetInstance().GetSitemapByID("ADMIN1").GetInitParam("page.admin.login") );
			

			Response.Cache.SetNoStore();
			Response.Expires = 0;
			Response.AddHeader("pragma","no-cache");

			ClientScript.RegisterClientScriptBlock(this.GetType(),"BaseScript",
				"<link href=\"/Common/Css/global.css\" rel=\"stylesheet\" type=\"text/css\" />"
				+"<script type=\"text/javascript\" src=\"/Common/Js/Script.aculo.us/lib/prototype.js\"></script>"
				+"<script type=\"text/javascript\" src=\"/Common/Js/Script.aculo.us/src/scriptaculous.js\"></script>"
				+"<script type=\"text/javascript\" src=\"/Common/Js/Blog.js\"></script>"
				+"<script type=\"text/javascript\" src=\"/Common/Js/greybox/AJS.js\"></script>"
				+"<script type=\"text/javascript\" src=\"/Common/Js/greybox/AJS_fx.js\"></script>"
				+"<script type=\"text/javascript\" src=\"/Common/Js/greybox/gb_scripts.js\"></script>"
				+"<link href=\"/Common/Js/greybox/gb_styles.css\" rel=\"stylesheet\" type=\"text/css\" />");
		}

		protected string GetParamString(string id)
		{
			return GetParamString( id, null );
		}

		protected string GetParamString(string id, string def)
		{
			return (Request[id] != null) ? Request[id].ToString() : def;
		}

		protected int GetParamInt(string query)
		{
			return GetParamInt(query, -1);
		}

		protected int GetParamInt(string query, int def)
		{
			if (Request[query] != null)
				return int.Parse(Request[query].ToString());
			else
				return def;
		}
	}
}
