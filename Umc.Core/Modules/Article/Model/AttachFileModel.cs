using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Umc.Core.Modules.Article.Model
{
	public class AttachFileModel
	{
		private int fileNo;
		private int articleNo;
		private string filePath;
		private int fileSize;
		private int downCount;
		private DateTime insertDate;

		public AttachFileModel()
		{
		}

		public AttachFileModel(int fileNo)
		{
			this.fileNo = fileNo;
		}

		public int FileNo
		{
			get { return fileNo; }
		}

		public int ArticleNo
		{
			get { return articleNo; }
			set { articleNo = value; }
		}
		public string FileName
		{
			get { return Path.GetFileName( FilePath ); }
		}
		public string FilePath
		{
			get { return filePath; }
			set { filePath = value; }
		}
		public int FileSize
		{
			get { return fileSize; }
			set { fileSize = value; }
		}
		public int DownCount
		{
			get { return downCount; }
			set { downCount = value; }
		}
		public DateTime InsertDate
		{
			get { return insertDate; }
			set { insertDate = value; }
		}
	}
}
