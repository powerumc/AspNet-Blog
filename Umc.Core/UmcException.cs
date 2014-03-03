using System;
using Umc.Core;

namespace Umc.Core
{
	/// <summary>
	/// 시스템 전반적인 Exception 을 담당한다
	/// </summary>
	public class UmcException : Exception
	{
		private string _code;

		/// <summary>
		/// 내부 오류 코드
		/// </summary>
		public const string ERR_INTERNAL			= "err.internal";
		/// <summary>
		/// 알수없는 오류 코드
		/// </summary>
		public const string ERR_UNKNOWN				= "err.unknown";


		public string Code
		{
			get { return _code; }
			set { _code = value; }
		}

		public UmcException( Exception cause ) : base( UmcException.ERR_UNKNOWN, cause )
		{
		}

		public UmcException( string code ) : base( GetCodeString( code ) )
		{
			this.Code	= code;
		}

		public UmcException( string code, Exception cause ) : this( code, GetCodeString(code), cause )
		{
		}

		public UmcException( string code, string message ) : base( message )
		{
			this.Code	= code;
		}

		public UmcException( string code, string message, Exception cause ) : base( message, cause )
		{
			this.Code	= code;
		}

		protected static string GetCodeString( string code )
		{
			string msg		= UmcConfiguration.Message[ code ];

			return ( msg == null ) ? code : msg;
		}
	}
}
