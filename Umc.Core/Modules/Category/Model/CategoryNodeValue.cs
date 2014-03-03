using System;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Modules.Category.Model
{
	[Serializable]
	public class CategoryNodeValue
	{
		public const string ERR_CATEGORY_NODE_VALUE_PARSE = "err.category.node.value.parse";

		private int _categoryID;
		private int _categoryGroup;
		private int _categoryStep;
		private int _categoryOrder;
		private int _lCode				= -1;

		public CategoryNodeValue(int cateId, int cateGroup, int cateStep, int cateOrder, int lCode)
		{
			this.CategoryID		= cateId;
			this.CategoryGroup	= cateGroup;
			this.CategoryStep	= cateStep;
			this.CategoryOrder	= cateOrder;
			this._lCode			= lCode;
		}

		public int CategoryID
		{
			get { return _categoryID; }
			set { _categoryID = value; }
		}

		public int CategoryGroup
		{
			get { return _categoryGroup; }
			set { _categoryGroup = value; }
		}

		public int CategoryStep
		{
			get { return _categoryStep; }
			set { _categoryStep = value; }
		}

		public int CategoryOrder
		{
			get { return _categoryOrder; }
			set { _categoryOrder = value; }
		}

		public int CategoryLCode
		{
			get { return _lCode; }
			set { _lCode = value; }
		}

		public override string ToString()
		{
			return string.Format("{0},{1},{2},{3},{4}",
								this.CategoryID,
								this.CategoryGroup,
								this.CategoryStep,
								this.CategoryOrder,
								this.CategoryLCode
			);
		}

		public static CategoryNodeValue Parse(string data)
		{
			string[] sp		= data.Split(',');

			if(sp.Length != 5) throw new UmcDataException(ERR_CATEGORY_NODE_VALUE_PARSE);

			int[] isp		= new int[ sp.Length ];

			for (int i = 0; i < sp.Length; i++)
				isp[i]		= int.Parse( sp[i] );
			return new CategoryNodeValue(isp[0], isp[1], isp[2], isp[3], isp[4]);
		}
	}
}
