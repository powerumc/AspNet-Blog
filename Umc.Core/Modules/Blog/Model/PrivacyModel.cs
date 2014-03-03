using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Modules.Blog.Model
{
	/// <summary>
	/// �����̹��� ����
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
		/// ���� ���� ����
		/// </summary>
		public bool CanWriteMemo
		{
			get { return _canWriteMemo; }
			set { _canWriteMemo = value; }
		}
		/// <summary>
		/// ���� ���� ����
		/// </summary>
		public bool CanWriteGuestBoard
		{
			get { return _canWriteGuestBoard; }
			set { _canWriteGuestBoard = value; }
		}
		/// <summary>
		/// �������� �� ��ƼŬ...(ȯ�� �޼��� ��ƼŬ)
		/// </summary>
		public int GuestBoardArticleNo
		{
			get { return _guestboardArticleNo; }
			set { _guestboardArticleNo = value; }
		}
		/// <summary>
		/// �Ϲ� �Խ��� ���� ����
		/// </summary>
		public bool CanWriteBbs
		{
			get { return _canWriteBbs; }
			set { _canWriteBbs = value; }
		}
		/// <summary>
		/// ���� IP
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
		/// RSS ���� ����
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
		/// ���콺 ������ ��ư Ȱ�� ����
		/// </summary>
		public bool AllowMouseRightButton
		{
			get { return _allowMouseRightButton; }
			set { _allowMouseRightButton = value; }
		}
	}
}
