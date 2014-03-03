using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Collections.Specialized;

using Umc.Core.Modules.Category.Model;
using Umc.Core.Modules.Article.Model;

namespace Umc.Core.Modules.Article
{
	public class ArticleManager : IManager
	{
		private static ArticleManager instance	= null;

		public static ArticleManager GetInstance()
		{
			lock (typeof(ArticleManager))
			{
				if( instance == null )
					instance = new ArticleManager();
			}

			return instance;
		}

		#region ��ƼŬ ����
		/// <summary>
		/// ��ƼŬ�� �����Ѵ�.
		/// </summary>
		/// <param name="model"></param>
		public int InsertArticle( ArticleModel model, HttpFileCollection fileCollection)
		{
			return ArticleAccess.InsertArticle( model, fileCollection );
		}

		/// <summary>
		/// ��ƼŬ�� �����Ѵ�.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="fileCollection"></param>
		/// <returns></returns>
		public bool UpdateArticle(ArticleModel model, HttpFileCollection fileCollection)
		{
			return ArticleAccess.UpdateArticle( model, fileCollection );
		}

		public bool RemoveArticleByNo(int articleNo)
		{
			return ArticleAccess.RemoveArticleByNo(articleNo);
		}

		/// <summary>
		/// ī�װ��� ��ƼŬ ����Ʈ�� �����´�
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public ArticleBindModel GetArticleList(CategoryNodeValue node)
		{
			return ArticleAccess.GetArticleList( node );
		}

		/// <summary>
		/// ��¥���� ��ƼŬ�� �����´�.
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public ArticleBindModel GetArticleList(string date)
		{
			return ArticleAccess.GetArticleList(date);
		}

		/// <summary>
		/// ��¥�� �׷����� �����´�.
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public NameValueCollection GetArticleListGroupByDate(string date)
		{
			return ArticleAccess.GetArticleListGroupByDate(date);
		}

		/// <summary>
		/// �˻� �Ǵ� ������ ���� ��ƼŬ�� �����´�.
		/// </summary>
		/// <param name="currentPage"></param>
		/// <param name="pageCount"></param>
		/// <param name="searchMode"></param>
		/// <param name="searchKeyword"></param>
		/// <param name="publicArticle">��������Ʈ true / ����� ����Ʈ���� false</param>
		/// <returns></returns>
		public ArticleBindModel GetArticleList(int currentPage, int pageCount, string searchMode, string searchKeyword, bool publicArticle)
		{
			return ArticleAccess.GetArticleList( currentPage, pageCount, searchMode, searchKeyword, publicArticle );
		}

		/// <summary>
		/// �±׷� ��ƼŬ�� �����´�.
		/// </summary>
		/// <param name="currentPage"></param>
		/// <param name="pageCount"></param>
		/// <param name="searchMode"></param>
		/// <param name="searchKeyword"></param>
		/// <param name="publicArticle"></param>
		/// <returns></returns>
		public ArticleBindModel GetArticleListByTag(string tag, bool publicArticle)
		{
			return ArticleAccess.GetArticleListByTag( tag, publicArticle );
		}

		/// <summary>
		/// ��ƼŬ ��ȣ�� �����´�.
		/// </summary>
		/// <param name="articleNo"></param>
		/// <returns></returns>
		public ArticleModel GetArticleByArticleNo(int articleNo)
		{
			return ArticleAccess.GetArticleByArticleNo( articleNo );
		}

		public ArticleBindModel GetRecentArticleList(int count)
		{
			return ArticleAccess.GetRecentArticleList( count );
		}
		#endregion

		#region �±� ����
		/// <summary>
		/// �±� ����� �����´�.
		/// </summary>
		/// <returns></returns>
		public TagBindModel GetTagList()
		{
			return ArticleAccess.GetTagList();
		}
		/// <summary>
		/// �±� �̸����� ��ƼŬ�� �±׸� �����Ѵ�.
		/// </summary>
		/// <param name="tagName"></param>
		public void RemoveTagByTagName(string tagName)
		{
			ArticleAccess.RemoveTagByTagName( tagName );
		}
		#endregion

		#region ÷������ ����
		/// <summary>
		/// ÷�������� �����´�.
		/// </summary>
		/// <param name="fileNo"></param>
		/// <returns></returns>
		public AttachFileModel GetAttachFileByFileNo(int fileNo)
		{
			return ArticleAccess.GetAttachFileByFileNo( fileNo );
		}
		/// <summary>
		/// ÷�������� �����Ѵ�. ���� ���ϵ� �����ȴ�.
		/// </summary>
		/// <param name="fileNo"></param>
		/// <returns></returns>
		public bool RemoveAttachFileByFileNo(int fileNo)
		{
			return ArticleAccess.RemoveAttachFileByFileNo( fileNo );
		}
		#endregion

		/// <summary>
		/// ��ƼŬ�� ��� ������ ������Ų��. ( ������� ���� )
		/// </summary>
		/// <param name="articleNo"></param>
		/// <param name="addNumber"></param>
		public void AddCommentCount(int articleNo, int addNumber)
		{
			ArticleAccess.AddCommentCount(articleNo, addNumber);
		}

		/// <summary>
		/// ÷������ �ٿ�Ƚ���� ������Ų��.
		/// </summary>
		/// <param name="fileNo"></param>
		public void AddDownloadCount(int fileNo)
		{
			ArticleAccess.AddDownloadCount( fileNo );
		}

		#region IManager ���

		public void Dispose()
		{
			instance = null;
		}

		#endregion

	}
}
