using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Umc.Core.WebAdmin.Sitemap
{
	public class Sitemap : SItemapModule
	{
		public const string NODE_ADMIN				= "admin";
		public const string NODE_MODULE_GROUP		= "moduleGroup";
		public const string NODE_MODULE				= "module";
		public const string NODE_INIT_PARAMS		= "initParams";
		public const string NODE_PARAM				= "param";
		public const string NODE_TITLE				= "title";

		public Sitemap(ISitemap _parent)
			: base(_parent)
		{
		}
		public Sitemap() : base(null)
		{
		}

		public override void ReadXml(XmlReader reader)
		{
			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element)
				{
					if (reader.Name == NODE_ADMIN)
					{
						this.ID		= reader["id"];
						this.Path	= reader["path"];

						SitemapManager.GetInstance().SetSitemapByID(this);
					}
					if (reader.Name == NODE_TITLE)
					{
						this.Title	= reader.ReadElementString();
					}
					if (reader.Name == NODE_MODULE_GROUP)
					{
						ModuleGroup moduleGroup = new ModuleGroup(this);
						moduleGroup.ID		= reader["id"];
						moduleGroup.Path	= reader["path"];
						moduleGroup.ReadXml(reader);

						this.Add(moduleGroup);
					}
					if(reader.Name == NODE_INIT_PARAMS)
						ReadInitParams( reader );
				}
				if(reader.Name==NODE_ADMIN &&
					reader.NodeType==XmlNodeType.EndElement)
					break;
			}
		}
		/// <summary>
		/// 사이트맵 처리를 시작한다
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static ISitemap ReadSitemap(string path)
		{
			XmlTextReader reader		= null;
			try
			{
				reader			= new XmlTextReader(path);
				ISitemap root	= new Sitemap();

				root.ReadXml( reader );

				return root;
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				reader.Close();
			}
		}
	}
}
