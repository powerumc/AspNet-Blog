using System;

namespace Umc.Core
{
	/// <summary>
	/// �����ͺ��̽� ����¿��� �߻��ϴ� Exception �� ����� Ŭ����
	/// 
	/// DataAccess ������ ���ܴ� �� Exception �� ����ϼ���
	/// </summary>
	public class UmcDataException : UmcException
	{
		/// <summary>
		/// ó������ ���� Transaction ����
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
