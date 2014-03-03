using System;
using System.Web.UI.Design;

namespace Umc.Core.Web.Controls
{
	/// <summary>
	/// 소스제작 : 장현희님
	/// 주소 : http://bullog.net/
	/// 본 Pager 소스는 장현희님의 동의하에 엄준일이 배포하는 블로그 소스에 포함되었습니다.
	/// 본 Pager 소스에 대해 본인은 제작권을 가지고 있지 않음을 알려드립니다.
	/// </summary>
	public class UmcPagerDesigner : ControlDesigner {
		public override string GetDesignTimeHtml() {
			UmcPager pager = (UmcPager)this.Component;
			pager.RenderAtDesignTime();

			return base.GetDesignTimeHtml();
		}
	}
}
