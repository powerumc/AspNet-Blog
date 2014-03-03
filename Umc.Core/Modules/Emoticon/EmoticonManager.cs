using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

using Umc.Core;

namespace Umc.Core.Modules.Emoticon
{
	public class EmoticonManager : IManager
	{
		private EmoticonManager()
		{
		}

		private static EmoticonManager instance = null;

		private List<EmoticonModel> model;

		public static EmoticonManager GetInstance()
		{
			lock (typeof(EmoticonManager))
			{
				if (instance == null)
				{
					instance = new EmoticonManager();
					instance.Init();
				}

				return instance;
			}
		}

		private void Init()
		{
			model	= EmoticonAccess.GetEmoticonList();
		}

		public List<EmoticonModel> Model
		{
			get { return model; }
		}

		/// <summary>
		/// 이모티콘을 저장한다.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="file"></param>
		/// <returns></returns>
		public int InsertEmoticon(EmoticonModel model, HttpPostedFile file)
		{
			return EmoticonAccess.InsertEmoticon( model, file );
		}

		/// <summary>
		/// 이모티콘을 삭제한다.
		/// </summary>
		/// <param name="seqNo"></param>
		public void RemoveEmoticon(int seqNo)
		{
			EmoticonAccess.RemoveEmoticon(seqNo);
		}

		/// <summary>
		/// 이모티콘 리스트를 가져온다.
		/// </summary>
		/// <returns></returns>
		public List<EmoticonModel> GetList()
		{
			return EmoticonAccess.GetEmoticonList();
		}

		/// <summary>
		/// 이모티콘 번호로 가져오기
		/// </summary>
		/// <param name="seqNo"></param>
		/// <returns></returns>
		public EmoticonModel GetEmoticonBySeqNo(int seqNo)
		{
			return EmoticonAccess.GetEmoticonBySeqNo( seqNo );
		}

		public void UpdateEmoticon(EmoticonModel model, HttpPostedFile file)
		{
			EmoticonAccess.UpdateEmoticon( model, file );
		}

		#region IManager 멤버

		public void Dispose()
		{
			instance	= null;
			model		= null;
		}

		#endregion
	}
}
