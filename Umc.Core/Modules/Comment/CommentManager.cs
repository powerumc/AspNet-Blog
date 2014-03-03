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
		New = 0,		// �� ���
		Reply = 1		// �亯 ���
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

			throw new UmcException("Comment ��Ʈ���� �ε��� �� �����ϴ�");
		}
		*/

		/// <summary>
		/// ��� ����
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public int InsertComment(CommentModel model)
		{
			return CommentAccess.InsertComment(model);
		}

		/// <summary>
		/// ��۸���Ʈ�� �����´�.
		/// </summary>
		/// <param name="articleNo"></param>
		/// <returns></returns>
		public CommentBindModel GetCommentList(int articleNo)
		{
			return CommentAccess.GetCommentList(articleNo);
		}

		/// <summary>
		/// ����� �����Ѵ�.
		/// </summary>
		/// <param name="commentNo"></param>
		/// <returns></returns>
		public int RemoveComment(int commentNo)
		{
			return CommentAccess.RemoveComment(commentNo);
		}

		/// <summary>
		/// ��� �ϳ��� �����´�.
		/// </summary>
		/// <param name="commentNo"></param>
		/// <returns></returns>
		public CommentModel GetComment(int commentNo)
		{
			return CommentAccess.GetComment(commentNo);
		}

		/// <summary>
		/// ����� �����Ѵ�.
		/// </summary>
		/// <param name="model"></param>
		public void UpdateComment(CommentModel model)
		{
			CommentAccess.UpdateComment(model);
		}

		/// <summary>
		/// �ֽ� ��� ����Ʈ�� �����´�.
		/// </summary>
		/// <param name="count">����</param>
		/// <returns></returns>
		public CommentBindModel GetRecentCommentList(int count)
		{
			return CommentAccess.GetRecentCommentList(count);
		}

		#region IManager ���

		public void Dispose()
		{
			instance = null;
		}

		#endregion
	}
}
