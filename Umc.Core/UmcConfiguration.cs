using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Umc.Core
{
	/// <summary>
	/// ȯ�� ���� ������ �����´�..
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
		/// Umc.Web Configuration �� �����´�.
		/// </summary>
		public static NameValueCollection Web
		{
			get
			{
				return (NameValueCollection)ConfigurationManager.GetSection("Umc.Web");
			}
		}

		/// <summary>
		/// Umc.Core Configuration �� �����´�.
		/// </summary>
		public static NameValueCollection Core
		{
			get
			{
				return (NameValueCollection)ConfigurationManager.GetSection("Umc.Core");
			}
		}

		/// <summary>
		/// Umc.Message COnfiguration �� �����´�.
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
