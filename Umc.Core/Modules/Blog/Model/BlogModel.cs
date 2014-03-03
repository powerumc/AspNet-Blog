using System;
using System.Collections.Generic;
using System.Text;

using Umc.Core.Modules.Blog;

namespace Umc.Core.Modules.Blog.Model
{
	/// <summary>
	/// 블로그 기본 정보
	/// </summary>
	[Serializable]
	public class BlogModel
	{
		//<Title>UMC WORLD</Title>
		//<BlogAddress>http://umc.net</BlogAddress>
		//<Picture>/common/images.loading3.gif</Picture>
		//<Name>엄준일</Name>
		//<NickName>땡초</NickName>
		//<Introduction>소개입니다</Introduction>
		//<Address>서울시</Address>
		//<Hobby>컴퓨터</Hobby>
		//<Gender>Man</Gender>
		//<Alarm>True</Alarm>
		//<AutoClip>True</AutoClip>
		private string _title				= "UMC WORLD";
		private string _url					= "http://localhost:9090";
		private string _email				= "umjunil@hotmail.com";
		private string _picture				= string.Empty;
		private string _name				= "엄준일";
		private string _nickName			= "땡초";
		private string _introduction		= "안녕하세요. 블로그에 오신것을 환영합니다";
		private string _address				= "강원도";
		private string _hobby				= "컴퓨터";
		private BlogConst.Gender _gender	= BlogConst.Gender.Man;
		private bool _alram					= true;
		private bool _autoClip				= false;
		private int _postCount				= 3;
		private int _recentCommentListCount	= 5;
		private int _recentArticleListCount	= 5;
		private bool _useEmoticon			= true;
		private int _peridoNewIcon			= 1;

		/// <summary>
		/// 블로그 제목
		/// </summary>
		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}
		/// <summary>
		/// 블로그 URL
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
		/// 내 사진
		/// </summary>
		public string Picture
		{
			get { return _picture; }
			set { _picture = value; }
		}
		/// <summary>
		/// 이름
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		/// <summary>
		/// 별명
		/// </summary>
		public string NickName
		{
			get { return _nickName; }
			set { _nickName = value; }
		}
		/// <summary>
		/// 소개
		/// </summary>
		public string Introduction
		{
			get { return _introduction; }
			set { _introduction = value; }
		}
		/// <summary>
		/// 주소
		/// </summary>
		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}
		/// <summary>
		/// 취미
		/// </summary>
		public string Hobby
		{
			get { return _hobby; }
			set { _hobby = value; }
		}
		/// <summary>
		/// 성별
		/// </summary>
		public BlogConst.Gender Gender
		{
			get { return _gender; }
			set { _gender = value; }
		}
		/// <summary>
		/// 댓글이나 게시판 글 등록시 이메일로 알림
		/// </summary>
		public bool Alarm
		{
			get { return _alram; }
			set { _alram = value; }
		}
		/// <summary>
		/// 포스트 등록후 클립보드에 포스트 복사
		/// </summary>
		public bool AutoClip
		{
			get { return _autoClip; }
			set { _autoClip = value; }
		}
		/// <summary>
		/// 페이지당 포스트 갯수
		/// </summary>
		public int PostCount
		{
			get { return _postCount; }
			set { _postCount = value; }
		}

		/// <summary>
		/// 최신 댓글 리스트 보여준 갯수
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
