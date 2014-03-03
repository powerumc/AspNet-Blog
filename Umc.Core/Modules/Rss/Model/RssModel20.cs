using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Web;

using Umc.Core.Modules.Blog;
using Umc.Core.Modules.Blog.Model;
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Article.Model;

namespace Umc.Core.Modules.Rss.Model
{
	public class RssModel20 : RssModel
	{
		public RssModel20()
			: base()
		{
		}

		/// <summary>
		/// RSS 를 XML 로 쓴다.
		/// </summary>
		/// <returns></returns>
		public override TextWriter  XmlWriter()
		{
			TextWriter tw = new StringWriter();
			XmlTextWriter writer = new XmlTextWriter(tw);

			writer.Formatting	= Formatting.Indented;
			writer.Indentation	= 4;

			BlogBaseModel blogModel = BlogManager.GetInstance().BlogBaseModel;

			writer.WriteStartElement("rss");
				writer.WriteAttributeString("version","2.0");
				
				writer.WriteStartElement("channel");
					writer.WriteElementString("title", this.Title);
					writer.WriteElementString("link", this.Link );
					writer.WriteElementString("description", this.Description);
					writer.WriteElementString("copyright",this.Copyright);
					writer.WriteElementString("generator",this.Generator);
					
					foreach (RssItemModel model in this.Item)
					{
						writer.WriteStartElement("item");

						writer.WriteElementString("title", model.Title );
						writer.WriteElementString("link", model.Link );
						//writer.WriteStartElement("description");
						//	writer.WriteCData( model.Description );
						//writer.WriteEndElement();
						writer.WriteElementString("author", model.Author );
						writer.WriteElementString("pubDate", model.PubDate);

						foreach (TagModel tagModel in model.Category)
						{
							writer.WriteElementString("category", tagModel.TagName);
						}

						writer.WriteEndElement();

					}
				writer.WriteEndElement();
			writer.WriteEndElement();

			return tw;
		}
	}
}
