using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Umc.Core.Modules.Blog;
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Trackback;

namespace Umc.Core.Web
{
	public class UmcHttpModule : IHttpModule
	{
		#region IHttpModule ¸â¹ö

		public void Dispose()
		{
		
		}

		public void Init(HttpApplication context)
		{
			context.BeginRequest += new EventHandler(Umc_BeginRequest);
		}

		#endregion

		string[] Command = new string[] {
				"/article_",
				"/tag_",
				"/trackback_"
			};
		private void Umc_BeginRequest(object sender, EventArgs e)
		{
			string url				= "/default.aspx";

			string localPath = HttpContext.Current.Request.Url.LocalPath;

			foreach (string command in Command)
			{
				if (localPath.ToLower().StartsWith( command ))
				{
					localPath = localPath.Remove(0, command.Length);

					int dotIndex		= localPath.LastIndexOf(".");
					string[] filename	= new string[2];
					filename[0]			= localPath.Substring(0, dotIndex);
					filename[1]			= localPath.Substring(dotIndex+1, localPath.Length - dotIndex-1);

					if( filename[1].ToLower() != "aspx" ) return;

					switch (command)
					{
						case "/article_" : 
							url = string.Format("/default.aspx?{0}={1}",
							ArticleConst.PARAM_ARTICLENO, filename[0] );
							break;
						case "/tag_" :
							url = string.Format("/default.aspx?{0}={1}",
							ArticleConst.PARAM_TAG, filename[0]);
							break;
						case "/trackback_" :
							url = string.Format("/common/trackback.aspx?{0}={1}",
								TrackbackConst.PARAM_TRACKBACK, filename[0] );
							break;
					}

					HttpContext.Current.RewritePath(url);
				}
			}
		}
	}
}
