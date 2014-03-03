using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Umc.Core.WebAdmin.Sitemap;

namespace Umc.Core.WebAdmin
{
	/// <summary>
	/// 관리자 사이트에서의 User Control은 현재 컨트롤을 상속받아 구현하세요
	/// </summary>
	public class WebAdminCommonTemplate : System.Web.UI.UserControl
	{
		protected string ViewMode
		{
			get { return GetParamString(Parameters.PARAM_VIEWMODE); }
		}

		protected string ModuleID
		{
			get
			{
				return GetParamString( Parameters.PARAM_MODULE_ID );
			}
		}

		public ISitemap CurrentSitemapInfo
		{
			get { return ((WebAdminTemplate)Page).CurrentSitemapInfo; }
			set { ((WebAdminTemplate)Page).CurrentSitemapInfo = value; }
		}

		public SItemapModule CurrentModuleInfo
		{
			get { return (SItemapModule)CurrentSitemapInfo; }
		}

		public delegate void UmcRegisterEventHandler(object sender, EventArgs e);
		public event UmcRegisterEventHandler UmcRegisterEvent;

		protected void OnRegisterEvent(object sender, EventArgs e)
		{
			if(UmcRegisterEvent != null)
				UmcRegisterEvent( sender, e);
		}

		protected string GetParamString(string query)
		{
			return GetParamString(query, null);
		}

		protected string GetParamString(string query, string def)
		{
			if (Request[query] != null)
				return Request[query].ToString();
			else
				return def;
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
