using System;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Authenticate
{
	public class AuthenticateConst
	{
		public const string AUTHENTICATE_HASH_FORMAT = "SHA1";
		/// <summary>
		/// ���� ���� ���� ����
		/// </summary>
		public const string SESSION_USERINFO = "currentUserInfo";
		/// <summary>
		/// �߸��� �̸��� �ּ�
		/// </summary>
		public const string MESSAGE_WRONG_EMAIL	= "message.wrong.email";
		/// <summary>
		/// �ڸ��� �̸�
		/// </summary>
		public const string MESSAGE_EMPTY_NAME	= "message.empty.name";
		/// <summary>
		/// �߸��� �г���
		/// </summary>
		public const string MESSAGE_EMPTY_NICKNAME	= "message.empty.nickname";
		/// <summary>
		/// �߸��� ��й�ȣ
		/// </summary>
		public const string MESSAGE_EMPTY_PASSWORD	= "message.empty.password";
		/// <summary>
		/// �߸��� ��й�ȣ Ȯ��
		/// </summary>
		public const string MESSAGE_COMPARE_PASSWORD	= "message.compare.password";
		/// <summary>
		/// ȸ�� ���� ����
		/// </summary>
		public const string MESSAGE_SUCCESS_USERJOIN	= "message.success.userjoin";
		/// <summary>
		/// �̸��� �ߺ�
		/// </summary>
		public const string MESSAGE_DOUBLE_EMAIL		= "message.double.email";
		/// <summary>
		/// ��Ÿ ������ ���� �Ұ���
		/// </summary>
		public const string MESSAGE_JOIN_FAIL			= "message.join.fail";

		public const string MESSAGE_LOGIN_FAIL			= "message.login.fail";

		public const string MESSAGE_LOGIN_SUCCESS		= "message.login.success";
	}
}
