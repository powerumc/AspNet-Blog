using System;
using System.Collections.Generic;
using System.Text;

using Umc.Core;

namespace Umc.Core
{
	public class MessageCode
	{
		/// <summary>
		/// Message.Config ���� �޽����� �����´�
		/// �ڵ忡 ���� �޽����� ������� code �� �����Ѵ�
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public static string GetMessageByCode(string code)
		{
			string message	= UmcConfiguration.Message[code];

			return ( message == null ) ? code : message;
		}
		/// <summary>
		/// ����Ǿ����ϴ�
		/// </summary>
		public const string MESSAGE_SAVED				= "message.saved";
		/// <summary>
		/// Ʈ����� ����
		/// </summary>
		public const string ERR_TRANSACTION				= "err.transaction";
	}
}
