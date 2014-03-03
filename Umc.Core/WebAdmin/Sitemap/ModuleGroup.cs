using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Umc.Core.WebAdmin.Sitemap
{
	public class ModuleGroup : SItemapModule
	{
		public ModuleGroup(ISitemap _parent)
			: base(_parent)
		{
		}

		public override void ReadXml(System.Xml.XmlReader reader)
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
					if (reader.Name == Sitemap.NODE_MODULE)
					{
						ModuleInfo moduleInfo	= new ModuleInfo(this);
						moduleInfo.ID			= reader["id"];
						moduleInfo.ViewControl	= reader["viewControl"];
						moduleInfo.ReadXml( reader );

						this.Add(moduleInfo);
					}
					if (reader.Name == Sitemap.NODE_INIT_PARAMS )
						ReadInitParams( reader );
				}
				if(reader.Depth <= depth ) return;
			}
		}
	}
}
