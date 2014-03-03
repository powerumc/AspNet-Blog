using System;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Modules.Blog.Model
{
	/// <summary>
	/// 프로필 정보
	/// </summary>
	[Serializable]
	public class ProfileInfoModel
	{
		//<PublicName>True</PublicName>
		//<PublicGender>True</PublicGender>
		//<PublicAddress>True</PublicAddress>
		//<PublicGuestBoard></PublicGuestBoard>
		private bool _publicName;
		private bool _publicGender;
		private bool _publicAddress;
		private bool _publicGuestBoard;

		public bool PublicName
		{
			get { return _publicName; }
			set { _publicName = value; }
		}
		public bool PublicGender
		{
			get { return _publicGender; }
			set { _publicGender = value; }
		}
		public bool PublicAddress
		{
			get { return _publicAddress; }
			set { _publicAddress = value; }
		}
		public bool PublicGuestBoard
		{
			get { return _publicGuestBoard; }
			set { _publicGuestBoard = value; }
		}
	}
}
