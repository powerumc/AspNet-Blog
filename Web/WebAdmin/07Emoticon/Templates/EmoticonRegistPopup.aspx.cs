using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Umc.Core.Util;
using Umc.Core.Modules.Emoticon;
using Umc.Core.WebAdmin;

public partial class WebAdmin_07Emoticon_Templates_EmoticonRegistPopup : WebAdminTemplate
{
	private string PARAM_SEQNO = "seqNo";
	private int seqNo;
	private EmoticonModel model;

	protected void Page_Load(object sender, EventArgs e)
	{
		initParam();

		if (IsPostBack) return;

		bind();

	}

	private void initParam()
	{
		seqNo = GetParamInt(PARAM_SEQNO, -1);

		if (seqNo > 0) model = EmoticonManager.GetInstance().GetEmoticonBySeqNo(seqNo);
	}

	private void bind()
	{
		if (seqNo > 0)
		{

			txtString.Text		= model.EmoticonString;
			lblResult.Text		= string.Format("현재 {0} 는 {1} 가 등록되어있습니다",
				model.EmoticonString,
				model.EmoticonValue);
			txtDescription.Text	= model.Description;
		}
	}


	protected void lnkWriteOK_Click(object sender, EventArgs e)
	{
		if (txtString.Text == string.Empty)
		{
			Utility.JS_Alert(sender, EmoticonConst.MESSAGE_EMOTICON_NOT_TITLE);
			return;
		}

		if (seqNo > 0)
		{
			ModifyEmoticon();
		}
		else
		{
			if (file1.PostedFile.FileName == string.Empty && seqNo == -1)
			{
				Utility.JS_Alert(sender, EmoticonConst.MESSAGE_EMOTICON_NOT_IMAGE);
				return;
			}

			InsertEmoticon();
		}

		Update();
	}

	private void ModifyEmoticon()
	{
		EmoticonModel modifyModel	= new EmoticonModel( seqNo );
		modifyModel.EmoticonString	= txtString.Text;
		modifyModel.EmoticonValue	= file1.FileName != string.Empty ? 
			System.IO.Path.GetFileName( file1.FileName ) : model.EmoticonValue;
		modifyModel.Description		= txtDescription.Text;
		modifyModel.InsertDate		= DateTime.Now;

		EmoticonManager.GetInstance().UpdateEmoticon( modifyModel, file1.PostedFile );

		string img = string.Format("<img src='{0}' alt='' />",
			"/Upload/Emoticon/" + modifyModel.EmoticonValue);
		lblResult.Text = string.Format("{0} 는 {1} 로 수정되었습니다.",
			modifyModel.EmoticonString,
			img);
	}

	private void Update()
	{
		Utility.JsCall(this, "update();");
	}

	private void InsertEmoticon()
	{
		EmoticonModel model		= new EmoticonModel();
		model.EmoticonString	= txtString.Text;
		model.EmoticonValue		= System.IO.Path.GetFileName(file1.FileName);
		model.Description		= txtDescription.Text;

		int seqNo = EmoticonManager.GetInstance().InsertEmoticon(model, file1.PostedFile);

		if (seqNo == -1)
		{
			lblResult.Text = string.Format("{0} 는 이미 존재합니다", model.EmoticonString);
			txtString.Text = string.Empty;
			return;
		}

		txtString.Text		= string.Empty;
		txtDescription.Text	= string.Empty;

		string img = string.Format("<img src='{0}' alt='' />",
			"/Upload/Emoticon/" + model.EmoticonValue);
		lblResult.Text = string.Format("{0} 는 {1} 로 저장되었습니다",
			model.EmoticonString,
			img);

		EmoticonManager.GetInstance().Dispose();
	}
}
