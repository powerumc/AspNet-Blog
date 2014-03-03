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
		/// ī�װ� ������ �����´�.
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
				throw new UmcDataException("UBI_GetMyCategorys ���ν��� ȣ���� ����", ex.Message);
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}

		/// <summary>
		/// ī�װ� �ڵ带 �����´�
		/// </summary>
		/// <param name="lcode">��з� �ڵ� ������� -1</param>
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
		/// ���ο� ī�װ��� �߰��Ѵ�.
		/// </summary>
		/// <param name="title">�߰��� ī�װ� Ÿ��Ʋ</param>
		/// <param name="node">���</param>
		/// <param name="mode">1:��Ʈ 2:�ڽ� ī�װ�</param>
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
		/// ī�װ� ������ �����Ѵ�.
		/// </summary>
		/// <param name="title">Ÿ��Ʋ</param>
		/// <param name="node">���</param>
		/// <param name="lCode">��з�</param>
		/// <param name="mCode">�ߺз�</param>
		/// <param name="parent">ī�װ� �θ�</param>
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
		/// ī�װ��� �����Ѵ�.
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
		/// ī�װ� �ڽĳ�带 �̵��Ѵ�.
		/// </summary>
		/// <param name="node">���</param>
		/// <param name="mode">��� up,down</param>
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
		/// ī�װ� ������ �̵��Ѵ�.
		/// </summary>
		/// <param name="node">Node</param>
		/// <param name="mode">��� up, down</param>
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
