using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

using Umc.Core;

namespace Umc.Core.Data
{
	/// <summary>
	/// Dac Layer 계층에 DataBase Access 클래스를 구현한다.
	/// </summary>
	public abstract class AbstractDataAccess
	{
		private static string connectionString = UmcConfiguration.ConnectionString;

		protected AbstractDataAccess()
		{
		}

		#region SqlCommand 관련 메서드
		/// <summary>
		/// 프로시져를 호출한다.
		/// 호출후 받드시 ReleaseCommand 를 사용하세요
		/// </summary>
		/// <param name="sp">스로시져 이름</param>
		/// <returns></returns>
		protected static SqlCommand GetSpCommand(string sp)
		{
			return GetSpCommand( sp, null );
		}

		/// <summary>
		/// Parameters 가 있는 프로시져를 호출한다
		/// 호출 후 받드시 ReleaseCommand 를 사용하세요
		/// </summary>
		/// <param name="sp">프로시져 이름</param>
		/// <param name="parameters">파라메터</param>
		/// <returns></returns>
		protected static SqlCommand GetSpCommand(string sp, SqlParameter[] parameters)
		{
			SqlConnection cn	= new SqlConnection( connectionString );
			cn.Open();

			SqlCommand cmd		= new SqlCommand( sp, cn );
			cmd.CommandType		= CommandType.StoredProcedure;

			AddParameters( cmd, parameters );

			return cmd;
		}

		protected static SqlCommand GetSpCommand(string sp, IsolationLevel transLevel)
		{
			SqlCommand cmd		= GetSpCommand( sp );

			SetTransaction( cmd, transLevel );

			return cmd;
		}

		/// <summary>
		/// Parameters 가 있는 프로시져 호출과 함께 트랜잭션 잠금을 수행한다
		/// </summary>
		/// <param name="sp"></param>
		/// <param name="parameters"></param>
		/// <param name="transLevel"></param>
		/// <returns></returns>
		protected static SqlCommand GetSpCommand(string sp, SqlParameter[] parameters, IsolationLevel transLevel)
		{
			SqlCommand cmd		= GetSpCommand( sp, parameters );

			SetTransaction( cmd, transLevel );

			return cmd;
		}

		/// <summary>
		/// Inline 쿼리를 호출한다
		/// 호출후 반드시 ReleaseCommand 를 사용하세요
		/// </summary>
		/// <param name="query">Inline 쿼리</param>
		/// <returns></returns>
		protected static SqlCommand GetRawCommand(string query)
		{
			return GetRawCommand( query, null );
		}

		/// <summary>
		/// inline 쿼리를 호출한다
		/// 호출후 반드시 ReleaseCommand 를 사용하세요
		/// </summary>
		/// <param name="query">inline 쿼리</param>
		/// <param name="parameters">파라메터</param>
		/// <returns></returns>
		protected static SqlCommand GetRawCommand(string query, SqlParameter[] parameters)
		{
			SqlConnection cn	= new SqlConnection( connectionString );
			cn.Open();

			SqlCommand cmd		= new SqlCommand( query, cn );
			cmd.CommandType		= CommandType.Text;

			AddParameters( cmd, parameters );

			return cmd;
		}

		protected static SqlCommand GetRawCommand(string query, IsolationLevel transLevel)
		{
			SqlCommand cmd		= GetRawCommand( query );

			SetTransaction( cmd, transLevel );

			return cmd;
		}

		/// <summary>
		/// parameters 가 있는 inline 쿼리를 호출하면서 트랜잭션 잠금을 수행한다
		/// </summary>
		/// <param name="query"></param>
		/// <param name="parameters"></param>
		/// <param name="transLevel"></param>
		/// <returns></returns>
		protected static SqlCommand GetRawCommand(string query, SqlParameter[] parameters, IsolationLevel transLevel)
		{
			SqlCommand cmd		= GetRawCommand( query, parameters );
			
			SetTransaction( cmd, transLevel );

			return cmd;
		}

		private static SqlCommand SetTransaction(SqlCommand cmd, IsolationLevel transLevel)
		{
			SqlTransaction tran	= cmd.Connection.BeginTransaction( transLevel );
			
			cmd.Transaction		= tran;

			return cmd;
		}
		#endregion

		#region 데이터베이스 Close 메서드
		/// <summary>
		/// 데이터베이스 닫기
		/// </summary>
		/// <param name="cmd"></param>
		protected static void ReleaseCommand(SqlCommand cmd)
		{
			SqlConnection cn	= cmd.Connection;

			if( cmd.Transaction != null )
			{
				throw new UmcDataException(MessageCode.ERR_TRANSACTION);
			}
			
			if( cn != null && cn.State != ConnectionState.Closed )
			{
				cn.Close();
				cn.Dispose();
			}
		}

		/// <summary>
		/// Commit과 함께 데이터베이스를 닫는다
		/// </summary>
		/// <param name="cmd"></param>
		protected static void ReleaseCommandWithCommit(SqlCommand cmd)
		{
			SqlTransaction tran	= cmd.Transaction;
			tran.Commit();
			tran.Dispose();

			ReleaseCommand( cmd );
		}

		/// <summary>
		/// Rollback과 함께 데이터베이스를 닫는다
		/// </summary>
		/// <param name="cmd"></param>
		protected static void ReleaseCommandWithRollback(SqlCommand cmd)
		{
			SqlTransaction tran	= cmd.Transaction;
			tran.Rollback();
			tran.Dispose();

			ReleaseCommand( cmd );
		}
		#endregion

		#region Sql 파라메터 메서드
		/// <summary>
		/// 사용자 지정 Parameter
		/// </summary>
		/// <param name="paramName">파라메터 이름</param>
		/// <param name="type">SqlDbType</param>
		/// <param name="size">크기</param>
		/// <param name="val">파라메터 값</param>
		/// <returns></returns>
		protected static SqlParameter CreateInParam(string paramName, SqlDbType type, int size, object val)
		{
			SqlParameter param	= new SqlParameter( paramName, type, size );
			param.Value			= val;

			return param;
		}

		/// <summary>
		/// Output 타입의 Parameter
		/// </summary>
		/// <param name="paramName">파라메터 이름</param>
		/// <param name="type">SqlDbType</param>
		/// <param name="size">크기</param>
		/// <param name="val">파라메터 값</param>
		/// <returns></returns>
		protected static SqlParameter CreateOutParam(string paramName, SqlDbType type, int size)
		{
			SqlParameter param	= new SqlParameter( paramName, type, size );
			param.Direction		= ParameterDirection.Output;

			return param;
		}

		/// <summary>
		/// ReturnValue 타입의 Parameter
		/// </summary>
		/// <returns></returns>
		protected static SqlParameter CreateReturnValue()
		{
			SqlParameter param	= new SqlParameter( "@ReturnValue", SqlDbType.Int, 4 );
			param.Direction		= ParameterDirection.ReturnValue;

			return param;
		}

		private static void AddParameters(SqlCommand cmd, SqlParameter[] parameters)
		{
			if( parameters == null ) return;

			foreach( SqlParameter param in parameters )
			{
				cmd.Parameters.Add( param );
			}
		}
		#endregion
	}
}
