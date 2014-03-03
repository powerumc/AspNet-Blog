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
	/// ��α� ������
	/// </summary>
	public class BlogManager : IManager
	{
		private static BlogManager _instance	= null;
		private BlogBaseModel _blogBaseModel	= null;

		private BlogManager()
		{
		}
		/// <summary>
		/// �⺻������ ��� 3 ���� Model Ŭ������ ��ȯ�ϴ�
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
		/// Xml �� ��α� �⺻ ������ �����Ѵ�
		/// </summary>
		public void Init()
		{
			string path		= Utility.GetAbsolutePath(UmcConfiguration.Core["BlogXmlPath"]);
			_blogBaseModel	= BlogManager.GetInstance().ReadBlogBaseInfo(path);
		}

		#region ��α� XML 
		/// <summary>
		/// ��α� �⺻ ������ Xml �� ���� �д´�
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
			catch					// Xml �� ���ų� �߸��� ��� ���� �����
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
		/// ��α� �⺻ ������ �����Ѵ�
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
				throw new Exception("Blog.Xml ������ �����߻�" + ex.Message);
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

		#region IManager ���

		public void Dispose()
		{
			_instance	= null;
		}

		#endregion
	}
}
