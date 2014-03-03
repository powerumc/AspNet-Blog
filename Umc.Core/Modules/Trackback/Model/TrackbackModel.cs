using System;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Modules.Trackback
{
	public class TrackbackModel
	{
		private int seqNo;
		private int articleNo;
		private string url;
		private string blog_name;
		private string title;
		private string exceprt;
		private string userIP;
		private object insertDate;

		public TrackbackModel()
		{
		}

		public TrackbackModel(int seqNo)
		{
			this.seqNo			= seqNo;
		}

		public int SeqNo
		{
			get { return seqNo; }
		}

		public int ArticleNo
		{
			get { return articleNo; }
			set { articleNo = value; }
		}

		public string Url
		{
			get { return url; }
			set { url = value; }
		}

		public string Blog_Name
		{
			get { return blog_name; }
			set { blog_name = value; }
		}

		public string Title
		{
			get { return title; }
			set { title = value; }
		}

		public string Exceprt
		{
			get { return exceprt; }
			set { exceprt = value; }
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
	}
}
