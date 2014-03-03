using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;

using Umc.Core.Data;

namespace Umc.Core.Modules.Emoticon
{
	internal class EmoticonAccess : AbstractDataAccess
	{
		/// <summary>
		/// 이모티콘 리스트를 가져온다.
		/// </summary>
		/// <returns></returns>
		public static List<EmoticonModel> GetEmoticonList()
		{
			SqlCommand cmd			= GetSpCommand("UBE_GetEmoticonList");
			SqlDataReader reader	= cmd.ExecuteReader( CommandBehavior.CloseConnection );

			List<EmoticonModel> bindModel	= new List<EmoticonModel>();

			while (reader.Read())
			{
				EmoticonModel model			= new EmoticonModel( (int)reader["SeqNo"] );
				FillEmoticon( reader, model );

				bindModel.Add( model );
				model						= null;
			}

			ReleaseCommand(cmd);

			return bindModel;
		}

		/// <summary>
		/// 이모티콘을 가져온다.
		/// </summary>
		/// <param name="seqNo"></param>
		/// <returns></returns>
		public static EmoticonModel GetEmoticonBySeqNo(int seqNo)
		{
			SqlParameter[] param	= { CreateInParam("@SeqNo", SqlDbType.Int,4,	seqNo ) };

			SqlCommand cmd			= GetSpCommand("UBE_GetEmoticonBySeqNo", param);
			SqlDataReader reader	= cmd.ExecuteReader( CommandBehavior.CloseConnection );

			EmoticonModel model		= new EmoticonModel(seqNo);

			if (reader.Read())
			{
				FillEmoticon( reader, model );
			}
			else
				return null;

			ReleaseCommand(cmd);

			return model;
		}

		/// <summary>
		/// 이모티콘을 저장한다.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="file"></param>
		/// <returns></returns>
		public static int InsertEmoticon(EmoticonModel model, HttpPostedFile file)
		{
			object description = model.Description != null ? (object)model.Description : DBNull.Value;

			SqlParameter[] param = {
				CreateInParam("@String",		SqlDbType.VarChar,50,				model.EmoticonString),
				CreateInParam("@Value",			SqlDbType.VarChar,255,				model.EmoticonValue),
				CreateInParam("@Description",	SqlDbType.Text, Int32.MaxValue,		description),
				CreateReturnValue()
			};

			SqlCommand cmd			= GetSpCommand("UBE_InsertEmoticon", param);

			try
			{
				RepositoryManager.GetInstance().SaveAs("Emoticon", file);

				cmd.ExecuteNonQuery();

				int seqNo			= (int)cmd.Parameters["@ReturnValue"].Value;

				return seqNo;
			}
			catch(Exception e)
			{
				throw new UmcDataException("UBE_InsertEmoticon 프로시져 호출중 에러",e);
			}
			finally
			{
				ReleaseCommand(cmd);
			}
		}

		/// <summary>
		/// 이모티콘을 삭제한다.
		/// </summary>
		/// <param name="seqNo"></param>
		public static void RemoveEmoticon(int seqNo)
		{
			SqlParameter[] param = {
				CreateInParam("@SeqNo",			SqlDbType.Int,4,		seqNo),
				CreateOutParam("@FileName",		SqlDbType.VarChar,255)
			};

			SqlCommand cmd			= GetSpCommand("UBE_RemoveEmoticon", param);

			cmd.ExecuteNonQuery();

			string filename			= cmd.Parameters["@FileName"].Value.ToString();

			string serverPath		= RepositoryManager.GetInstance().RepositoryDirectory + "\\Emoticon\\"+ filename;

			if( File.Exists( serverPath ) ) File.Delete( serverPath );

			ReleaseCommand(cmd);
		}

		public static void UpdateEmoticon(EmoticonModel model, HttpPostedFile file)
		{
			object description = model.Description != null ? (object)model.Description : DBNull.Value;

			SqlParameter[] param = {
				CreateInParam("@SeqNo",			SqlDbType.Int,4,					model.SeqNo),
				CreateInParam("@String",		SqlDbType.VarChar,50,				model.EmoticonString),
				CreateInParam("@Value",			SqlDbType.VarChar,255,				model.EmoticonValue),
				CreateInParam("@Description",	SqlDbType.Text, Int32.MaxValue,		description),
				CreateInParam("@InsertDate",	SqlDbType.DateTime,8,	(DateTime)model.InsertDate),
				CreateOutParam("@OldFileName",	SqlDbType.VarChar,255)
			};

			SqlCommand cmd			= GetSpCommand("UBE_UpdateEmoticon", param);

			cmd.ExecuteNonQuery();

			if ( file.FileName != string.Empty)
			{
				string filename = cmd.Parameters["@OldFileName"].Value.ToString();

				string serverPath = RepositoryManager.GetInstance().RepositoryDirectory + "\\Emoticon\\" + filename;

				if (File.Exists(serverPath)) File.Delete(serverPath);

				RepositoryManager.GetInstance().SaveAs("Emoticon", file);
			}

			ReleaseCommand(cmd);
		}

		private static void FillEmoticon( IDataRecord row, EmoticonModel model)
		{
			model.EmoticonString	= (string)row["String"];
			model.EmoticonValue		= (string)row["Value"];
			model.Description		= row["Description"] != DBNull.Value ? (string)row["Description"] : string.Empty;
			model.InsertDate		= row["InsertDate"];
		}
	}
}
