using System;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Modules.Emoticon
{
	public class EmoticonModel
	{
		private int seqNo;
		private string emoticonString;
		private string emoticonValue;
		private string description;
		private object insertdate;

		public EmoticonModel()
		{
		}

		public EmoticonModel(int seqNo)
		{
			this.seqNo = seqNo;
		}

		public int SeqNo
		{
			get { return seqNo; }
		}
		public string EmoticonString
		{
			get { return emoticonString; }
			set { emoticonString = value; }
		}
		public string EmoticonValue
		{
			get { return emoticonValue; }
			set { emoticonValue = value; }
		}
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
		public object InsertDate
		{
			get { return insertdate; }
			set { insertdate = value; }
		}
	}
}
