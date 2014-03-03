using System;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Logger.Model
{
	public class ConnectionLogModel
	{
		private int seqNo;
		private string sessionID;
		private string urlReferrer;
		private DateTime insertDate;
		private string userIP;

		public ConnectionLogModel(string sessionID, string urlReferrer, string userIP)
		{
			this.SessionID		= sessionID;
			this.UrlReferrer	= urlReferrer;
			this.UserIP			= userIP;
		}

		public int SeqNo
		{
			get { return seqNo; }
		}

		public string SessionID
		{
			get { return sessionID; }
			set { sessionID = value; }
		}

		public string UrlReferrer
		{
			get { return urlReferrer; }
			set { urlReferrer = value; }
		}

		public DateTime InsertDate
		{
			get { return insertDate; }
			set { insertDate = value; }
		}

		public string UserIP
		{
			get { return userIP; }
			set { userIP = value; }
		}
	}
}
