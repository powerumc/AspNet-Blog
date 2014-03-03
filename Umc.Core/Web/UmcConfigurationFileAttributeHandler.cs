using System;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Web
{
	/// <summary>
	/// Web.Config 의 file 특성을 처리하는 핸들러
	/// </summary>
	public class UmcConfigurationFileAttributeHandler 
		: System.Configuration.NameValueFileSectionHandler
	{
		public UmcConfigurationFileAttributeHandler()
		{
		}
	}
}
