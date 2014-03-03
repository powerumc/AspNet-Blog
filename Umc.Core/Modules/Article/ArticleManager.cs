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

		#region 아티클 관련
		/// <summary>
		/// 아티클을 저장한다.
		/// </summary>
		/// <param name="model"></param>
		public int InsertArticle( ArticleModel model, HttpFileCollection fileCollection)
		{
			return ArticleAccess.InsertArticle( model, fileCollection );
		}

		/// <summary>
		/// 아티클을 수정한다.
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
		/// 카테고리의 아티클 리스트를 가져온다
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public ArticleBindModel GetArticleList(CategoryNodeValue node)
		{
			return ArticleAccess.GetArticleList( node );
		}

		/// <summary>
		/// 날짜별로 아티클을 가져온다.
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public ArticleBindModel GetArticleList(string date)
		{
			return ArticleAccess.GetArticleList(date);
		}

		/// <summary>
		/// 날짜별 그룹으로 가져온다.
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public NameValueCollection GetArticleListGroupByDate(string date)
		{
			return ArticleAccess.GetArticleListGroupByDate(date);
		}

		/// <summary>
		/// 검색 또는 페이지 별로 아티클을 가져온다.
		/// </summary>
		/// <param name="currentPage"></param>
		/// <param name="pageCount"></param>
		/// <param name="searchMode"></param>
		/// <param name="searchKeyword"></param>
		/// <param name="publicArticle">공개포스트 true / 비공개 포스트포함 false</param>
		/// <returns></returns>
		public ArticleBindModel GetArticleList(int currentPage, int pageCount, string searchMode, string searchKeyword, bool publicArticle)
		{
			return ArticleAccess.GetArticleList( currentPage, pageCount, searchMode, searchKeyword, publicArticle );
		}

		/// <summary>
		/// 태그로 아티클을 가져온다.
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
		/// 아티클 번호로 가져온다.
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

		#region 태그 관련
		/// <summary>
		/// 태그 목록을 가져온다.
		/// </summary>
		/// <returns></returns>
		public TagBindModel GetTagList()
		{
			return ArticleAccess.GetTagList();
		}
		/// <summary>
		/// 태그 이름으로 아티클의 태그를 삭제한다.
		/// </summary>
		/// <param name="tagName"></param>
		public void RemoveTagByTagName(string tagName)
		{
			ArticleAccess.RemoveTagByTagName( tagName );
		}
		#endregion

		#region 첨부파일 관련
		/// <summary>
		/// 첨부파일을 가져온다.
		/// </summary>
		/// <param name="fileNo"></param>
		/// <returns></returns>
		public AttachFileModel GetAttachFileByFileNo(int fileNo)
		{
			return ArticleAccess.GetAttachFileByFileNo( fileNo );
		}
		/// <summary>
		/// 첨부파일을 삭제한다. 실제 파일도 삭제된다.
		/// </summary>
		/// <param name="fileNo"></param>
		/// <returns></returns>
		public bool RemoveAttachFileByFileNo(int fileNo)
		{
			return ArticleAccess.RemoveAttachFileByFileNo( fileNo );
		}
		#endregion

		/// <summary>
		/// 아티클의 댓글 갯수를 증가시킨다. ( 사용하지 않음 )
		/// </summary>
		/// <param name="articleNo"></param>
		/// <param name="addNumber"></param>
		public void AddCommentCount(int articleNo, int addNumber)
		{
			ArticleAccess.AddCommentCount(articleNo, addNumber);
		}

		/// <summary>
		/// 첨부파일 다운횟수를 증가시킨다.
		/// </summary>
		/// <param name="fileNo"></param>
		public void AddDownloadCount(int fileNo)
		{
			ArticleAccess.AddDownloadCount( fileNo );
		}

		#region IManager 멤버

		public void Dispose()
		{
			instance = null;
		}

		#endregion

	}
}
