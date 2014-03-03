using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Umc.Core.WebAdmin.Sitemap
{
	public class ModuleInfo : SItemapModule
	{
		private string _viewControl		= null;
		public ModuleInfo(ISitemap _parent)
			: base(_parent)
		{
		}

		public override string ViewControl
		{
			get { return _viewControl; }
			set { _viewControl = value; }
		}

		public override void ReadXml(XmlReader reader)
		{
			int depth	= reader.Depth;

			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element)
				{
					if (reader.Name == Sitemap.NODE_TITLE)
					{
						this.Title	= reader.ReadElementString();
					}
					if (reader.Name == Sitemap.NODE_INIT_PARAMS)
					{
						ReadInitParams( reader );
					}
				}

				if(reader.Name==Sitemap.NODE_MODULE && 
					reader.NodeType==XmlNodeType.EndElement)
					return;
			}
		}
	}
}
