using System;

namespace Umc.Core
{
	/// <summary>
	/// 데이터베이스 입출력에서 발생하는 Exception 을 담당할 클래스
	/// 
	/// DataAccess 과정의 예외는 이 Exception 을 사용하세요
	/// </summary>
	public class UmcDataException : UmcException
	{
		/// <summary>
		/// 처리되지 않은 Transaction 에러
		/// </summary>
		public const string ERR_TRANSACTION				= "err.transaction";

		public UmcDataException( Exception cause ) : base( UmcException.ERR_UNKNOWN, cause )
		{
		}

		public UmcDataException( string code ) : base ( GetCodeString(code) )
		{
			this.Code		= code;
		}

		public UmcDataException( string code, string message ) : base( message )
		{
			this.Code		= code;
		}

		public UmcDataException( string code, Exception cause ) : this( code, GetCodeString(code), cause )
		{
		}

		public UmcDataException( string code, string message, Exception cause )
			: base( message, cause )
		{
			this.Code		= code;
		}
	}
}
