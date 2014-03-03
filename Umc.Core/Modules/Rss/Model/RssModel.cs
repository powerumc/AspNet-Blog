using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;

using Umc.Core.Modules.Blog;
using Umc.Core.Modules.Blog.Model;
using Umc.Core.Modules.Article;
using Umc.Core.Modules.Article.Model;

namespace Umc.Core.Modules.Rss.Model
{
	public abstract class RssModel : IRss
	{
		private string title			= string.Empty;
		private string link				= string.Empty;
		private string description		= string.Empty;
		private string copyright		= string.Empty;
		private string generator		= string.Empty;
		private RssItemBindModel item = new RssItemBindModel();

		public RssModel()
		{
			this.Title		= BlogManager.GetInstance().BlogBaseModel.BlogModel.Title;
			this.Link		= BlogManager.GetInstance().BlogBaseModel.BlogModel.Url;
			this.Description= BlogManager.GetInstance().BlogBaseModel.BlogModel.Introduction;
			this.Copyright	= BlogManager.GetInstance().BlogBaseModel.BlogModel.NickName;
		}

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
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
		public string Copyright
		{
			get { return copyright; }
			set { copyright = value; }
		}
		public string Generator
		{
			get { return generator; }
			set { generator = value; }
		}
		public RssItemBindModel Item
		{
			get { return item; }
		}

		public virtual void FillRss<T>(System.Collections.IEnumerator eData)
		{
			while (eData.MoveNext())
			{
				T data = (T)eData.Current;

				Type type = data.GetType();

				bool publicRss	= (bool)type.GetProperty("PublicRss").GetValue(data, null);

				if( !publicRss) continue;

				RssItemModel model = new RssItemModel();
				int articleNo				= (int)type.GetProperty("ArticleNo").GetValue( data, null );
				model.Title					= type.GetProperty("Title").GetValue( data, null ).ToString();
				model.Link					= Util.Utility.MakeArticleUrl( articleNo );
				model.Description			= type.GetProperty("Content").GetValue(data, null).ToString();
				model.Author				= BlogManager.GetInstance().BlogBaseModel.BlogModel.Name;
				model.PubDate				= type.GetProperty("InsertDate").GetValue(data, null).ToString();
				TagBindModel tagBindModel	= (TagBindModel)type.GetProperty("Tag").GetValue(data,null);
				foreach (TagModel tagModel in tagBindModel)
				{
					model.Category.Add( tagModel );
				}
				
				this.Item.Add( model );
			}
		}

		#region IRss ¸â¹ö

		public virtual TextWriter XmlWriter()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		#endregion
	}
}
