using System;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Authenticate
{
	public class AuthenticateConst
	{
		public const string AUTHENTICATE_HASH_FORMAT = "SHA1";
		/// <summary>
		/// 유져 관련 세션 변수
		/// </summary>
		public const string SESSION_USERINFO = "currentUserInfo";
		/// <summary>
		/// 잘못된 이메일 주소
		/// </summary>
		public const string MESSAGE_WRONG_EMAIL	= "message.wrong.email";
		/// <summary>
		/// 자못된 이름
		/// </summary>
		public const string MESSAGE_EMPTY_NAME	= "message.empty.name";
		/// <summary>
		/// 잘못된 닉네임
		/// </summary>
		public const string MESSAGE_EMPTY_NICKNAME	= "message.empty.nickname";
		/// <summary>
		/// 잘못된 비밀번호
		/// </summary>
		public const string MESSAGE_EMPTY_PASSWORD	= "message.empty.password";
		/// <summary>
		/// 잘못된 비밀번호 확인
		/// </summary>
		public const string MESSAGE_COMPARE_PASSWORD	= "message.compare.password";
		/// <summary>
		/// 회원 가입 성공
		/// </summary>
		public const string MESSAGE_SUCCESS_USERJOIN	= "message.success.userjoin";
		/// <summary>
		/// 이메일 중복
		/// </summary>
		public const string MESSAGE_DOUBLE_EMAIL		= "message.double.email";
		/// <summary>
		/// 기타 이유로 가입 불가능
		/// </summary>
		public const string MESSAGE_JOIN_FAIL			= "message.join.fail";

		public const string MESSAGE_LOGIN_FAIL			= "message.login.fail";

		public const string MESSAGE_LOGIN_SUCCESS		= "message.login.success";
	}
}
