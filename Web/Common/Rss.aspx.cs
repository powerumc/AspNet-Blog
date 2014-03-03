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

using Umc.Core.Web;
using Umc.Core.Modules.Blog;
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Article.Model;
using Umc.Core.Modules.Rss;
using Umc.Core.Modules.Rss.Model;

public partial class Common_Rss : UmcBlogBasePage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if( ! BlogManager.GetInstance().BlogBaseModel.PrivacyModel.PublicRSS ) return;

		Response.ContentType = "text/xml";

		Response.Clear();

		IRss rss = new RssModel20();
		
		IEnumerator eData = ArticleManager.GetInstance().
			GetRecentArticleList( BlogManager.GetInstance().BlogBaseModel.PrivacyModel.LimitRssCount).GetEnumerator();
		
		rss.FillRss<ArticleModel>(eData);

		Response.Write( rss.XmlWriter() );

		Response.Flush();
		Response.End();
	}
}
