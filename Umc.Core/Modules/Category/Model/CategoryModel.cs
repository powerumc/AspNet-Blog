using System;
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Umc.Core.Modules.Category.Model
{
	public class CategoryModel : ICategory
	{
		protected int _categoryID;
		protected string _categoryTitle;
		protected int _categoryLCode;
		protected int _categoryMCode;
		protected int _categoryGroup;
		protected int _categoryStep;
		protected int _categoryOrder;
		protected int _articleCount;
		protected bool _newIcon;
		protected ArrayList items = new ArrayList();

		public ICategory GetICategory
		{
			get { return (ICategory)this; }
		}
		public CategoryModel this[int index]
		{
			get { return (CategoryModel)items[index]; }
		}

		public void Add(CategoryModel model)
		{
			items.Add(model);
		}

		public int Count
		{
			get { return items.Count; }
		}

		public IEnumerator GetEnumerator()
		{
			return items.GetEnumerator();
		}

		/// <summary>
		/// ī�װ� ID
		/// </summary>
		public int CategoryID
		{
			get { return _categoryID; }
			set { _categoryID = value; }
		}
		/// <summary>
		/// ī�װ� Ÿ��Ʋ
		/// </summary>
		public string CategoryTitle
		{
			get { return _categoryTitle; }
			set { _categoryTitle = value; }
		}
		/// <summary>
		/// ��з� �ڵ�
		/// </summary>
		public int CategoryLCode
		{
			get { return _categoryLCode; }
			set { _categoryLCode = value; }
		}
		/// <summary>
		/// �ߺз� �ڵ�
		/// </summary>
		public int CategoryMCode
		{
			get { return _categoryMCode; }
			set { _categoryMCode = value; }
		}
		/// <summary>
		/// ī�װ� ����
		/// </summary>
		public int CategoryGroup
		{
			get { return _categoryGroup; }
			set { _categoryGroup = value; }
		}
		/// <summary>
		/// ī�װ� �鿩����
		/// </summary>
		public int CategoryStep
		{
			get { return _categoryStep; }
			set { _categoryStep = value; }
		}
		/// <summary>
		/// ī�װ��� ���ļ���
		/// </summary>
		public int CategoryOrder
		{
			get { return _categoryOrder; }
			set { _categoryOrder = value; }
		}
		public int ArticleCount
		{
			get { return _articleCount; }
			set { _articleCount = value; }
		}
		public bool NewIcon
		{
			get { return _newIcon; }
			set { _newIcon = value; }
		}

		#region ICategory ���

		public virtual void Bind(System.Web.UI.Control control)
		{
			throw new UmcException("���� Ŭ�������� �����ϼ���");
		}
		public CategoryNodeValue NodeValue
		{
			get 
			{
				return new CategoryNodeValue(
								this.CategoryID,
								this.CategoryGroup,
								this.CategoryStep,
								this.CategoryOrder,
								this.CategoryLCode
								);
			}
		}

		#endregion
	}

	public class CategoryBindModel : CategoryModel, IListSource
	{
		#region IListSource ���

		public bool ContainsListCollection
		{
			get { return false; }
		}

		public IList GetList()
		{
			return (IList)items;
		}

		#endregion
	}
}
