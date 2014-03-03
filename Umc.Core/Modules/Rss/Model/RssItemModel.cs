using System;
using System.Collections.Generic;
using System.Text;

using Umc.Core.Modules.Article.Model;

namespace Umc.Core.Modules.Rss.Model
{
	public class RssItemModel
	{
		private string title;
		private string link;
		private string author;
		private string description;
		private string pubDate;
		private TagBindModel category = new TagBindModel();

		public string Title
		{
			get { return title; }
			set { title = value; }
		}
		public string Link
		{
			get { return link; }
			set { link = value; }
		}
		public string Author
		{
			get { return author; }
			set { author = value; }
		}
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
		public string PubDate
		{
			get { return pubDate; }
			set { pubDate = value; }
		}
		public TagBindModel Category
		{
			get { return category; }
		}
	}
}
