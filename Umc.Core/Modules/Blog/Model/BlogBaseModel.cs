using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Umc.Core.Modules.Blog.Model
{
	/// <summary>
	/// 블로그 기본 정보 Model
	/// </summary>
	public class BlogBaseModel
	{
		private BlogModel _blogModel;
		private PrivacyModel _privacyModel;
		private ProfileInfoModel _profileInfoModel;

		public BlogBaseModel()
		{
			_blogModel			= new BlogModel();
			_privacyModel		= new PrivacyModel();
			_profileInfoModel	= new ProfileInfoModel();
		}
		/// <summary>
		/// 블로그 기본 정보
		/// </summary>
		[XmlElement]
		public BlogModel BlogModel
		{
			get { return _blogModel; }
			set { _blogModel = value; }
		}
		/// <summary>
		/// 블로그 프라이버시 정보
		/// </summary>
		[XmlElement]
		public PrivacyModel PrivacyModel
		{
			get { return _privacyModel; }
			set { _privacyModel = value; }
		}
		/// <summary>
		/// 프로필 정보
		/// </summary>
		[XmlElement]
		public ProfileInfoModel ProfileInfoModel
		{
			get { return _profileInfoModel; }
			set { _profileInfoModel = value; }
		}
	}
}
