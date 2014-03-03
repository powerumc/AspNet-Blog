using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Modules.Blog.Model
{
	/// <summary>
	/// 프라이버시 정보
	/// </summary>
	[Serializable]
	public class PrivacyModel
	{
		private bool _canWriteMemo			= true;
		private bool _canWriteGuestBoard	= true;
		private int _guestboardArticleNo	= 1;
		private bool _canWriteBbs			= true;
		private string _blockIP				= string.Empty;
		private bool _publicRSS				= true;
		private int _limitRssCount			= 20;
		private bool _allowMouseRightButton	= false;

		/// <summary>
		/// 덧글 쓰기 권한
		/// </summary>
		public bool CanWriteMemo
		{
			get { return _canWriteMemo; }
			set { _canWriteMemo = value; }
		}
		/// <summary>
		/// 방명록 쓰기 권한
		/// </summary>
		public bool CanWriteGuestBoard
		{
			get { return _canWriteGuestBoard; }
			set { _canWriteGuestBoard = value; }
		}
		/// <summary>
		/// 방명록으로 쓸 아티클...(환영 메세지 아티클)
		/// </summary>
		public int GuestBoardArticleNo
		{
			get { return _guestboardArticleNo; }
			set { _guestboardArticleNo = value; }
		}
		/// <summary>
		/// 일반 게시판 쓰기 권한
		/// </summary>
		public bool CanWriteBbs
		{
			get { return _canWriteBbs; }
			set { _canWriteBbs = value; }
		}
		/// <summary>
		/// 차단 IP
		/// </summary>
		public string[] BlockIP
		{
			get
			{
				string[] ips = _blockIP.Split(',');
				return ips;
			}
		}
		/// <summary>
		/// RSS 공개 여부
		/// </summary>
		public bool PublicRSS
		{
			get { return _publicRSS; }
			set { _publicRSS = value; }
		}

		public int LimitRssCount
		{
			get { return _limitRssCount; }
			set { _limitRssCount = value; }
		}
		/// <summary>
		/// 마우스 오른쪽 버튼 활성 여부
		/// </summary>
		public bool AllowMouseRightButton
		{
			get { return _allowMouseRightButton; }
			set { _allowMouseRightButton = value; }
		}
	}
}
