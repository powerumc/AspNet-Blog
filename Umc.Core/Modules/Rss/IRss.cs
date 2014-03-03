using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace Umc.Core.Modules.Rss
{
	/// <summary>
	/// RSS 인터페이스 선언
	/// </summary>
	public interface IRss
	{
		TextWriter XmlWriter();

		void FillRss<T>(IEnumerator eData);
	}
}
