using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Web;

using Umc.Core;
using Umc.Core.Data;
using Umc.Core.Modules.Blog;
using Umc.Core.Modules.Blog.Model;

namespace Umc.Core.Modules.Blog
{
	internal class BlogAccess : AbstractDataAccess
	{
		/// <summary>
		/// 내 사진을 가져온다.
		/// </summary>
		/// <returns></returns>
		public static Bitmap GetMyPicture()
		{
			string filename		= BlogManager.GetInstance().BlogBaseModel.BlogModel.Picture;
			string absFilename	= HttpContext.Current.Server.MapPath(filename);

			return new Bitmap(absFilename);
		}

		/// <summary>
		/// 내 사진을 Html 태그로 가져온다.
		/// </summary>
		/// <returns></returns>
		public static string GetMyPictureForImgTag()
		{
			return string.Format("<img src='{0}' alt=''내사진'",
				BlogManager.GetInstance().BlogBaseModel.BlogModel.Picture);
		}
	}
}
