using System;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Web;

namespace Umc.Core.Modules.Trackback
{
	public class TrackbackManager
	{
		private TrackbackManager()
		{
		}

		private static TrackbackManager instance		= null;

		public static TrackbackManager GetInstance()
		{
			lock (typeof(TrackbackManager))
			{
				if( instance == null )
					instance = new TrackbackManager();

				return instance;
			}
		}

		/// <summary>
		/// 트랙백 정보를 저장한다.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public int InsertTrackback(TrackbackModel model)
		{
			return TrackbackAccess.InsertTrackback( model );
		}

		/// <summary>
		/// 트랙백을 삭제한다.
		/// </summary>
		/// <param name="seqNo"></param>
		public void RemoveTrackback(int seqNo)
		{
			TrackbackAccess.RemoveTrackback( seqNo );
		}

		public List<TrackbackModel> GetTrackbackList(int articleNo)
		{
			return TrackbackAccess.GetTrackbackList( articleNo );
		}

		/// <summary>
		/// utf-8 로 트랙백을 보낸다.
		/// </summary>
		/// <param name="targetUrl"></param>
		/// <param name="model"></param>
		/// <returns></returns>
		public bool SendTrackback(string targetUrl, TrackbackModel model)
		{
			string[] data = new string[4]{
				"url=" + model.Url,
				"blog_name=" + model.Blog_Name,
				"title=" + model.Title,
				"exceprt=" + model.Exceprt
			};

			string trackbackData	= string.Join("&", data );

			try
			{
				WebClient wc			= new WebClient();
				wc.Headers.Add( "content-type","application/x-www-form-urlencoded");
				byte[] response			= wc.UploadData( targetUrl, "POST", Encoding.Default.GetBytes(trackbackData));

				string resultXml		= Encoding.UTF8.GetString( response ).Trim();

				XmlDocument doc			= new XmlDocument();
				doc.LoadXml( resultXml );

				if (doc.SelectSingleNode("response/error").InnerXml == "0")
				{
					//TrackbackManager.GetInstance().InsertTrackback( model );
					return true;
				}
				else
					return false;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// 트랙백을 받는다.
		/// </summary>
		/// <param name="articleNo"></param>
		/// <param name="context"></param>
		/// <returns></returns>
		public bool ReceiveTrackback(int articleNo, HttpContext context)
		{
			TrackbackModel model		= new TrackbackModel();
			model.ArticleNo				= articleNo;
			model.Url					= GetParamString( "url", context );
			model.Blog_Name				= GetParamString( "blog_name", context );
			model.Title					= GetParamString( "title", context );
			model.Exceprt				= GetParamString( "exceprt", context );
			model.UserIP				= context.Request.UserHostAddress;

			if (model.Url == null || model.Blog_Name == null || model.Title == null )
			{
				WriteXml("1", "REQUIRED PARAMETER IS MISSING", context);
				return false;
			}

			TrackbackManager.GetInstance().InsertTrackback( model );
			WriteXml("0", "Registed Trackback", context);

			return true;
		}

		private void WriteXml(string error, string msg, HttpContext context)
		{
			context.Response.Clear();
			context.Response.ContentType		= "text/xml";
			context.Response.ContentEncoding	= Encoding.UTF8;

			XmlTextWriter writer	= new XmlTextWriter( context.Response.OutputStream, System.Text.Encoding.UTF8 );

			writer.WriteStartDocument();
			writer.WriteStartElement("response");
				writer.WriteElementString("error", error);
				
				if( msg != string.Empty )
					writer.WriteElementString("message", msg );

			writer.WriteEndElement();
			writer.WriteEndDocument();

			writer.Flush();
			writer.Close();

			context.Response.Flush();
			context.Response.End();
		}

		private string GetParamString(string key, HttpContext context)
		{
			if (context.Request[key] != null)
			{
				string CurrentEncoding = context.Request.ContentEncoding.HeaderName;
				return context.Request[key].ToString();
			}

			return null;
		}
	}
}
