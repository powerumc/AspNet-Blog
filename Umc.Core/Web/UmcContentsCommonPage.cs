using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Reflection;

using Umc.Core.Modules.Category;
using Umc.Core.Modules.Category.Model;
using Umc.Core.Modules.Article.Model;
using Umc.Core.Modules.Snap;
using Umc.Core.Authenticate;
using Umc.Core.Web.Controls;

namespace Umc.Core.Web
{
	public class UmcContentsCommonPage : UserControl
	{
		private string _viewControl;
		//private string _contentViewControl;

		public string ViewControl
		{
			get { return _viewControl; }
			set { _viewControl = value;}
		}

		public string ContentViewControl
		{
			get { return ((UmcBlogBasePage)Page).ContentViewControl; }
			set { ((UmcBlogBasePage)Page).ContentViewControl = value; }
		}

		public CategoryNodeValue CurrentCategoryNodeValue
		{
			get { return ((UmcBlogBasePage)Page).CurrentCategoryNodeValue; }
			set { ((UmcBlogBasePage)Page).CurrentCategoryNodeValue = value; }
		}

		public int CurrentArticleNo
		{
			get { return ((UmcBlogBasePage)Page).CurrentArticleNo; }
			set { ((UmcBlogBasePage)Page).CurrentArticleNo = value; }
		}

		public void Update()
		{
			((UmcBlogBasePage)Page).Update(ContentViewControl);
		}

		public void Update(string viewControl)
		{
			ContentViewControl = ContentViewControl;
			Update();
		}

		private SnapModel snapModel;
		public SnapModel SnapModel
		{
			get { return snapModel; }
			set { snapModel = value; }
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

		public UserInfo CurrentUserInfo
		{
			get { return Authenticator.GetInstance().GetUserInfo(Context); }
		}

		public bool IsLogin
		{
			get { return Authenticator.GetInstance().GetUserInfo(Context).EMail != null; }
		}

		public void SetMessageContent(string msg)
		{
			MessageContentControl template		= 
				(MessageContentControl)LoadControl( SnapManager.GetInstance().SnapCollection[ "Message" ].ContentControl );

			template.Message					= msg;

			this.Controls.Add(template);
		}
	}
}
