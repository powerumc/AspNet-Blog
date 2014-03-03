using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace Umc.Core.Authenticate
{
	public class Authenticator
	{
		private static Authenticator _instance	= null;

		public static Authenticator GetInstance()
		{
			lock (typeof(Authenticator))
			{
				if( _instance == null )
					_instance	= new Authenticator();
			}

			return _instance;
		}



		/// <summary>
		/// 유저를 로그인 시킨다.
		/// </summary>
		/// <param name="userInfo"></param>
		/// <param name="context"></param>
		public void Login(UserInfo userInfo, HttpContext context)
		{
			context.Session[AuthenticateConst.SESSION_USERINFO] = userInfo;
		}

		/// <summary>
		/// 로그아웃 한다.
		/// </summary>
		/// <param name="context"></param>
		public void Logout(HttpContext context)
		{
			context.Session[AuthenticateConst.SESSION_USERINFO] = null;
		}

		/// <summary>
		/// 회원 정보를 가져오면서 로그인 시킨다.
		/// </summary>
		/// <param name="email"></param>
		/// <param name="context"></param>
		/// <returns></returns>
		public UserInfo GetUserInfo(string email, HttpContext context)
		{
			return AuthenticateAccess.GetUserInfo( email, context );
		}

		/// <summary>
		/// 회원 정보를 가져온다.
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public UserInfo GetUserInfo( HttpContext context)
		{
			HttpSessionState session	= context.Session;

			UserInfo userInfo	= (UserInfo)session[ AuthenticateConst.SESSION_USERINFO ];

			if (userInfo == null)
			{
				userInfo	= UserInfo.CreateUser( null );

				session[ AuthenticateConst.SESSION_USERINFO ] = userInfo;
			}

			return userInfo;
		}
		/// <summary>
		/// 회원 가입
		/// </summary>
		/// <param name="userInfo"></param>
		/// <returns></returns>
		public string InsertUser(UserInfo userInfo)
		{
			return AuthenticateAccess.InsertUser( userInfo );
		}

		/// <summary>
		/// 회원 목록을 가져온다.
		/// </summary>
		/// <param name="currentPage"></param>
		/// <param name="pageSize"></param>
		/// <param name="searchKeyword"></param>
		/// <param name="searchString"></param>
		/// <returns></returns>
		public UserInfoBindModel GetUserList(int currentPage, int pageSize, string searchKeyword, string searchString)
		{
			return AuthenticateAccess.GetUserList( currentPage, pageSize, searchKeyword, searchString );
		}

		/// <summary>
		/// 회원레벨규칙을 가져온다.
		/// </summary>
		/// <returns></returns>
		public NameValueCollection GetMemberLevelRole()
		{
			return AuthenticateAccess.GetMemberLevelRole();
		}

		/// <summary>
		/// 유저정보를 수정한다.
		/// </summary>
		/// <param name="email"></param>
		/// <param name="userInfo"></param>
		public void UpdateUserInfo(string email, UserInfo userInfo)
		{
			AuthenticateAccess.UpdateUserInfo( email,  userInfo );
		}

		/// <summary>
		/// 유저를 삭제한다.
		/// </summary>
		/// <param name="email"></param>
		public void RemoveUserInfo(string email)
		{
			AuthenticateAccess.RemoveUserInfo( email );
		}

		/// <summary>
		/// 입력한 아이디와 패스워드를 검사한다
		/// </summary>
		/// <param name="email"></param>
		/// <param name="password"></param>
		/// <returns>
		/// -1 : 이메일이 존재하지 않음
		/// 0  : 아이디/패스워드 일치하지 않음
		/// 1  : OK
		/// 2  : 중복된 데이터
		/// </returns>
		public int CompareEmailAndPassword(string email, string password)
		{
			return AuthenticateAccess.CompareEmailAndPassword( email, password );
		}
	}
}
