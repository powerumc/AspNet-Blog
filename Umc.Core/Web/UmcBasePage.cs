using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Umc.Core.Web;
using Umc.Core.Modules.Snap;
using Umc.Core.Modules.Article.Model;
using Umc.Core.Modules.Category.Model;
using Umc.Core.Modules.Blog;
using Umc.Core.Authenticate;

namespace Umc.Core.Web
{
	public abstract class UmcBlogBasePage : System.Web.UI.Page
	{
		//private string _contentViewControl;

		/// <summary>
		/// Content 컨트롤에 표시될 컨트롤
		/// </summary>
		public string ContentViewControl
		{
			get { return (string)ViewState["CurrentContentViewControl"] ?? null; }
			set { IsUmcPostBack=false; ViewState["CurrentContentViewControl"] = value; }
		}

		/// <summary>
		/// 카테고리를 클릭했을경우 넘겨받는 프로퍼티
		/// </summary>
		public CategoryNodeValue CurrentCategoryNodeValue
		{
			get { return (CategoryNodeValue)ViewState["CurrentCategoryNodeValue"] ?? null; }
			set { ViewState["CurrentCategoryNodeValue"] = value; }
		}

		public int CurrentArticleNo
		{
			get { return ViewState["CurrentArticleNo"] != null ? (int)ViewState["CurrentArticleNo"] : -1; }
			set { ViewState["CurrentArticleNo"] = value; }
		}

		public bool IsUpdate
		{
			get { return ViewState["IsUpdate"] != null ? (bool)ViewState["IsUpdate"] : false; }
			set { ViewState["IsUpdate"] = value; }
		}

		public bool IsUmcPostBack
		{
			get { return ViewState["IsUmcPostBack"] != null ? (bool)ViewState["IsUmcPostBack"] : false; }
			set { ViewState["IsUmcPostBack"] = value; }
		}

		public UmcBlogBasePage()
		{ }

		public virtual void Update()
		{
			FindContentSnap(Form);
		}

		public virtual void Update(string viewControl)
		{
			ContentViewControl	= viewControl;
			Update();
		}

		private void FindContentSnap(Control control)
		{
			foreach (Control child in control.Controls)
			{
				if (child.ID == "placeContent")
				{
					child.Controls.Clear();
					if (ContentViewControl != null)
					{
						child.Controls.AddAt(0, LoadControl(ContentViewControl));
						return;
					}
				}
				else
				{
					FindContentSnap(child);
				}
			}
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
#if(DEBUG)
			SnapManager.GetInstance().Dispose();
			SnapManager.GetInstance().Init();
#endif
			SetSnapTemplate();
			SetNoCache();
			SetTitle();

			ClientScript.RegisterClientScriptBlock( this.GetType(), "BaseScript",
				"<link href=\"/Common/Css/baseStyle.css\" rel=\"stylesheet\" type=\"text/css\" />"
				+"<link href=\"/Common/Css/Snap.css\" rel=\"stylesheet\" type=\"text/css\" />"
				+"<link href=\"/Common/Css/global.css\" rel=\"stylesheet\" type=\"text/css\" />"
				+"<script type=\"text/javascript\" src=\"/common/js/sha1.js\"></script>"
				+"<script type=\"text/javascript\" src=\"/common/js/blog.js\"></script>"
				+"<script type=\"text/javascript\" src=\"/Common/Js/greybox/AJS.js\"></script>"
				+"<script type=\"text/javascript\" src=\"/Common/Js/greybox/AJS_fx.js\"></script>"
				+"<script type=\"text/javascript\" src=\"/Common/Js/greybox/gb_scripts.js\"></script>"
				+"<link href=\"/Common/Js/greybox/gb_styles.css\" rel=\"stylesheet\" type=\"text/css\" />");
		}

		private void SetNoCache()
		{
			Response.Cache.SetNoStore();
			Response.Expires = 0;
			Response.AppendHeader("pragma","no-cache");
		}
		private void SetTitle()
		{
			//string titleScript	= string.Format("<script>document.title='{0}';</script>",
			//    BlogManager.GetInstance().BlogBaseModel.BlogModel.Title);
			//ClientScript.RegisterClientScriptBlock( this.GetType(), "Title", titleScript );
			Page.Title				= BlogManager.GetInstance().BlogBaseModel.BlogModel.Title;
		}

		#region Snap 불러오기
		protected void SetSnapTemplate()
		{
			foreach (DictionaryEntry dic in SnapManager.GetInstance().SnapCollection)
			{
				SnapModel snapModel = SnapManager.GetInstance().SnapCollection[dic.Key.ToString()];
				if( string.IsNullOrEmpty(snapModel.ViewControl) ) continue;
				
				UmcContentsCommonPage template = (UmcContentsCommonPage)LoadControl(snapModel.ViewControl.ToString());
				template.SnapModel	= snapModel;

				//if (FindControl("ph_" + snapModel.ID.ToString()) == null) return;
				//((PlaceHolder)FindControl("ph_" + snapModel.ID.ToString()))
				//    .Controls.Add(template);
				
				if (FindControl("phSnaps") == null) return;

				((PlaceHolder)FindControl("phSnaps")).Controls.Add(template);

				if (!IsPostBack)
				{
					//if (FindControl("snap_" + snapModel.ID.ToString()) == null) return;
					ComponentArt.Web.UI.Snap snapTemplate = (ComponentArt.Web.UI.Snap)template.FindControl("snap_" + snapModel.ID.ToString());
					SnapManager.GetInstance().LoadSnap(snapTemplate, Context);
				}
			}
		}
		#endregion

		protected void SnapSave()
		{
			SnapFindControl(Page.Form);
		}

		private void SnapFindControl(Control control)
		{
			foreach (Control childControl in control.Controls)
			{
				SnapFindControl(childControl);
				if (childControl is ComponentArt.Web.UI.Snap)
				{
					SnapManager.GetInstance().SaveSnap((ComponentArt.Web.UI.Snap)childControl, Context);
				}
			}
		}

		protected string GetParamString(string query)
		{
			return GetParamString(query, null);
		}

		protected string GetParamString(string query, string def)
		{
			if( Request[ query ] != null )
				return Request[ query ].ToString();
			else
				return def;
		}

		protected int GetParamInt(string query)
		{
			return GetParamInt( query, -1 );
		}

		protected int GetParamInt(string query, int def)
		{
			if (Request[query] != null)
				return int.Parse(Request[query].ToString());
			else
				return def;
		}

		/// <summary>
		/// 현재 유저 정보
		/// </summary>
		public UserInfo CurrentUserInfo
		{
			get { return Authenticator.GetInstance().GetUserInfo(Context); }
		}

		/// <summary>
		/// 유저가 로그인을 했으면 true 하지 않았으면 false
		/// </summary>
		public bool IsLogin
		{
			get { return Authenticator.GetInstance().GetUserInfo(Context).EMail != null; }
		}
	}
}