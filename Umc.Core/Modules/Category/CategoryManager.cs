using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

using Umc.Core.Modules.Category.Model;

namespace Umc.Core.Modules.Category
{
	public class CategoryManager : IManager
	{
		private static CategoryManager instance		= null;

		public static CategoryManager GetInstance()
		{
			lock (typeof(CategoryManager))
			{
				if( instance == null)
					instance	= new CategoryManager();

				return instance;
			}
		}

		/// <summary>
		/// ���� ī�װ��� �����´�
		/// </summary>
		/// <param name="type">���ε� �� ��Ʈ�� Type�� ������ Class</param>
		/// <returns></returns>
		public CategoryModel GetMyCategorys(Type type)
		{
			return CategoryAccess.GetMyCategorys(type);
		}

		/// <summary>
		/// ī�װ� �ڵ带 �����´�
		/// </summary>
		/// <param name="lcode">��з� �ڵ� ������� -1</param>
		/// <returns></returns>
		public CategoryCodeModel GetCategoryCodes(int lcode)
		{
			return CategoryAccess.GetCategoryCodes( lcode );
		}

		/// <summary>
		/// ���ο� ī�װ��� �߰��Ѵ�.
		/// </summary>
		/// <param name="title">�߰��� ī�װ� Ÿ��Ʋ</param>
		/// <param name="node">���</param>
		/// <param name="mode">1:��Ʈ 2:�ڽ� ī�װ�</param>
		public void InsertNewCategory(string title, CategoryNodeValue node, int mode)
		{
			CategoryAccess.InsertNewCategory( title, node, mode );
		}

		/// <summary>
		/// ī�װ� ������ �����Ѵ�.
		/// </summary>
		/// <param name="title">Ÿ��Ʋ</param>
		/// <param name="node">���</param>
		/// <param name="lCode">��з�</param>
		/// <param name="mCode">�ߺз�</param>
		/// <param name="parent">ī�װ� �θ�</param>
		public void UpdateCategoryNodeValue(string title, CategoryNodeValue node, int lCode, int mCode, int newGroup)
		{
			CategoryAccess.UpdateCategoryNodeValue(title, node, lCode, mCode, newGroup);
		}

		/// <summary>
		/// ī�װ��� �����Ѵ�.
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public bool RemoveCategoryNode(CategoryNodeValue node)
		{
			return CategoryAccess.RemoveCategoryNode( node );
		}

		/// <summary>
		/// ī�װ� ��� ��ġ�� �����Ѵ�.
		/// </summary>
		/// <param name="node"></param>
		public bool UpdateMoveCategoryChildNode(CategoryNodeValue node, string mode)
		{
			return CategoryAccess.UpdateMoveCategoryChildNode(node, mode);
		}

		/// <summary>
		/// ī�װ� ������ �̵��Ѵ�.
		/// </summary>
		/// <param name="node">Node</param>
		/// <param name="mode">��� up, down</param>
		/// <returns></returns>
		public bool UpdateMoveCategoryNode(CategoryNodeValue node, string mode)
		{
			return CategoryAccess.UpdateMoveCategoryNode( node, mode );
		}

		#region IManager ���

		public void Dispose()
		{
			instance = null;
		}

		#endregion
	}
}
