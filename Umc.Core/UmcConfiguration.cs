using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Umc.Core
{
	/// <summary>
	/// 환경 설정 내용을 가져온다..
	/// </summary>
	public class UmcConfiguration
	{
		public static string ConnectionString
		{
			get
			{
				return ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
			}
		}

		/// <summary>
		/// Umc.Web Configuration 을 가져온다.
		/// </summary>
		public static NameValueCollection Web
		{
			get
			{
				return (NameValueCollection)ConfigurationManager.GetSection("Umc.Web");
			}
		}

		/// <summary>
		/// Umc.Core Configuration 을 가져온다.
		/// </summary>
		public static NameValueCollection Core
		{
			get
			{
				return (NameValueCollection)ConfigurationManager.GetSection("Umc.Core");
			}
		}

		/// <summary>
		/// Umc.Message COnfiguration 을 가져온다.
		/// </summary>
		public static NameValueCollection Message
		{
			get
			{
				return (NameValueCollection)ConfigurationManager.GetSection("Umc.Message");
			}
		}
	}
}
