using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Umc.Core.Util;

namespace Umc.Core.WebAdmin.Sitemap
{
	public class SitemapManager : Umc.Core.Modules.IManager
	{
		private static SitemapManager _instance		= null;
		private ISitemap _sitemap;
		private Hashtable _hashSitemap;

		public ISitemap SiteInfo
		{
			get { return _sitemap; }
		}

		/// <summary>
		/// 각 섹션의 ID 로 사이트맵을 가져온다.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ISitemap GetSitemapByID(string id)
		{
			return (ISitemap)_hashSitemap[id];
		}

		/// <summary>
		/// 사이트맵을 해당 ID 로 저장한다.
		/// </summary>
		/// <param name="_hash"></param>
		public void SetSitemapByID(ISitemap _hash)
		{
			_hashSitemap.Add( _hash.ID, _hash );
		}

		private SitemapManager()
		{
		}

		public static SitemapManager GetInstance()
		{
			lock (typeof(SitemapManager))
			{
				if (_instance == null)
				{
					_instance = new SitemapManager();
					_instance.Init();
				}

				return _instance;
			}

		}

		public void Init()
		{
			string path	= Utility.GetAbsolutePath( Umc.Core.UmcConfiguration.Core["AdminXmlPath"]);
			_hashSitemap	= new Hashtable();
			_sitemap		= Sitemap.ReadSitemap(path);
		}

		/// <summary>
		/// 사이트맵을 다시 로드하기위해..
		/// </summary>
		public void ReConfig()
		{
			Dispose();
		}

		// 재귀호출로 네비게이트 문자열을 가져온다
		public string GetNavigateString(ISitemap _map)
		{
			ISitemap _tempSitemap		= _map;
			StringBuilder naviString	= new StringBuilder();

			naviString.Insert(0, _tempSitemap.Title);

			while (_tempSitemap.Parent != null)
			{
				naviString.Insert(0, _tempSitemap.Parent.Title + " > " );
				_tempSitemap	= _tempSitemap.Parent;
			}

			return naviString.ToString();
		}

		#region IManager 멤버

		public void Dispose()
		{
			_instance		= null;
			_hashSitemap	= null;
		}

		#endregion
	}
}
