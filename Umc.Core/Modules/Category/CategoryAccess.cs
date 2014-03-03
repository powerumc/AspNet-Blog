using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Reflection;

using Umc.Core.Data;
using Umc.Core.Modules.Category.Model;

namespace Umc.Core.Modules.Category
{
	internal class CategoryAccess : AbstractDataAccess
	{
		private static CategoryModel CreateCategoryModelFactory(Type type)
		{
			if (type == typeof(CategoryTreeView))
				return new CategoryTreeView();
			else if(type == typeof(CategoryListBox))
				return new CategoryListBox();

			return null;
		}
		/// <summary>
		/// 카테고리 정보를 가져온다.
		/// </summary>
		/// <returns></returns>
		public static CategoryModel GetMyCategorys(Type type)
		{
			SqlParameter[] param = {
				CreateInParam("@PeridoNewIcon", SqlDbType.Int,4, Blog.BlogManager.GetInstance().BlogBaseModel.BlogModel.PeridoNewIcon)
			};
			SqlCommand cmd = GetSpCommand("UBI_GetMyCategorys", param);

			try
			{
				SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				CategoryModel model = CreateCategoryModelFactory( type );
				while (reader.Read())
				{
					CategoryModel item	= new CategoryModel();
					item.CategoryID		= (int)reader["CategoryID"];
					item.CategoryTitle	= reader["CategoryTitle"].ToString();
					item.CategoryLCode	= (int)reader["CategoryLCode"];
					item.CategoryMCode	= (int)reader["CategoryMCode"];
					item.CategoryGroup	= (int)reader["CategoryGroup"];
					item.CategoryStep	= (int)reader["CategoryStep"];
					item.CategoryOrder	= (int)reader["CategoryOrder"];
					item.ArticleCount	= (int)reader["ArticleCount"];
					item.NewIcon		= (bool)reader["NewIcon"];
					model.Add(item);
					item = null;
				}

				return model;
			}
			catch (Exception ex)
			{
				throw new UmcDataException("UBI_GetMyCategorys 프로시져 호출중 에러", ex.Message);
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}

		/// <summary>
		/// 카테고리 코드를 가져온다
		/// </summary>
		/// <param name="lcode">대분류 코드 없을경우 -1</param>
		/// <returns></returns>
		public static CategoryCodeModel GetCategoryCodes(int lCode)
		{
			SqlParameter[] param	= { CreateInParam("@LCode", SqlDbType.Int,4, lCode) };

			SqlCommand cmd			= GetSpCommand("UBI_GetCategoryCodes", param);

			SqlDataReader reader	= cmd.ExecuteReader(CommandBehavior.CloseConnection);

			CategoryCodeModel code	= new CategoryCodeModel();

			while (reader.Read())
			{
				code.Add( new CategoryCodeModel(
					(int)reader["CategoryLCode"], reader["CategoryLTitle"].ToString()));
			}

			if (reader.NextResult())
			{
				code.CreateCategoryMCode();
				while (reader.Read())
				{
					code.CategoryMCode.Add(new CategoryCodeModel(
						(int)reader["CategoryMCode"], reader["CategoryMTitle"].ToString()));
				}
			}

			ReleaseCommand(cmd);

			return code;
		}

		/// <summary>
		/// 새로운 카테고리를 추가한다.
		/// </summary>
		/// <param name="title">추가될 카테고리 타이틀</param>
		/// <param name="node">노드</param>
		/// <param name="mode">1:루트 2:자식 카테고리</param>
		public static void InsertNewCategory(string title, CategoryNodeValue node, int mode)
		{
			SqlParameter[] param =
				{
					CreateInParam("@Title", SqlDbType.VarChar,50,title ),
					CreateInParam("@LCode", SqlDbType.Int, 4 , node.CategoryLCode),
					CreateInParam("@MCode", SqlDbType.Int, 4 , -1),
					CreateInParam("@Group", SqlDbType.Int, 4, node.CategoryGroup ),
					CreateInParam("@Step",  SqlDbType.Int, 4, node.CategoryStep),
					CreateInParam("@Order", SqlDbType.Int, 4, node.CategoryOrder),
					CreateInParam("@Mode",  SqlDbType.Int, 4, mode)
				};

			SqlCommand cmd		= GetSpCommand("UBI_InsertNewCategory", param, IsolationLevel.ReadUncommitted );

			try
			{
				cmd.ExecuteNonQuery();
				ReleaseCommandWithCommit(cmd);
			}
			catch
			{
				ReleaseCommandWithRollback(cmd);
			}

		}

		/// <summary>
		/// 카테고리 정보를 수정한다.
		/// </summary>
		/// <param name="title">타이틀</param>
		/// <param name="node">노드</param>
		/// <param name="lCode">대분류</param>
		/// <param name="mCode">중분류</param>
		/// <param name="parent">카테고리 부모</param>
		public static void UpdateCategoryNodeValue(string title, CategoryNodeValue node, int lCode, int mCode, int newGroup)
		{
			SqlParameter[] param = { 
				CreateInParam("@ID", SqlDbType.Int, 4, node.CategoryID),
				CreateInParam("@Title", SqlDbType.VarChar,50, title),
				CreateInParam("@LCode", SqlDbType.Int, 4, lCode),
				CreateInParam("@MCode", SqlDbType.Int, 4, mCode),
				CreateInParam("@NewGroup", SqlDbType.Int, 4, newGroup)
			};

			SqlCommand cmd		= GetSpCommand("UBI_UpdateCategoryNodeValue", param, IsolationLevel.ReadUncommitted);

			try
			{
				cmd.ExecuteNonQuery();
			}
			catch
			{
				ReleaseCommandWithRollback(cmd);
			}

			ReleaseCommandWithCommit(cmd);
		}

		/// <summary>
		/// 카테고리를 삭제한다.
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public static bool RemoveCategoryNode(CategoryNodeValue node)
		{
			SqlParameter[] param =
				{
					CreateInParam("@ID", SqlDbType.Int, 4, node.CategoryID),
					CreateInParam("@Step", SqlDbType.Int, 4, node.CategoryStep),
					CreateInParam("@Group", SqlDbType.Int, 4, node.CategoryGroup)
				};

			SqlCommand cmd = GetSpCommand("UBI_RemoveCategoryNode", param, IsolationLevel.Serializable);

			try
			{
				cmd.ExecuteNonQuery();
				ReleaseCommandWithCommit(cmd);
				return true;
			}
			catch
			{
				ReleaseCommandWithRollback(cmd);
				return false;
			}
		}

		
		/// <summary>
		/// 카테고리 자식노드를 이동한다.
		/// </summary>
		/// <param name="node">노드</param>
		/// <param name="mode">모드 up,down</param>
		/// <returns></returns>
		public static bool UpdateMoveCategoryChildNode(CategoryNodeValue node, string mode)
		{
			SqlParameter[] param = {
					CreateInParam("@ID",	SqlDbType.Int,4,node.CategoryID),
					CreateInParam("@Group",	SqlDbType.Int,4,node.CategoryGroup),
					CreateInParam("@Step",	SqlDbType.Int,4,node.CategoryStep),
					CreateInParam("@Order",	SqlDbType.Int,4,node.CategoryOrder),
					CreateInParam("@Mode",	SqlDbType.VarChar,10,mode),
					CreateReturnValue(),
			};

			SqlCommand cmd		= GetSpCommand("UBI_UpdateMoveCategoryChildNode", param, IsolationLevel.Serializable);

			try
			{
				cmd.ExecuteNonQuery();

				int result = (int)cmd.Parameters["@ReturnValue"].Value;

				ReleaseCommandWithCommit(cmd);

				return (result == 1) ? true : false;
			}
			catch
			{
				ReleaseCommandWithRollback( cmd );

				return false;
			}
		}

		/// <summary>
		/// 카테고리 구룹을 이동한다.
		/// </summary>
		/// <param name="node">Node</param>
		/// <param name="mode">모드 up, down</param>
		/// <returns></returns>
		public static bool UpdateMoveCategoryNode(CategoryNodeValue node, string mode)
		{
			SqlParameter[] param = {
					CreateInParam("@ID",	SqlDbType.Int,4,node.CategoryID),
					CreateInParam("@Group",	SqlDbType.Int,4,node.CategoryGroup),
					CreateInParam("@Step",	SqlDbType.Int,4,node.CategoryStep),
					CreateInParam("@Order",	SqlDbType.Int,4,node.CategoryOrder),
					CreateInParam("@Mode",	SqlDbType.VarChar,10,mode),
					CreateReturnValue(),
			};
			SqlCommand cmd		= GetSpCommand("UBI_UpdateMoveCategoryNode", param, IsolationLevel.Serializable);

			try
			{
				cmd.ExecuteNonQuery();

				int result = (int)cmd.Parameters["@ReturnValue"].Value;
				ReleaseCommandWithCommit(cmd);

				return (result == 1) ? true : false;
			}
			catch
			{
				ReleaseCommandWithRollback( cmd );

				return false;
			}
		}
	}
}
