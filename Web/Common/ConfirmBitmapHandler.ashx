<%@ WebHandler Language="C#" Class="ConfirmBitmapHandler" %>

using System;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Web.SessionState;

using Umc.Core;

public class ConfirmBitmapHandler : IHttpHandler, IRequiresSessionState {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "image/jpeg";
		
		int lenX = 80, lenY = 30;
		
		Bitmap bm		= new Bitmap( lenX, lenY );
		
		Graphics g		= Graphics.FromImage( bm );
		
		LinearGradientBrush bgGr = new LinearGradientBrush(
			new Point(0,0),
			new Point(lenX, lenY),
			Color.Blue,
			Color.Black);
		
		g.FillRectangle( bgGr, 0, 0, lenX, lenY );
				
		string text = string.Empty;
		Random rnd = new Random();
		for(int i=0; i<5; i++)
		{
			text += rnd.Next(10).ToString();
		}
		
		Brush textBrush	= new SolidBrush( Color.White );
		g.DrawString( text, new Font("굴림", 15), textBrush, 10, 5, StringFormat.GenericDefault );
		
		bm.Save( context.Response.OutputStream, ImageFormat.Jpeg );
		
		context.Session[ Parameters.SESSION_CONFIRM_VALIDATE_STRING ] = text;
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}