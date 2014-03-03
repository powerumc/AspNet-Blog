using System;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Modules.Breaker
{
	public class BreakerModel
	{
		public BreakerModel()
		{
		}

		public BreakerModel(int seqNo)
		{
			this.seqNo = seqNo;
		}

		private int seqNo;
		private string userIP;
		private object insertDate;

		public int SeqNo
		{
			get { return seqNo; }
			set { seqNo = value; }
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
