using System;
using Umc.Core;

namespace Umc.Core
{
	/// <summary>
	/// �ý��� �������� Exception �� ����Ѵ�
	/// </summary>
	public class UmcException : Exception
	{
		private string _code;

		/// <summary>
		/// ���� ���� �ڵ�
		/// </summary>
		public const string ERR_INTERNAL			= "err.internal";
		/// <summary>
		/// �˼����� ���� �ڵ�
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
