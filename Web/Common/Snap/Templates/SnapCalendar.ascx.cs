using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Umc.Core.Util;
using Umc.Core.Modules.Article;
public partial class Common_Snap_Templates_SnapCalendar : Umc.Core.Web.UmcContentsCommonPage
{
	private NameValueCollection cal;

	protected void Page_Load(object sender, EventArgs e)
	{
		if( IsPostBack) return;

		bindDate( DateTime.Now );
	}

	protected void cldCalendar_OnSelectionChanged(object sender, EventArgs e)
	{
		bindDate( cldCalendar.SelectedDate );

		string date = cldCalendar.SelectedDate.ToShortDateString();
		string script = string.Format("setContent('Category&{0}');",
			"date=" + date);
		Utility.JsCall(sender, script);
	}

	private void bindDate(DateTime date)
	{
		string currentDate = date.Year.ToString() + "/" + date.Month.ToString();

		cal = ArticleManager.GetInstance().GetArticleListGroupByDate(currentDate);
	}

	protected void cldCalendar_DayRender(object sender, DayRenderEventArgs e)
	{
		if( cal == null ) bindDate( cldCalendar.VisibleDate );

		string currentDate	= e.Day.Date.ToString("yyyy/MM/dd").Replace("-","/");

		if (cldCalendar.SelectedDate == e.Day.Date)
		{
			e.Cell.Attributes["onclick"] = "return false";
		}

		if (cal[currentDate] != null)
		{
			e.Cell.Font.Bold = true;
			e.Cell.ForeColor = System.Drawing.Color.Red;
		}
		else
		{
			e.Cell.Attributes["onclick"] = "return false";
		}
	}
	protected void cldCalendar_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
	{
		bindDate( e.NewDate );
	}
}
