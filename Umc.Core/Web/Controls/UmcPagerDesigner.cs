using System;
using System.Web.UI.Design;

namespace Umc.Core.Web.Controls
{
	/// <summary>
	/// �ҽ����� : �������
	/// �ּ� : http://bullog.net/
	/// �� Pager �ҽ��� ��������� �����Ͽ� �������� �����ϴ� ��α� �ҽ��� ���ԵǾ����ϴ�.
	/// �� Pager �ҽ��� ���� ������ ���۱��� ������ ���� ������ �˷��帳�ϴ�.
	/// </summary>
	public class UmcPagerDesigner : ControlDesigner {
		public override string GetDesignTimeHtml() {
			UmcPager pager = (UmcPager)this.Component;
			pager.RenderAtDesignTime();

			return base.GetDesignTimeHtml();
		}
	}
}
