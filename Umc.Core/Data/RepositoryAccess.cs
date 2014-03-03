using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;

namespace Umc.Core.Data
{
	internal class RepositoryAccess
	{
		private string _repositoryDirectory;

		public string RepositoryDirectory
		{
			get { return _repositoryDirectory; }
			set { _repositoryDirectory = value; }
		}

		public FileInfo SaveAs(string repositoryDir, HttpPostedFile postedFile)
		{
			return SaveAs(repositoryDir, postedFile, null);
		}

		public FileInfo SaveAs(string repositoryDir, HttpPostedFile postedFile, string saveFilename)
		{
			// 폴더가 없으면 새로 만든다
			string folder	= RepositoryDirectory + "/" + repositoryDir;
			if( !Directory.Exists( folder ))
				Directory.CreateDirectory( folder );

			// {0} : Web.config 에 지정된 upload 폴더
			// {1} : 상세 폴더
			// {2} : 파일명
			
			string fileName;
			if (saveFilename == null)
				fileName	= Path.GetFileName(postedFile.FileName);
			else
				fileName	= saveFilename;

			string saveFullName	= string.Format("{0}/{1}/{2}",
				RepositoryDirectory,
				repositoryDir,
				fileName );

			postedFile.SaveAs(saveFullName);

			return new FileInfo( saveFullName );
		}
	}
}
