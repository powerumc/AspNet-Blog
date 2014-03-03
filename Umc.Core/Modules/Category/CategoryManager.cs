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
		/// 나의 카테고리를 가져온다
		/// </summary>
		/// <param name="type">바인딩 될 컨트롤 Type의 구현부 Class</param>
		/// <returns></returns>
		public CategoryModel GetMyCategorys(Type type)
		{
			return CategoryAccess.GetMyCategorys(type);
		}

		/// <summary>
		/// 카테고리 코드를 가져온다
		/// </summary>
		/// <param name="lcode">대분류 코드 없을경우 -1</param>
		/// <returns></returns>
		public CategoryCodeModel GetCategoryCodes(int lcode)
		{
			return CategoryAccess.GetCategoryCodes( lcode );
		}

		/// <summary>
		/// 새로운 카테고리를 추가한다.
		/// </summary>
		/// <param name="title">추가될 카테고리 타이틀</param>
		/// <param name="node">노드</param>
		/// <param name="mode">1:루트 2:자식 카테고리</param>
		public void InsertNewCategory(string title, CategoryNodeValue node, int mode)
		{
			CategoryAccess.InsertNewCategory( title, node, mode );
		}

		/// <summary>
		/// 카테고리 정보를 수정한다.
		/// </summary>
		/// <param name="title">타이틀</param>
		/// <param name="node">노드</param>
		/// <param name="lCode">대분류</param>
		/// <param name="mCode">중분류</param>
		/// <param name="parent">카테고리 부모</param>
		public void UpdateCategoryNodeValue(string title, CategoryNodeValue node, int lCode, int mCode, int newGroup)
		{
			CategoryAccess.UpdateCategoryNodeValue(title, node, lCode, mCode, newGroup);
		}

		/// <summary>
		/// 카테고리를 삭제한다.
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public bool RemoveCategoryNode(CategoryNodeValue node)
		{
			return CategoryAccess.RemoveCategoryNode( node );
		}

		/// <summary>
		/// 카테고리 노드 위치를 수정한다.
		/// </summary>
		/// <param name="node"></param>
		public bool UpdateMoveCategoryChildNode(CategoryNodeValue node, string mode)
		{
			return CategoryAccess.UpdateMoveCategoryChildNode(node, mode);
		}

		/// <summary>
		/// 카테고리 구룹을 이동한다.
		/// </summary>
		/// <param name="node">Node</param>
		/// <param name="mode">모드 up, down</param>
		/// <returns></returns>
		public bool UpdateMoveCategoryNode(CategoryNodeValue node, string mode)
		{
			return CategoryAccess.UpdateMoveCategoryNode( node, mode );
		}

		#region IManager 멤버

		public void Dispose()
		{
			instance = null;
		}

		#endregion
	}
}
