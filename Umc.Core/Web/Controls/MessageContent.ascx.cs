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

using Umc.Core;
using Umc.Core.Web;
namespace Umc.Core.Web.Controls
{
	public partial class MessageContentControl : UmcContentsCommonPage
	{
		private string message;

		public string Message
		{
			get
			{
				if (UmcConfiguration.Message[message] != null)
					return UmcConfiguration.Message[message];

				return message;
			}
			set { message = value; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}