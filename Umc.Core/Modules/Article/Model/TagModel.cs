using System;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Modules.Article.Model
{
	public class TagModel
	{
		private int tagNo;
		private string tagName;
		private DateTime insertDate;

		public TagModel()
		{
		}

		public TagModel(int tagNo)
		{
			this.tagNo = tagNo;
		}

		public TagModel(string tagName)
		{
			this.TagName = tagName;
		}

		public TagModel(int tagNo, string tagName)
		{
			this.tagNo		= tagNo;
			this.TagName	= tagName;
		}

		public TagModel(int tagNo, string tagName, DateTime insertDate)
		{
			this.tagNo		= tagNo;
			this.tagName	= tagName;
			this.insertDate	= insertDate;
		}

		public int TagNo
		{
			get { return tagNo; }
		}

		public string TagName
		{
			get { return tagName; }
			set { tagName = value; }
		}

		public DateTime InsertDate
		{
			get { return insertDate; }
			set { insertDate = value; }
		}

		public static string Parse(TagBindModel model)
		{
			string[] tag = new string[model.Count];

			for(int i=0; i<model.Count; i++)
				tag[i] = model[i].TagName;

			return string.Join(",", tag);
		}
	}
}
