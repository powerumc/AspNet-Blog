using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

using Umc.Core.Data;
using Umc.Core.Util;

namespace Umc.Core.Modules.Snap
{
	/// <summary>
	/// 메인 페이지 관련 Manager
	/// </summary>
	public class SnapManager : IManager
	{
		private SnapManager()
		{ }

		private SnapModel _snapModel;
		private static SnapManager instance = null;

		public SnapModel SnapCollection
		{
			get { return _snapModel; }
		}

		public static SnapManager GetInstance()
		{
			lock (typeof(SnapManager))
			{
				if (instance == null)
				{
					instance = new SnapManager();

					try
					{
						instance.Init();
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
			}

			return instance;
		}

		/// <summary>
		/// Snap을 쿠키에 저장한다.
		/// </summary>
		/// <param name="snap"></param>
		/// <param name="context"></param>
		public void SaveSnap(ComponentArt.Web.UI.Snap snap, HttpContext context)
		{
			string controlName = snap.ID;
			HttpCookie cookie = new HttpCookie(controlName + "_option");

			cookie.Values.Add(controlName + "_coolapsed", snap.IsCollapsed.ToString());
			cookie.Values.Add(controlName + "_dockingContainer", snap.CurrentDockingContainer.ToString());
			cookie.Values.Add(controlName + "_dockingIndex", snap.CurrentDockingIndex.ToString());

			DateTime nowDateTime = DateTime.Now;
			cookie.Expires = nowDateTime.AddDays(30);

			context.Response.AppendCookie(cookie);
		}

		/// <summary>
		/// 쿠키에서 Snap 정보를 가져온다.
		/// </summary>
		/// <param name="snap"></param>
		/// <param name="context"></param>
		public void LoadSnap(ComponentArt.Web.UI.Snap snap, HttpContext context)
		{
			string controlName = snap.ID;

			HttpCookie cookie = context.Request.Cookies[controlName + "_option"];
			if (cookie == null) return;

			snap.IsCollapsed = bool.Parse(cookie.Values[controlName + "_coolapsed"]);
			snap.CurrentDockingContainer = cookie.Values[controlName + "_dockingContainer"].ToString();
			snap.CurrentDockingIndex = int.Parse(cookie.Values[controlName + "_dockingIndex"]);
		}

		public void Init()
		{
			string path = Utility.GetAbsolutePath(UmcConfiguration.Core["SnapXmlPath"]);

			_snapModel	= SnapXml.ReadXml( path );
		}

		#region IManager 멤버

		public void Dispose()
		{
			instance	= null;
		}

		#endregion
	}
}
