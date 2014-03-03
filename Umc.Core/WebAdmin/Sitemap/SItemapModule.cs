using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Umc.Core.WebAdmin.Sitemap
{
	/// <summary>
	/// ������ XML ������ �� Ŭ������ ��ӹ޾� �����ϼ���
	/// </summary>
	public class SItemapModule : ISitemap
	{
		protected ArrayList sitemap;
		protected ISitemap parent;
		protected string _id;
		protected string _path;
		protected string _title;

		// InitParams ����
		protected StringDictionary _initParam = new StringDictionary();

		public SItemapModule(ISitemap _parent)
		{
			this.parent			= _parent;
			this.sitemap		= new ArrayList();
		}
		#region ISitemap ���

		/// <summary>
		/// param ���� ������ �����´�.
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
		/// ���
		/// </summary>
		public string Path
		{
			get { return _path; }
			set { _path = value; }
		}
		/// <summary>
		/// Ÿ��Ʋ
		/// </summary>
		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}
		/// <summary>
		/// ���� ��Ʈ���� ��� �� ���ϸ�
		/// </summary>
		public virtual string ViewControl
		{
			get { return null; }
			set { throw new Exception("The method or operation is not implemented."); }
		}
		/// <summary>
		/// ����� ����
		/// </summary>
		public int Count
		{
			get { return sitemap.Count; }
		}
		/// <summary>
		/// �����ڸ� ��ȯ�ϴ�
		/// </summary>
		/// <returns></returns>
		public System.Collections.IEnumerator GetEnumerator()
		{
			return sitemap.GetEnumerator();
		}
		/// <summary>
		/// ���� ����� �θ� Sitemap�� ��ȯ�Ѵ�
		/// </summary>
		public ISitemap Parent
		{
			get { return this.parent; }
		}
		/// <summary>
		/// ��带 �߰��Ѵ�
		/// </summary>
		/// <param name="sitemap"></param>
		public virtual void Add(ISitemap sitemap)
		{
			this.sitemap.Add( sitemap );
			SitemapManager.GetInstance().SetSitemapByID( sitemap );
		}
		/// <summary>
		/// ���� ����� �ڽ� ��尡 �ִ°�
		/// </summary>
		public bool HasChild
		{
			get { return sitemap.Count>0; }
		}
		/// <summary>
		/// Xml �� �Ľ��ϴ� ó����
		/// </summary>
		/// <param name="reader"></param>
		public virtual void ReadXml(XmlReader reader)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		#endregion

		/// <summary>
		/// InitParams ���� ó����
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
