using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;

using Umc.Core;
using Umc.Core.Data;

namespace Umc.Core.Authenticate
{
	internal class AuthenticateAccess : AbstractDataAccess
	{
		public static UserInfo GetUserInfo(string email, HttpContext context)
		{
			SqlParameter[] param	= { CreateInParam("@EMail", SqlDbType.VarChar, 20, email ) };

			SqlCommand cmd			= GetSpCommand("UUI_GetUserInfo", param);
			SqlDataReader reader	= cmd.ExecuteReader( CommandBehavior.CloseConnection );

			UserInfo userInfo		= UserInfo.CreateUser( email );
			try
			{
				if (reader.Read())
				{
					fillUserInfo(reader, userInfo);

					context.Session[AuthenticateConst.SESSION_USERINFO] = userInfo;
				}
				return userInfo;
			}
			catch( Exception ex )
			{
				throw new UmcException("회원 정보를 가져오는 중 에러", ex);
			}
			finally
			{
				reader.Close();
				ReleaseCommand(cmd);
			}
		}

		private static void fillUserInfo(SqlDataReader reader, UserInfo userInfo)
		{
			userInfo.Name		= (string)reader["Name"];
			userInfo.NickName	= (string)reader["NickName"];
			userInfo.Password	= (string)reader["Password"];
			userInfo.Homepage	= (string)reader["Homepage"];
			userInfo.Level		= (LevelAttribute)Enum.Parse( typeof(LevelAttribute), (string)reader["Level"]);
		}

		/// <summary>
		/// 회원 가입
		/// </summary>
		/// <param name="userInfo"></param>
		/// <returns></returns>
		public static string InsertUser(UserInfo userInfo)
		{
			SqlParameter[] param = {
				CreateInParam("@EMail", SqlDbType.VarChar, 20,	userInfo.EMail ),
				CreateInParam("@Name", SqlDbType.VarChar,20,	userInfo.Name ),
				CreateInParam("@NickName",SqlDbType.VarChar,20,	userInfo.NickName ),
				CreateInParam("@Password",SqlDbType.VarChar,100, userInfo.Password ),
				CreateInParam("@Homepage",SqlDbType.VarChar,255, userInfo.Homepage ),
				CreateInParam("@Level", SqlDbType.VarChar,20, userInfo.Level.ToString() ),
				CreateOutParam("@ReturnCode", SqlDbType.VarChar,100)
			};

			SqlCommand cmd		= GetSpCommand("UUI_InsertUser", param, IsolationLevel.ReadUncommitted);

			try
			{
				cmd.ExecuteNonQuery();
				ReleaseCommandWithCommit(cmd);
				return (string)cmd.Parameters["@ReturnCode"].Value;
			}
			catch
			{
				ReleaseCommandWithRollback(cmd);
				return AuthenticateConst.MESSAGE_JOIN_FAIL;
			}
		}

		/// <summary>
		/// 회원 리스트 가져오기
		/// </summary>
		/// <param name="currentPage"></param>
		/// <param name="pageSize"></param>
		/// <param name="searchKeyword"></param>
		/// <param name="searchString"></param>
		/// <returns></returns>
		public static UserInfoBindModel GetUserList(int currentPage, int pageSize, string searchKeyword, string searchString)
		{
			SqlParameter[] param = {
				CreateInParam("@CurrentPage", SqlDbType.Int, 4,			currentPage ),
				CreateInParam("@PageSize", SqlDbType.Int, 4,			pageSize ),
				CreateInParam("@SearchKeyword",SqlDbType.VarChar,20,	searchKeyword ),
				CreateInParam("@SearchString", SqlDbType.VarChar,20,	searchString )
			};

			SqlCommand cmd			= GetSpCommand("UBU_GetUserList", param);
			SqlDataReader reader	= cmd.ExecuteReader(CommandBehavior.CloseConnection);

			UserInfoBindModel bindModel = new UserInfoBindModel();
			try
			{
				if (reader.Read())
				{
					bindModel.TotalCount	= (int)reader["TotalCount"];
				}

				if( !reader.NextResult() ) return bindModel;

				while (reader.Read())
				{
					UserInfo model	= UserInfo.CreateUser( (string)reader["Email"] );
					fillUserInfo( reader, model );

					bindModel.Add( model );
					model			= null;
				}

				return bindModel;
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}

		/// <summary>
		/// 회원레벨규칙을 가져온다.
		/// </summary>
		/// <returns></returns>
		public static NameValueCollection GetMemberLevelRole()
		{
			SqlCommand cmd				= GetRawCommand("SELECT * FROM Level WHERE Level NOT IN ('GUEST') ORDER BY [Level] ASC");
			SqlDataReader reader		= cmd.ExecuteReader(CommandBehavior.CloseConnection);

			NameValueCollection data	= new NameValueCollection();

			try
			{
				while (reader.Read())
				{
					data.Add((string)reader["Level"], (string)reader["LevelString"]);
				}

				return data;
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}

		/// <summary>
		/// 사용자 정보를 수정한다.
		/// </summary>
		/// <param name="userInfo"></param>
		public static void UpdateUserInfo(string email, UserInfo userInfo)
		{
			SqlParameter[] param = {
				CreateInParam("@OldEmail", SqlDbType.VarChar,20,	email),
				CreateInParam("@NewEmail", SqlDbType.VarChar,255,	userInfo.EMail),
				CreateInParam("@Name", SqlDbType.VarChar,20,		userInfo.Name),
				CreateInParam("@NickName",SqlDbType.VarChar,20,		userInfo.NickName),
				CreateInParam("@HomePage", SqlDbType.VarChar,255,	userInfo.Homepage),
				CreateInParam("@Level", SqlDbType.VarChar,20,		userInfo.Level.ToString())
			};

			SqlCommand cmd			= GetSpCommand("UBU_UpdateUserInfo",param);

			cmd.ExecuteNonQuery();

			ReleaseCommand(cmd);
		}

		/// <summary>
		/// 유저를 삭제한다.
		/// </summary>
		/// <param name="email"></param>
		public static void RemoveUserInfo(string email)
		{
			SqlParameter[] param = {
				CreateInParam("@Email", SqlDbType.VarChar,255,	email)
			};

			SqlCommand cmd			= GetRawCommand("DELETE UserInfo WHERE Email=@Email", param, IsolationLevel.ReadUncommitted);

			try
			{
				cmd.ExecuteNonQuery();
				ReleaseCommandWithCommit(cmd);
			}
			catch(Exception ex)
			{
				ReleaseCommandWithRollback(cmd);
				throw new UmcDataException("유저정보를 삭제하는중 에러", ex);
			}
		}

		/// <summary>
		/// 입력한 아이디와 패스워드를 검사한다
		/// </summary>
		/// <param name="email"></param>
		/// <param name="password"></param>
		/// <returns>
		/// -1 : 이메일이 존재하지 않음
		/// 0  : 아이디/패스워드 일치하지 않음
		/// 1  : OK
		/// 2  : 중복된 데이터
		/// </returns>
		public static int CompareEmailAndPassword( string email, string password )
		{
			SqlParameter[] param =
				{
					CreateInParam("@EMail",					SqlDbType.VarChar,255,			email),
					CreateInParam("@Password",				SqlDbType.VarChar,100,			password),
					CreateReturnValue()
				};

			SqlCommand cmd			= GetSpCommand("UBU_CompareEmailAndPassword", param);

			try
			{
				cmd.ExecuteNonQuery();

				int result			= (int)cmd.Parameters["@ReturnValue"].Value;

				return result;
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}
	}
}
