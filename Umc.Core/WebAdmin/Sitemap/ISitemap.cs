using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Umc.Core.WebAdmin.Sitemap
{
	/// <summary>
	/// ����Ʈ�� �������̽�
	/// </summary>
	public interface ISitemap
	{
		string ID { get; set; }

		string Path { get; set; }

		string Title { get; set; }

		string ViewControl { get; set; }

		int Count { get; }

		IEnumerator GetEnumerator();

		ISitemap Parent { get; }

		void Add(ISitemap sitemap);

		bool HasChild { get; }

		void ReadXml(XmlReader reader);

		string GetInitParam( string key );
	}
}
