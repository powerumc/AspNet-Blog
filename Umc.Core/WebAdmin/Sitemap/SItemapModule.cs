using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Umc.Core.WebAdmin.Sitemap
{
	/// <summary>
	/// 각각의 XML 섹션은 이 클래스를 상속받아 구현하세요
	/// </summary>
	public class SItemapModule : ISitemap
	{
		protected ArrayList sitemap;
		protected ISitemap parent;
		protected string _id;
		protected string _path;
		protected string _title;

		// InitParams 섹션
		protected StringDictionary _initParam = new StringDictionary();

		public SItemapModule(ISitemap _parent)
		{
			this.parent			= _parent;
			this.sitemap		= new ArrayList();
		}
		#region ISitemap 멤버

		/// <summary>
		/// param 설정 내용을 가져온다.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public string GetInitParam(string key)
		{
			string val		= _initParam[ key ];

			if( val != null && val != string.Empty ) return val;

			val				= Parent.GetInitParam( key );

			return val;
		}

		/// <summary>
		/// ID
		/// </summary>
		public string ID
		{
			get { return _id; }
			set { _id = value; }
		}

		/// <summary>
		/// 경로
		/// </summary>
		public string Path
		{
			get { return _path; }
			set { _path = value; }
		}
		/// <summary>
		/// 타이틀
		/// </summary>
		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}
		/// <summary>
		/// 유저 컨트롤의 경로 및 파일명
		/// </summary>
		public virtual string ViewControl
		{
			get { return null; }
			set { throw new Exception("The method or operation is not implemented."); }
		}
		/// <summary>
		/// 노드의 갯수
		/// </summary>
		public int Count
		{
			get { return sitemap.Count; }
		}
		/// <summary>
		/// 열거자를 반환하다
		/// </summary>
		/// <returns></returns>
		public System.Collections.IEnumerator GetEnumerator()
		{
			return sitemap.GetEnumerator();
		}
		/// <summary>
		/// 현재 노드의 부모 Sitemap을 반환한다
		/// </summary>
		public ISitemap Parent
		{
			get { return this.parent; }
		}
		/// <summary>
		/// 노드를 추가한다
		/// </summary>
		/// <param name="sitemap"></param>
		public virtual void Add(ISitemap sitemap)
		{
			this.sitemap.Add( sitemap );
			SitemapManager.GetInstance().SetSitemapByID( sitemap );
		}
		/// <summary>
		/// 현재 노드의 자식 노드가 있는가
		/// </summary>
		public bool HasChild
		{
			get { return sitemap.Count>0; }
		}
		/// <summary>
		/// Xml 을 파싱하는 처리기
		/// </summary>
		/// <param name="reader"></param>
		public virtual void ReadXml(XmlReader reader)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		#endregion

		/// <summary>
		/// InitParams 섹션 처리기
		/// </summary>
		/// <param name="reader"></param>
		public void ReadInitParams(XmlReader reader)
		{
			while (reader.Read())
			{
				if(reader.IsEmptyElement) return;

				if (reader.NodeType == XmlNodeType.Element)
				{
					if (reader.Name == Sitemap.NODE_PARAM)
					{
						string _key		= reader["name"];
						string _value	= reader.ReadElementString();
						_initParam.Add( _key, _value );
					}
				}
				if(reader.Name==Sitemap.NODE_INIT_PARAMS &&
					reader.NodeType==XmlNodeType.EndElement)
					return;
			}
		}
	}
}
