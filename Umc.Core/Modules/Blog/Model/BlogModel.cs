using System;
using System.Collections.Generic;
using System.Text;

using Umc.Core.Modules.Blog;

namespace Umc.Core.Modules.Blog.Model
{
	/// <summary>
	/// ��α� �⺻ ����
	/// </summary>
	[Serializable]
	public class BlogModel
	{
		//<Title>UMC WORLD</Title>
		//<BlogAddress>http://umc.net</BlogAddress>
		//<Picture>/common/images.loading3.gif</Picture>
		//<Name>������</Name>
		//<NickName>����</NickName>
		//<Introduction>�Ұ��Դϴ�</Introduction>
		//<Address>�����</Address>
		//<Hobby>��ǻ��</Hobby>
		//<Gender>Man</Gender>
		//<Alarm>True</Alarm>
		//<AutoClip>True</AutoClip>
		private string _title				= "UMC WORLD";
		private string _url					= "http://localhost:9090";
		private string _email				= "umjunil@hotmail.com";
		private string _picture				= string.Empty;
		private string _name				= "������";
		private string _nickName			= "����";
		private string _introduction		= "�ȳ��ϼ���. ��α׿� ���Ű��� ȯ���մϴ�";
		private string _address				= "������";
		private string _hobby				= "��ǻ��";
		private BlogConst.Gender _gender	= BlogConst.Gender.Man;
		private bool _alram					= true;
		private bool _autoClip				= false;
		private int _postCount				= 3;
		private int _recentCommentListCount	= 5;
		private int _recentArticleListCount	= 5;
		private bool _useEmoticon			= true;
		private int _peridoNewIcon			= 1;

		/// <summary>
		/// ��α� ����
		/// </summary>
		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}
		/// <summary>
		/// ��α� URL
		/// </summary>
		public string Url
		{
			get { return _url; }
			set { _url = value; }
		}
		public string EMail
		{
			get { return _email; }
			set { _email = value; }
		}
		/// <summary>
		/// �� ����
		/// </summary>
		public string Picture
		{
			get { return _picture; }
			set { _picture = value; }
		}
		/// <summary>
		/// �̸�
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		/// <summary>
		/// ����
		/// </summary>
		public string NickName
		{
			get { return _nickName; }
			set { _nickName = value; }
		}
		/// <summary>
		/// �Ұ�
		/// </summary>
		public string Introduction
		{
			get { return _introduction; }
			set { _introduction = value; }
		}
		/// <summary>
		/// �ּ�
		/// </summary>
		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}
		/// <summary>
		/// ���
		/// </summary>
		public string Hobby
		{
			get { return _hobby; }
			set { _hobby = value; }
		}
		/// <summary>
		/// ����
		/// </summary>
		public BlogConst.Gender Gender
		{
			get { return _gender; }
			set { _gender = value; }
		}
		/// <summary>
		/// ����̳� �Խ��� �� ��Ͻ� �̸��Ϸ� �˸�
		/// </summary>
		public bool Alarm
		{
			get { return _alram; }
			set { _alram = value; }
		}
		/// <summary>
		/// ����Ʈ ����� Ŭ�����忡 ����Ʈ ����
		/// </summary>
		public bool AutoClip
		{
			get { return _autoClip; }
			set { _autoClip = value; }
		}
		/// <summary>
		/// �������� ����Ʈ ����
		/// </summary>
		public int PostCount
		{
			get { return _postCount; }
			set { _postCount = value; }
		}

		/// <summary>
		/// �ֽ� ��� ����Ʈ ������ ����
		/// </summary>
		public int RecentCommentListCount
		{
			get { return _recentCommentListCount; }
			set { _recentCommentListCount = value; }
		}

		public int RecentArticleListCount
		{
			get { return _recentArticleListCount; }
			set { _recentArticleListCount = value; }
		}

		public bool UseEmoticon
		{
			get { return _useEmoticon; }
			set { _useEmoticon = value; }
		}

		public int PeridoNewIcon
		{
			get { return _peridoNewIcon; }
			set { _peridoNewIcon = value; }
		}
	}
}
