using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Umc.Core.Modules.Snap
{
	/// <summary>
	/// Snap Model Å¬·¡½º
	/// </summary>
	public class SnapModel
	{
		private Hashtable snapHash	= new Hashtable();
		private string _id;
		private string _viewControl;
		private string _contentControl;

		public SnapModel()
		{ }

		public SnapModel(string id, string viewControl)
		{
			this._id			= id;
			this._viewControl	= viewControl;
		}

		public SnapModel(string id, string viewControl, string contentControl)
		{
			this._id = id;
			this._viewControl = viewControl;
			this._contentControl = contentControl;
		}

		public SnapModel this[string id]
		{
			get { return (SnapModel)snapHash[id]; }
		}
		public SnapModel this[int index]
		{
			get { return (SnapModel)snapHash[index]; }
		}

		public int Count
		{
			get { return snapHash.Count; }
		}

		public string ID
		{
			get { return _id; }
			set { _id = value; }
		}

		public string ViewControl
		{
			get { return _viewControl; }
			set { _viewControl = value; }
		}

		public string ContentControl
		{
			get { return _contentControl; }
			set { _contentControl = value; }
		}

		public void Add(SnapModel model)
		{
			snapHash.Add( model.ID, model );
		}

		public void Add(string id, string viewControl, string contentControl)
		{
			snapHash.Add( id, new SnapModel(id, viewControl, contentControl));
		}

		public IEnumerator GetEnumerator()
		{
			return snapHash.GetEnumerator();
		}
	}
}
