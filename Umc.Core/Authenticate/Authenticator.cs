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
		/// ������ �α��� ��Ų��.
		/// </summary>
		/// <param name="userInfo"></param>
		/// <param name="context"></param>
		public void Login(UserInfo userInfo, HttpContext context)
		{
			context.Session[AuthenticateConst.SESSION_USERINFO] = userInfo;
		}

		/// <summary>
		/// �α׾ƿ� �Ѵ�.
		/// </summary>
		/// <param name="context"></param>
		public void Logout(HttpContext context)
		{
			context.Session[AuthenticateConst.SESSION_USERINFO] = null;
		}

		/// <summary>
		/// ȸ�� ������ �������鼭 �α��� ��Ų��.
		/// </summary>
		/// <param name="email"></param>
		/// <param name="context"></param>
		/// <returns></returns>
		public UserInfo GetUserInfo(string email, HttpContext context)
		{
			return AuthenticateAccess.GetUserInfo( email, context );
		}

		/// <summary>
		/// ȸ�� ������ �����´�.
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
		/// ȸ�� ����
		/// </summary>
		/// <param name="userInfo"></param>
		/// <returns></returns>
		public string InsertUser(UserInfo userInfo)
		{
			return AuthenticateAccess.InsertUser( userInfo );
		}

		/// <summary>
		/// ȸ�� ����� �����´�.
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
		/// ȸ��������Ģ�� �����´�.
		/// </summary>
		/// <returns></returns>
		public NameValueCollection GetMemberLevelRole()
		{
			return AuthenticateAccess.GetMemberLevelRole();
		}

		/// <summary>
		/// ���������� �����Ѵ�.
		/// </summary>
		/// <param name="email"></param>
		/// <param name="userInfo"></param>
		public void UpdateUserInfo(string email, UserInfo userInfo)
		{
			AuthenticateAccess.UpdateUserInfo( email,  userInfo );
		}

		/// <summary>
		/// ������ �����Ѵ�.
		/// </summary>
		/// <param name="email"></param>
		public void RemoveUserInfo(string email)
		{
			AuthenticateAccess.RemoveUserInfo( email );
		}

		/// <summary>
		/// �Է��� ���̵�� �н����带 �˻��Ѵ�
		/// </summary>
		/// <param name="email"></param>
		/// <param name="password"></param>
		/// <returns>
		/// -1 : �̸����� �������� ����
		/// 0  : ���̵�/�н����� ��ġ���� ����
		/// 1  : OK
		/// 2  : �ߺ��� ������
		/// </returns>
		public int CompareEmailAndPassword(string email, string password)
		{
			return AuthenticateAccess.CompareEmailAndPassword( email, password );
		}
	}
}
