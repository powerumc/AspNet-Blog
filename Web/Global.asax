<%@ Application Language="C#" %>
<%@ Import Namespace="Umc.Core.Modules.Snap" %>
<%@ Import Namespace="Umc.Core.WebAdmin.Sitemap" %>
<%@ Import Namespace="Umc.Core.Modules.Blog.Model" %>
<%@ Import Namespace="Umc.Core.Modules.Blog" %>
<%@ Import Namespace="Umc.Core" %>
<%@ Import Namespace="Umc.Core.Modules.Article" %>
<%@ Import Namespace="Umc.Core.Logger" %>
<%@ Import Namespace="Umc.Core.Logger.Model" %>
<%@ Import Namespace="Umc.Core.Modules.Breaker" %>
<script runat="server">

	private BlogManager _blogManager		= null;
	private SnapManager	_snapManager		= null;
	private SitemapManager _sitemapManager	= null;
	
    void Application_Start(object sender, EventArgs e) 
    {
		_blogManager		= BlogManager.GetInstance();
        _snapManager		= SnapManager.GetInstance();
		_sitemapManager		= SitemapManager.GetInstance();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  응용 프로그램이 종료될 때 실행되는 코드입니다.

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 처리되지 않은 오류가 발생할 때 실행되는 코드입니다.

    }

    void Session_Start(object sender, EventArgs e) 
    {
		string userip			= Request.UserHostAddress;		
		string urlRefer			= Request.RawUrl != null ? Request.Url.ToString() : null;
		
		if (BreakerManager.GetInstance().CompareBreakerIP(userip))
		{
			string breakerUrl	= SitemapManager.GetInstance().GetSitemapByID("ADMIN1").GetInitParam("page.breaker");
			LoggerManager.GetInstance().InsertConnectionLog( new ConnectionLogModel( Session.SessionID, "차단됨", userip ) );
			
			Response.Redirect( breakerUrl );
		}
		
        LoggerManager.GetInstance().InsertConnectionLog( new ConnectionLogModel( Session.SessionID, urlRefer, userip ) );
    }

    void Session_End(object sender, EventArgs e) 
    {
        // 새 세션이 끝날 때 실행되는 코드입니다. 
        // 참고: Web.config 파일에서 sessionstate 모드가 InProc로 설정되어 있는 경우에만
        // Session_End 이벤트가 발생합니다. 세션 모드가 StateServer 또는 SQLServer로 
        // 설정되어 있는 경우에는 이 이벤트가 발생하지 않습니다.

    }
       
</script>
