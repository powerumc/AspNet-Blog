using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using Umc.Core.Modules.Snap;

namespace Umc.Core.Modules.Snap
{
	/// <summary>
	/// SnapInfo.Xml 을 담당하는 클래스
	/// </summary>
	public class SnapXml
	{
		public const string PARAM_SNAP				= "snap";
		public const string PARAM_SNAP_MODULE		= "module";
		public const string PARAM_SNAP_ID			= "id";
		public const string PARAM_SNAP_VIEWCONTROL	= "viewControl";
		public const string PARAM_SNAP_CONTENTCONTROL = "contentControl";

		private SnapModel _snapModel	= null;

		public SnapXml()
		{
			_snapModel	= new SnapModel();
		}
		/// <summary>
		/// Xml 을 읽어온다
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static SnapModel ReadXml(string path)
		{
			SnapXml _snapXml		= new SnapXml();

			XmlTextReader reader	= new XmlTextReader( path );

			_snapXml.ReadSnapXml( _snapXml._snapModel, reader );

			reader.Close();

			return _snapXml._snapModel;
		}
		private void ReadSnapXml( SnapModel _snapModel,  XmlReader reader)
		{
			// SnapInfo.Xml 을 읽어 Element 를 검색한다
			while (reader.Read())
			{
				if (reader.Name == PARAM_SNAP && reader.NodeType == XmlNodeType.Element)
				{
					SetSnapModule ( _snapModel,reader );
				}
			}
		}

		private void SetSnapModule(SnapModel _snapModel,XmlReader reader)
		{
			// 검색된 노드를 담는다
			while (reader.Read())
			{
				if (reader.Name == PARAM_SNAP_MODULE && reader.NodeType == XmlNodeType.Element)
				{
					_snapModel.Add( reader[PARAM_SNAP_ID], reader[PARAM_SNAP_VIEWCONTROL], reader[PARAM_SNAP_CONTENTCONTROL]);
				}
			}
		}
	}
}
