using System;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Authenticate
{
	public enum LevelAttribute
	{
		ADMIN,
		MEMBER,
		GUEST,
	}
	public class UserInfo
	{
		private string email		= null;
		private string name			= null;
		private string nickName		= null;
		private string homepage		= null;
		private string password		= null;
		private LevelAttribute level = LevelAttribute.GUEST;
		private int totalCount;

		protected UserInfo()
		{
		}

		private UserInfo(string email)
		{
			this.email = email;
		}
		/// <summary>
		/// 이메일
		/// </summary>
		public string EMail
		{
			get { return email; }
		}
		/// <summary>
		/// 이름
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		/// <summary>
		/// 닉네임
		/// </summary>
		public string NickName
		{
			get { return nickName; }
			set { nickName = value; }
		}
		/// <summary>
		/// 블로그/홈페이지
		/// </summary>
		public string Homepage
		{
			get { return homepage; }
			set { homepage = value; }
		}
		/// <summary>
		/// 비밀번호
		/// </summary>
		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		public LevelAttribute Level
		{
			get { return level; }
			set { level = value; }
		}

		public int TotalCount
		{
			get { return totalCount; }
			set { totalCount = value; }
		}

		public static UserInfo CreateUser()
		{
			return CreateUser( null );
		}

		public static UserInfo CreateUser(string email)
		{
			return new UserInfo( email );
		}
	}
}
