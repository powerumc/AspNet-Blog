using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing;

using Umc.Core.Util;
using Umc.Core.Modules.Blog;
using Umc.Core.Modules.Blog.Model;

namespace Umc.Core.Modules.Blog
{
	/// <summary>
	/// 블로그 관리자
	/// </summary>
	public class BlogManager : IManager
	{
		private static BlogManager _instance	= null;
		private BlogBaseModel _blogBaseModel	= null;

		private BlogManager()
		{
		}
		/// <summary>
		/// 기본정보를 담는 3 개의 Model 클래스를 반환하다
		/// </summary>
		public BlogBaseModel BlogBaseModel
		{
			get { return _blogBaseModel; }
		}

		public static BlogManager GetInstance()
		{
			lock (typeof(BlogManager))
			{
				if (_instance == null)
				{
					_instance = new BlogManager();
					_instance.Init();
				}
			}

			return _instance;
		}
		/// <summary>
		/// Xml 의 블로그 기본 정보를 설정한다
		/// </summary>
		public void Init()
		{
			string path		= Utility.GetAbsolutePath(UmcConfiguration.Core["BlogXmlPath"]);
			_blogBaseModel	= BlogManager.GetInstance().ReadBlogBaseInfo(path);
		}

		#region 블로그 XML 
		/// <summary>
		/// 블로그 기본 정보를 Xml 로 부터 읽는다
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public BlogBaseModel ReadBlogBaseInfo(string path)
		{
			XmlTextReader reader = null;
			BlogBaseModel model = new BlogBaseModel();

			try
			{
				reader = new XmlTextReader(path);
				XmlSerializer serializer = new XmlSerializer(typeof(BlogBaseModel));
				return (BlogBaseModel)serializer.Deserialize(reader);
			}
			catch					// Xml 이 없거나 잘못된 경우 새로 만든다
			{
				WriteBlogBaseInfo(path, model);
				return model;
			}
			finally
			{
				reader.Close();
				model = null;
			}
		}
		/// <summary>
		/// 블로그 기본 정보를 저장한다
		/// </summary>
		/// <param name="path"></param>
		/// <param name="model"></param>
		public void WriteBlogBaseInfo(string path, BlogBaseModel model)
		{
			XmlTextWriter writer = null;

			try
			{
				writer = new XmlTextWriter(path, Encoding.Default);

				writer.Formatting = Formatting.Indented;

				XmlSerializer serializer = new XmlSerializer(typeof(BlogBaseModel));
				serializer.Serialize(writer, model);
			}
			catch (Exception ex)
			{
				throw new Exception("Blog.Xml 쓰는중 오류발생" + ex.Message);
			}
			finally
			{
				writer.Close();
			}
		}
		#endregion

		public Bitmap GetMyPicture()
		{
			return BlogAccess.GetMyPicture();
		}

		public string GetMyPictureForImgTag()
		{
			return BlogAccess.GetMyPictureForImgTag();
		}

		#region IManager 멤버

		public void Dispose()
		{
			_instance	= null;
		}

		#endregion
	}
}
