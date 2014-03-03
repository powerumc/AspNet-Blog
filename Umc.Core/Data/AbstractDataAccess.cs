using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

using Umc.Core;

namespace Umc.Core.Data
{
	/// <summary>
	/// Dac Layer ������ DataBase Access Ŭ������ �����Ѵ�.
	/// </summary>
	public abstract class AbstractDataAccess
	{
		private static string connectionString = UmcConfiguration.ConnectionString;

		protected AbstractDataAccess()
		{
		}

		#region SqlCommand ���� �޼���
		/// <summary>
		/// ���ν����� ȣ���Ѵ�.
		/// ȣ���� �޵�� ReleaseCommand �� ����ϼ���
		/// </summary>
		/// <param name="sp">���ν��� �̸�</param>
		/// <returns></returns>
		protected static SqlCommand GetSpCommand(string sp)
		{
			return GetSpCommand( sp, null );
		}

		/// <summary>
		/// Parameters �� �ִ� ���ν����� ȣ���Ѵ�
		/// ȣ�� �� �޵�� ReleaseCommand �� ����ϼ���
		/// </summary>
		/// <param name="sp">���ν��� �̸�</param>
		/// <param name="parameters">�Ķ����</param>
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
		/// Parameters �� �ִ� ���ν��� ȣ��� �Բ� Ʈ����� ����� �����Ѵ�
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
		/// Inline ������ ȣ���Ѵ�
		/// ȣ���� �ݵ�� ReleaseCommand �� ����ϼ���
		/// </summary>
		/// <param name="query">Inline ����</param>
		/// <returns></returns>
		protected static SqlCommand GetRawCommand(string query)
		{
			return GetRawCommand( query, null );
		}

		/// <summary>
		/// inline ������ ȣ���Ѵ�
		/// ȣ���� �ݵ�� ReleaseCommand �� ����ϼ���
		/// </summary>
		/// <param name="query">inline ����</param>
		/// <param name="parameters">�Ķ����</param>
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
		/// parameters �� �ִ� inline ������ ȣ���ϸ鼭 Ʈ����� ����� �����Ѵ�
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

		#region �����ͺ��̽� Close �޼���
		/// <summary>
		/// �����ͺ��̽� �ݱ�
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
		/// Commit�� �Բ� �����ͺ��̽��� �ݴ´�
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
		/// Rollback�� �Բ� �����ͺ��̽��� �ݴ´�
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

		#region Sql �Ķ���� �޼���
		/// <summary>
		/// ����� ���� Parameter
		/// </summary>
		/// <param name="paramName">�Ķ���� �̸�</param>
		/// <param name="type">SqlDbType</param>
		/// <param name="size">ũ��</param>
		/// <param name="val">�Ķ���� ��</param>
		/// <returns></returns>
		protected static SqlParameter CreateInParam(string paramName, SqlDbType type, int size, object val)
		{
			SqlParameter param	= new SqlParameter( paramName, type, size );
			param.Value			= val;

			return param;
		}

		/// <summary>
		/// Output Ÿ���� Parameter
		/// </summary>
		/// <param name="paramName">�Ķ���� �̸�</param>
		/// <param name="type">SqlDbType</param>
		/// <param name="size">ũ��</param>
		/// <param name="val">�Ķ���� ��</param>
		/// <returns></returns>
		protected static SqlParameter CreateOutParam(string paramName, SqlDbType type, int size)
		{
			SqlParameter param	= new SqlParameter( paramName, type, size );
			param.Direction		= ParameterDirection.Output;

			return param;
		}

		/// <summary>
		/// ReturnValue Ÿ���� Parameter
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
