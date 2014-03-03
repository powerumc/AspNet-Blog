using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;

namespace Umc.Core.Data
{
	public class RepositoryManager : Umc.Core.Modules.IManager
	{
		private static RepositoryManager instance			= null;
		private static RepositoryAccess repositoryAccess	= null;

		public string RepositoryDirectory
		{
			get { return repositoryAccess.RepositoryDirectory; }
		}

		private RepositoryManager()
		{
		}

		public static RepositoryManager GetInstance()
		{
			lock (typeof(RepositoryManager))
			{
				if (instance == null)
				{
					instance			= new RepositoryManager();
					repositoryAccess	= new RepositoryAccess();
					instance.Init();
				}	
			}

			return instance;
		}

		/// <summary>
		/// Manager Ŭ������ �ʱ�ȭ �Ѵ�.
		/// </summary>
		private void Init()
		{
			repositoryAccess.RepositoryDirectory = HttpContext.Current.Server.MapPath(
				UmcConfiguration.Core["repository.dir"]);
		}

		/// <summary>
		/// ������ �����Ѵ�
		/// </summary>
		/// <param name="repositoryDir">������ ����</param>
		/// <param name="postedFile">PostedFile</param>
		/// <returns></returns>
		public FileInfo SaveAs(string repositoryDir, HttpPostedFile postedFile)
		{
			return repositoryAccess.SaveAs( repositoryDir, postedFile );
		}

		/// <summary>
		/// ������ �����Ѵ�
		/// </summary>
		/// <param name="repositoryDir">������ ����</param>
		/// <param name="postedFile">PostedFile</param>
		/// <param name="saveFilename">����� ���ϸ�</param>
		/// <returns></returns>
		public FileInfo SaveAs(string repositoryDir, HttpPostedFile postedFile, string saveFilename)
		{
			return repositoryAccess.SaveAs( repositoryDir, postedFile, saveFilename );
		}
		#region IDisposable ���

		public void Dispose()
		{
			instance		= null;
		}

		#endregion
	}
}
