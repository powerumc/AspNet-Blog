using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Umc.Core.Web;
using Umc.Core.Web.Controls;
using Umc.Core.Modules.Comment.Model;

namespace Umc.Core.Modules.Comment
{
	public enum CommentAttribute
	{
		New = 0,		// 새 댓글
		Reply = 1		// 답변 댓글
	}

	public class CommentManager : IManager
	{
		private static CommentManager instance = null;

		public static CommentManager GetInstance()
		{
			lock (typeof(CommentManager))
			{
				if( instance == null )
					instance = new CommentManager();

				return instance;
			}
		}

		/*
		public Control LoadCommentControl(object form, int articleNo)
		{
			if( form is Page )
			{
				UmcBlogBasePage template = (UmcBlogBasePage)((Page)form).LoadControl(CommentConst.PARAM_COMMENT_CONTROL_PATH);

				return template;
			} 
			else if( form is UserControl )
			{
				UmcContentsCommonPage template = (UmcContentsCommonPage)((UserControl)form).LoadControl(CommentConst.PARAM_COMMENT_CONTROL_PATH);
				
				return template;
			}

			throw new UmcException("Comment 컨트롤을 로드할 수 없습니다");
		}
		*/

		/// <summary>
		/// 댓글 저장
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public int InsertComment(CommentModel model)
		{
			return CommentAccess.InsertComment(model);
		}

		/// <summary>
		/// 댓글리스트를 가져온다.
		/// </summary>
		/// <param name="articleNo"></param>
		/// <returns></returns>
		public CommentBindModel GetCommentList(int articleNo)
		{
			return CommentAccess.GetCommentList(articleNo);
		}

		/// <summary>
		/// 댓글을 삭제한다.
		/// </summary>
		/// <param name="commentNo"></param>
		/// <returns></returns>
		public int RemoveComment(int commentNo)
		{
			return CommentAccess.RemoveComment(commentNo);
		}

		/// <summary>
		/// 댓글 하나를 가져온다.
		/// </summary>
		/// <param name="commentNo"></param>
		/// <returns></returns>
		public CommentModel GetComment(int commentNo)
		{
			return CommentAccess.GetComment(commentNo);
		}

		/// <summary>
		/// 댓글을 수정한다.
		/// </summary>
		/// <param name="model"></param>
		public void UpdateComment(CommentModel model)
		{
			CommentAccess.UpdateComment(model);
		}

		/// <summary>
		/// 최신 댓글 리스트를 가져온다.
		/// </summary>
		/// <param name="count">갯수</param>
		/// <returns></returns>
		public CommentBindModel GetRecentCommentList(int count)
		{
			return CommentAccess.GetRecentCommentList(count);
		}

		#region IManager 멤버

		public void Dispose()
		{
			instance = null;
		}

		#endregion
	}
}
