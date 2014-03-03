using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Modules.Category.Model
{
	public class CategoryCodeModel
	{
		private int _categoryCode;
		private string _categoryTitle;
		private ArrayList items;
		private CategoryCodeModel _categoryMCode;

		public CategoryCodeModel this[int index]
		{
			get { return (CategoryCodeModel)items[index]; }
		}

		public CategoryCodeModel()
		{ 
			items = new ArrayList();
		}

		public CategoryCodeModel CreateCategoryMCode()
		{
			_categoryMCode = new CategoryCodeModel();
			return _categoryMCode;
		}

		public CategoryCodeModel(int code, string title)
		{
			this.CategoryCode	= code;
			this.CategoryTitle	= title;
		}

		public CategoryCodeModel CategoryMCode
		{
			get { return _categoryMCode; }
			set { _categoryMCode = value; }
		}

		public int CategoryCode
		{
			get { return _categoryCode; }
			set { _categoryCode = value; }
		}

		public string CategoryTitle
		{
			get { return _categoryTitle; }
			set { _categoryTitle = value; }
		}

		public void Add(CategoryCodeModel code )
		{
			items.Add( code );
		}

		public int Count
		{
			get { return items.Count; }
		}
	}
}
