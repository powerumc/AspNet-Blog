using System;
using System.Collections.Generic;
using System.Text;

using Umc.Core.Modules.Emoticon;

namespace Umc.Core.Modules.Article.Model
{
	public class ArticleModel
	{
		private int articleNo;
		private int categoryID;
		private int categoryGroup;
		private int categoryStep;
		private int categoryOrder;
		private int categoryLCode;
		private int categoryMCode;
		private string title;
		private string content;
		private int viewCount;
		private string trackbackUrl;
		private int trackbackCount;
		private int commentCount;
		private bool publicFlag;
		private bool publicRss;
		private bool allowComment;
		private bool allowTrackback;
		private object insertDate;
		private object updateDate;
		private string categoryMTitle;
		private TagBindModel tag = new TagBindModel();
		private AttachFileBindModel attachFile = new AttachFileBindModel();

		public ArticleModel(int articleNo)
		{
			this.articleNo = articleNo;
		}
		public ArticleModel()
		{
		}

		public int ArticleNo
		{
			get { return articleNo; }
			set { articleNo = value; }
		}
		public int CategoryID
		{
			get { return categoryID; }
			set { categoryID = value; }
		}
		public int CategoryGroup
		{
			get { return categoryGroup; }
			set { categoryGroup = value; }
		}
		public int CategoryStep
		{
			get { return categoryStep; }
			set { categoryStep = value; }
		}
		public int CategoryOrder
		{
			get { return categoryOrder; }
			set { categoryOrder = value; }
		}
		public int CategoryLCode
		{
			get { return categoryLCode; }
			set { categoryLCode = value; }
		}
		public int CategoryMCode
		{
			get { return categoryMCode; }
			set { categoryMCode = value; }
		}
		public string Title
		{
			get { return title; }
			set { title = value; }
		}
		public string Content
		{
			get { return content; }
			set { content = value; }
		}
		public string TrackbackUrl
		{
			get { return trackbackUrl; }
			set { trackbackUrl = value; }
		}
		public int ViewCount
		{
			get { return viewCount; }
			set { viewCount = value; }
		}
		public int TrackbackCount
		{
			get { return trackbackCount; }
			set { trackbackCount = value; }
		}
		public int CommentCount
		{
			get { return commentCount; }
			set { commentCount = value; }
		}
		public bool PublicFlag
		{
			get { return publicFlag; }
			set { publicFlag = value; }
		}
		public bool PublicRss
		{
			get { return publicRss; }
			set { publicRss = value; }
		}
		public bool AllowComment
		{
			get { return allowComment; }
			set { allowComment = value; }
		}
		public bool AllowTrackback
		{
			get { return allowTrackback; }
			set { allowTrackback = value; }
		}
		public object InsertDate
		{
			get { return insertDate; }
			set { insertDate = value; }
		}
		public object UpdateDate
		{
			get { return updateDate; }
			set { updateDate = value; }
		}
		public string CategoryMTitle
		{
			get { return categoryMTitle; }
			set { categoryMTitle = value; }
		}

		public TagBindModel Tag
		{
			get { return tag; }
			set { tag = value; }
		}

		public AttachFileBindModel AttachFile
		{
			get { return attachFile; }
		}

		public bool NewIcon
		{
			get
			{
				TimeSpan span = DateTime.Now - (DateTime)InsertDate;

				return span.TotalMinutes < 1440 * Blog.BlogManager.GetInstance().BlogBaseModel.BlogModel.PeridoNewIcon;
			}
		}
	}
}
