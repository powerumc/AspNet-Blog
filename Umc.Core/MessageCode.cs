using System;
using System.Collections.Generic;
using System.Text;

using Umc.Core;

namespace Umc.Core
{
	public class MessageCode
	{
		/// <summary>
		/// Message.Config 에서 메시지를 가져온다
		/// 코드에 의한 메시지가 없을경우 code 를 리턴한다
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public static string GetMessageByCode(string code)
		{
			string message	= UmcConfiguration.Message[code];

			return ( message == null ) ? code : message;
		}
		/// <summary>
		/// 저장되었습니다
		/// </summary>
		public const string MESSAGE_SAVED				= "message.saved";
		/// <summary>
		/// 트랜잭션 오류
		/// </summary>
		public const string ERR_TRANSACTION				= "err.transaction";
	}
}
