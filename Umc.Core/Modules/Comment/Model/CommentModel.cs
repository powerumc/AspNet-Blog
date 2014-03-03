using System;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Modules.Comment.Model
{
	public class CommentModel
	{
		private int commentNo;
		private int articleNo;
		private int commentGroup;
		private int commentOrder;
		private int commentStep;
		private string userEmail;
		private string userName;
		private string userBlogUrl;
		private string content;
		private string password;
		private string userIP;
		private object insertDate;
		private object updateDate;
		private CommentAttribute commentType;

		public CommentModel() { }

		public CommentModel(int articleNo)
		{
			this.articleNo = articleNo;
		}

		public int CommentNo
		{
			get { return commentNo; }
			set { commentNo = value; }
		}
		public int ArticleNo
		{
			get { return articleNo; }
			set { articleNo = value; }
		}
		public int CommentGroup
		{
			get { return commentGroup; }
			set { commentGroup = value; }
		}
		public int CommentOrder
		{
			get { return commentOrder; }
			set { commentOrder = value; }
		}
		public int CommentStep
		{
			get { return commentStep; }
			set { commentStep = value; }
		}
		public string UserEmail
		{
			get { return userEmail; }
			set { userEmail = value; }
		}
		public string UserName
		{
			get { return userName; }
			set { userName = value; }
		}
		public string UserBlogUrl
		{
			get { return userBlogUrl; }
			set { userBlogUrl = value; }
		}
		public string Content
		{
			get { return content; }
			set { content = value; }
		}
		public string Password
		{
			get { return password; }
			set { password = value; }
		}
		public string UserIP
		{
			get { return userIP; }
			set { userIP = value; }
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
		public CommentAttribute CommentType
		{
			get { return commentType; }
			set { commentType = value; }
		}

		public bool NewIcon
		{
			get
			{
				TimeSpan span = DateTime.Now - (DateTime)insertDate;

				return span.TotalMinutes < 1440 * Blog.BlogManager.GetInstance().BlogBaseModel.BlogModel.PeridoNewIcon;
			}
		}
	}
}
