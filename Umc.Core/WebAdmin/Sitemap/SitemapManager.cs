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
		/// �� ������ ID �� ����Ʈ���� �����´�.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ISitemap GetSitemapByID(string id)
		{
			return (ISitemap)_hashSitemap[id];
		}

		/// <summary>
		/// ����Ʈ���� �ش� ID �� �����Ѵ�.
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
		/// ����Ʈ���� �ٽ� �ε��ϱ�����..
		/// </summary>
		public void ReConfig()
		{
			Dispose();
		}

		// ���ȣ��� �׺����Ʈ ���ڿ��� �����´�
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

		#region IManager ���

		public void Dispose()
		{
			_instance		= null;
			_hashSitemap	= null;
		}

		#endregion
	}
}
