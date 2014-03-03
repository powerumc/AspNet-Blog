using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Umc.Core.Web
{
	/// <summary>
	/// UmcMarkImageHandler의 요약 설명입니다.
	/// </summary>
	public class UmcMarkImageHandler : IHttpHandler
	{
		public UmcMarkImageHandler()
		{
		}

		#region IHttpHandler 멤버

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}

		public void ProcessRequest(HttpContext context)
		{
			string filename = context.Request.Path;

			string fn = Path.GetFileName(filename).ToLower();

			string ext = Path.GetExtension(fn);

			if (!(ext == ".mark"))
			{
				System.Drawing.Image nonImg = System.Drawing.Image.FromFile(context.Server.MapPath(filename));

				nonImg.Save(context.Response.OutputStream, ImageFormat.Jpeg);

				nonImg.Dispose();

				return;
			}

			System.Drawing.Image img = System.Drawing.Image.FromFile(context.Server.MapPath(filename));

			Bitmap bitmap = new Bitmap(img.Width, img.Height);

			Graphics g = Graphics.FromImage(bitmap);

			g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

			System.Drawing.Image imgText = System.Drawing.Image.FromFile(context.Server.MapPath("/common/images/mark.gif"));

			float[][] matrixItems ={ 
								   new float[] {1, 0, 0, 0, 0},
								   new float[] {0, 1, 0, 0, 0},
								   new float[] {0, 0, 1, 0, 0},
								   new float[] {0, 0, 0, 0.8f, 0}, 
								   new float[] {0, 0, 0, 0, 1}};
			ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

			ImageAttributes imageAtt = new ImageAttributes();
			imageAtt.SetColorMatrix(
				colorMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap);

			g.DrawImage(imgText,
				new Rectangle(0, 0, img.Width, img.Height),
				0,
				0,
				imgText.Width,
				imgText.Height,
				GraphicsUnit.Pixel,
				imageAtt);

			g.DrawImage(img,
				new Rectangle(0, 0, img.Width, img.Height),
				0,
				0,
				img.Width,
				img.Height,
				GraphicsUnit.Pixel,
				imageAtt);

			bitmap.Save(context.Response.OutputStream, ImageFormat.Jpeg);

			g.Dispose();
			img.Dispose();
			imgText.Dispose();
			bitmap.Dispose();
		}

		#endregion
	}
}