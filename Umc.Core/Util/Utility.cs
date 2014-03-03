using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Umc.Core.Modules.Blog;

namespace Umc.Core.Util
{
	public class Utility
	{
		/// <summary>
		/// �����θ� ���� ��η� �ٲپ��ش�.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string GetAbsolutePath(string path)
		{
			return HttpContext.Current.Server.MapPath("/")+path;
		}

		/// <summary>
		/// UpdatePanel ��Ʈ�Ѿȿ��� Alert â�� ��ﶧ ����Ѵ�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="msg"></param>
		public static void JS_Alert(object sender, string msg)
		{
			JS_Alert( sender, "UmcScript", msg );
		}

		public static void JS_Alert(object sender, string key, string msg)
		{
			// Umc.Message.config �� �޽����� �ִ��� ���� �˻��Ѵ�
			string codeMessage	= UmcConfiguration.Message[msg];

			string message		= string.Empty;

			if (codeMessage == null)
				message			= msg;
			else
				message			= codeMessage;

			JsCall(sender, key, string.Format("alert('{0}');", message));
		}

		public static void JsCall(object sender, string message)
		{
			JsCall( sender, "UmcScript", message );
		}
		public static void JsCall(object sender, string key, string message)
		{
			ScriptManager.RegisterStartupScript(
				(Control)sender, sender.GetType(), key, message, true);
		}

		public static void JS_SelfClose(object sender)
		{
			JsCall(sender, "self.close();");
		}

		/// <summary>
		/// ��ƼŬ url �� �����.
		/// </summary>
		/// <param name="articleNo"></param>
		/// <returns></returns>
		public static string MakeArticleUrl(int articleNo)
		{
			return BlogManager.GetInstance().BlogBaseModel.BlogModel.Url + "/article_"+articleNo.ToString()+".aspx";
		}

		public static string MakeTrackbackUrl(int articleNo)
		{
			return BlogManager.GetInstance().BlogBaseModel.BlogModel.Url + "/trackback_" + articleNo.ToString() + ".aspx";
		}

		public static string MakeTagUrl(string tagName)
		{
			return BlogManager.GetInstance().BlogBaseModel.BlogModel.Url + "/tag_" + tagName + ".aspx";
		}

		/// <summary>
		/// ���ڿ��� char ������ �ڸ���.
		/// </summary>
		/// <param name="orgText"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		public static string CutString(string orgText, int max)
		{
			string result = string.Empty;
			if (orgText != null && orgText != string.Empty)
			{
				int nByte = 0;
				char[] cArr = orgText.ToCharArray();
				for (int i = 0; i < cArr.Length; i++)
				{
					int keyCode = Convert.ToInt32(cArr[i]);
					if (keyCode < 0 || keyCode >= 128)
					{
						nByte += 2; //�ѱ� 2byte
					}
					else
					{
						nByte++;  //������ 1����Ʈ
					}



					if (nByte <= max)
					{
						result += orgText.Substring(i, 1);
					}
					else
					{
						result = result.Trim();
						break;
					}
				}
			}
			return result;
		}

		/// <summary>
		/// �ؽ�Ʈ ���̸� �����´�. �ѱ��� 2Byte ó��
		/// </summary>
		/// <param name="ordText"></param>
		/// <returns></returns>
		public static int LengthString(string orgText)
		{
			string result = string.Empty;
			int nByte = 0;

			if (orgText != null && orgText != string.Empty)
			{
				char[] cArr = orgText.ToCharArray();
				for (int i = 0; i < cArr.Length; i++)
				{
					int keyCode = Convert.ToInt32(cArr[i]);
					if (keyCode < 0 || keyCode >= 128)
					{
						nByte += 2; //�ѱ� 2byte
					}
					else
					{
						nByte++;  //������ 1����Ʈ
					}
				}
			}
			
			return nByte;
		}
	}
}
