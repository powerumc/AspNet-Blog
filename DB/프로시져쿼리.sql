if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetArticleByArticleNo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetArticleByArticleNo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetConnectionLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetConnectionLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UAA_InsertAttachFile]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UAA_InsertAttachFile]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UAT_GetTagList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UAT_GetTagList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UAT_InsertTag]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UAT_InsertTag]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBA_AddCommentCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBA_AddCommentCount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBA_GetArticleByArticleNo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBA_GetArticleByArticleNo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBA_GetArticleGroupByDate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBA_GetArticleGroupByDate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBA_GetArticleList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBA_GetArticleList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBA_GetArticleListByCategoryID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBA_GetArticleListByCategoryID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBA_GetArticleListByDate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBA_GetArticleListByDate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBA_GetArticleListByTag]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBA_GetArticleListByTag]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBA_GetRecentArticle]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBA_GetRecentArticle]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBA_InsertArticle]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBA_InsertArticle]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBA_RemoveArticle]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBA_RemoveArticle]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBA_UpdateArticle]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBA_UpdateArticle]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBB_CompareBreakerIP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBB_CompareBreakerIP]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBB_InsertBreaker]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBB_InsertBreaker]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBB_RemoveBreaker]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBB_RemoveBreaker]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBC_GetComment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBC_GetComment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBC_GetCommentList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBC_GetCommentList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBC_GetRecentCommentList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBC_GetRecentCommentList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBC_InsertComment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBC_InsertComment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBC_RemoveComment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBC_RemoveComment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBC_UpdateComment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBC_UpdateComment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBE_GetEmoticonBySeqNo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBE_GetEmoticonBySeqNo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBE_GetEmoticonList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBE_GetEmoticonList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBE_InsertEmoticon]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBE_InsertEmoticon]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBE_RemoveEmoticon]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBE_RemoveEmoticon]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBE_UpdateEmoticon]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBE_UpdateEmoticon]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBI_GetCategoryCodes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBI_GetCategoryCodes]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBI_GetMyCategorys]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBI_GetMyCategorys]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBI_InsertNewCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBI_InsertNewCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBI_RemoveCategoryNode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBI_RemoveCategoryNode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBI_UpdateCategoryNodeValue]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBI_UpdateCategoryNodeValue]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBI_UpdateMoveCategoryChildNode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBI_UpdateMoveCategoryChildNode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBI_UpdateMoveCategoryNode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBI_UpdateMoveCategoryNode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBS_GetConnectionLogList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBS_GetConnectionLogList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBT_GetTrackbackList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBT_GetTrackbackList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBT_InsertTrackback]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBT_InsertTrackback]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBU_CompareEmailAndPassword]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBU_CompareEmailAndPassword]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBU_GetUserList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBU_GetUserList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UBU_UpdateUserInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UBU_UpdateUserInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UUI_GetUserInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UUI_GetUserInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UUI_InsertUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UUI_InsertUser]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetArticleByArticleNo 
	@ArticleNo		INT
AS
	SELECT  ArticleNo, CategoryID, Title, Content, TrackbackUrl, ViewCount, CommentCount, 
			PublicFlag, PublicRss, AllowComment, AllowTrackback, InsertDate, UpdateDate
	FROM      Article
	WHERE ArticleNo=@ArticleNo
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetConnectionLog 
	@Date		VARCHAR(20)
AS
	DECLARE @CurrentDate	DATETIME
	
	SET @CurrentDate	= CAST(@Date AS DATETIME)
	
	-- 현재 날짜까지의 총 접속 카운트
	SELECT TOP 1 SeqNo 'Count'
	FROM ConnectionLog
	WHERE CONVERT(VARCHAR(20), InsertDate, 102) = CONVERT(VARCHAR(20), @CurrentDate, 102)
	ORDER BY InsertDate DESC
	
	
	-- 오늘 방문자수
	SELECT COUNT(SeqNo) 'TodayCount'
	FROM ConnectionLog
	WHERE CONVERT(VARCHAR(20), InsertDate, 102) = CONVERT(VARCHAR(20), @CurrentDate, 102)
	--GROUP BY CONVERT(VARCHAR(20), InsertDate, 102)
	
	-- 이번주 방문자수
	DECLARE @StartWeek	DATETIME
	SET @StartWeek = dbo.GetStartDateOfWeek(@CurrentDate)
	SELECT COUNT(SeqNo) 'WeekCount'
	FROM ConnectionLog
	WHERE InsertDate BETWEEN  @StartWeek AND DATEADD(SECOND, -1 ,@StartWeek+7)
	
	DECLARE @StartMonth		DATETIME
	DECLARE @EndMonth		DATETIME
	
	SET @StartMonth	= CAST(LEFT(CONVERT(VARCHAR(20), @CurrentDate, 102), 7)+'.01' AS DATETIME)
	SET @EndMonth	= DATEADD(SECOND, -1, DATEADD(MONTH, 1, @StartMonth))
	-- 이번달 방문자수
	SELECT COUNT(SeqNo) 'MonthCount'
	FROM ConnectionLog
	WHERE InsertDate BETWEEN @StartMonth AND @EndMonth
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UAA_InsertAttachFile 
	@ArticleNo		INT,
	@FilePath		VARCHAR(255),
	@FileSize		INT
AS
	
	INSERT INTO AttachFile(ArticleNo, FilePath, FileSize)
	VALUES( @ArticleNo, @FilePath, @FileSize )
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UAT_GetTagList 
AS
	SELECT TagName
	FROM Tag
	GROUP BY TagName
	ORDER BY TagName ASC
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UAT_InsertTag
	@ArticleNo		INT,
	@TagName		VARCHAR(50)
AS
	DECLARE @Count		INT
	
	SET @Count = ( 
		SELECT COUNT(TagNo) 
		FROM Tag 
		WHERE ArticleNo=@ArticleNo AND TagName=@TagName
	)
	
	-- 똑같은 태그가 이미 존재한다면 리턴..	
	IF( @Count > 0 ) RETURN
	
	INSERT	INTO Tag(ArticleNo, TagName)
			VALUES (@ArticleNo, @TagName)
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBA_AddCommentCount 
	@ArticleNo				INT,
	@AddNumber				INT
AS
	
	UPDATE Article
	SET CommentCount=CommentCount + @AddNumber
	WHERE ArticleNo=@ArticleNo
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBA_GetArticleByArticleNo 
	@ArticleNo		INT
AS
	SELECT  A.*, C.CategoryLCode, C.CategoryMCode, C.CategoryGroup
	FROM      Article A
	LEFT OUTER JOIN Category C ON C.CategoryID=A.CategoryID
	WHERE A.ArticleNo=@ArticleNo
	
	SELECT *
	FROM Tag
	WHERE ArticleNo=@ArticleNo
	
	SELECT *
	FROM AttachFile
	WHERE ArticleNo=@ArticleNo
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBA_GetArticleGroupByDate 
	@Date		VARCHAR(10)
AS
	-- 날짜별로 포스트를 가져온다.
	DECLARE @CurrentDate	VARCHAR(7)
	
	SET @CurrentDate = CONVERT(VARCHAR(7), CAST(@Date+'/1' AS DATETIME), 111)
	SELECT	CONVERT(VARCHAR(10), InsertDate, 111) 'Date', 
			COUNT(ArticleNo) 'ArticleCount'
	FROM ARTICLE
	WHERE CONVERT(VARCHAR(7), InsertDate, 111) = @CurrentDate
	GROUP BY CONVERT(VARCHAR(10), InsertDate, 111)
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBA_GetArticleList 
	@CurrentPage			INT,
	@PageSize				INT,
	@SearchMode				VARCHAR(20),
	@SearchKeyword			VARCHAR(20),
	@PublicArticle			BIT					-- 공개포스트 true, 비공개 포스트포함 false
AS
	DECLARE @Query				VARCHAR(1000)
	DECLARE @CountQuery			VARCHAR(1000)
	DECLARE @SearchString		VARCHAR(1000)
	
	SET @SearchString	= ''
	
	IF(@SearchMode = 'title')
		SET @SearchString	= @SearchString + ' AND A.Title LIKE ''%' + @SearchKeyword + '%'' '
		
	IF(@PublicArticle = 1)
		SET @SearchString	= @SearchString + ' AND A.PublicFlag = 1 '
	ELSE
		SET @SearchString	= @SearchString + ' AND A.PublicFlag IN (0,1) '
		
	SET @CountQuery	= ' SELECT COUNT(ArticleNo) AS Count '
					+ ' FROM Article A '
					+ ' WHERE ArticleNo>=0 ' + @SearchString
	
	SET @Query	= ' SELECT TOP ' + CAST(@PageSize AS VARCHAR(10))
				+ ' A.*, C.CategoryLCode, C.CategoryMCode, dbo.GetTagByArticleNo(A.ArticleNo) AS Tag '
				+ ' FROM Article A '
				+ ' LEFT OUTER JOIN Category C ON C.CategoryID=A.CategoryID '
				+ ' WHERE A.ArticleNo>=0 ' + @SearchString
				+ ' AND A.ArticleNo NOT IN '
				+ ' ( '
				+ '		SELECT TOP ' + CAST(@PageSize * @CurrentPage AS VARCHAR(10))
				+ '		A.ArticleNo ' 
				+ '		FROM Article A '
				+ '		WHERE A.ArticleNo>=0 ' + @SearchString
				+ '		ORDER BY A.InsertDate DESC '
				+ ' ) '
				+ ' ORDER BY A.InsertDate DESC '
				
	EXEC(@CountQuery)
	EXEC(@Query)
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBA_GetArticleListByCategoryID 
	@CategoryID			INT,
	@CategoryStep		INT
AS
	IF (@CategoryStep=1 )		-- CategoryStep 이 1이면 자식 카테고리 아티클도 가져온다.
	BEGIN
		DECLARE @CategoryGroup	INT
		SET @CategoryGroup		= ( 
									SELECT CategoryGroup
									FROM Category C
									WHERE C.CategoryID=@CategoryID
								)
								
		SELECT A.*, C.CategoryLCode, C.CategoryMCode, C.CategoryTitle AS CategoryMTitle
		FROM Article A
		LEFT OUTER JOIN Category C ON C.CategoryID=A.CategoryID
		WHERE C.CategoryGroup=@CategoryGroup
		ORDER BY A.InsertDate DESC
	END
	ELSE IF (@CategoryStep=2 )
	BEGIN
		SELECT A.*, C.CategoryLCode, C.CategoryMCode, C.CategoryTitle AS CategoryMTitle
		FROM Article A
		LEFT OUTER JOIN Category C ON C.CategoryID=A.CategoryID
		WHERE A.CategoryID=@CategoryID
		ORDER BY A.InsertDate DESC
	END
	
	RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBA_GetArticleListByDate 
	@Date	VARCHAR(20)
AS
	SELECT A.*, C.CategoryLCode, C.CategoryMCode, C.CategoryTitle AS CategoryMTitle
	FROM Article A
	INNER JOIN Category C ON C.CategoryID=A.CategoryID
	WHERE 
	CONVERT(VARCHAR(20), A.InsertDate, 102)=CONVERT(VARCHAR(20), CAST(@Date AS DATETIME), 102)
	ORDER BY A.InsertDate DESC
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBA_GetArticleListByTag 
	@Tag			VARCHAR(50),
	@PublicArticle	BIT
AS
	DECLARE @Query			VARCHAR(1000)
	DECLARE @SearchString	VARCHAR(1000)
	
	SET @SearchString		= ''
	
	IF(@PublicArticle = 1)
		SET @SearchString = @SearchString + ' AND A.PublicFlag=1 '
	ELSE
		SET @SearchString = @SearchString + ' AND A.PublicFlag IN (0,1) '
	
	SET @Query	= ' SELECT A.*, C.CategoryLCode, C.CategoryMCode, C.CategoryTitle AS CategoryMTitle '
				+ ' FROM Tag T '
				+ ' INNER JOIN Article A ON A.ArticleNo=T.ArticleNo '
				+ ' LEFT OUTER JOIN Category C ON C.CategoryID=A.CategoryID '
				+ ' WHERE T.TagName = ''' + @Tag + ''' ' + @SearchString
				+ ' ORDER BY A.InsertDate DESC '
	EXEC (@Query)
	RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBA_GetRecentArticle 
	@Count		INT
AS
	DECLARE @Query	VARCHAR(1000)
	
	SET @Query = ' SELECT TOP '+CAST(@Count AS VARCHAR(10)) 
				+ ' A.*, dbo.GetTagByArticleNo(ArticleNo) AS Tag, '
				+ ' C.CategoryLCode, C.CategoryMCode '
				+ ' FROM Article A '
				+ ' LEFT OUTER JOIN Category C ON C.CategoryID=A.CategoryID '
				+ ' ORDER BY InsertDate DESC '
				
	EXEC(@Query)
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBA_InsertArticle 
	@CategoryID			INT,
	@Title				VARCHAR(255),
	@Content			TEXT,
	@TrackbackUrl		VARCHAR(255),
	@PublicFlag			BIT,
	@PublicRss			BIT,
	@AllowComment		BIT,
	@AllowTrackback		BIT
AS
	INSERT INTO Article
	                (CategoryID, 
	                Title, 
	                Content, 
	                TrackbackUrl,
	                PublicFlag, 
	                PublicRss, 
	                AllowComment, 
	                AllowTrackback
	                )
	VALUES		(   @CategoryID,
					@Title,
					@Content,
					@TrackbackUrl,
					@PublicFlag,
					@PublicRss,
					@AllowComment,
					@AllowTrackback)
	RETURN @@IDENTITY

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBA_RemoveArticle
	@ArticleNo				INT
AS
	DELETE Article WHERE ArticleNo=@ArticleNo
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBA_UpdateArticle 
	@ArticleNo			INT,
	@CategoryID			INT,
	@Title				VARCHAR(255),
	@Content			TEXT,
	@TrackbackUrl		VARCHAR(255),
	@PublicFlag			BIT,
	@PublicRss			BIT,
	@AllowComment		BIT,
	@AllowTrackback		BIT
AS
	UPDATE  Article
	SET         CategoryID		= @CategoryID, 
				Title			= @Title, 
				Content			= @Content, 
				TrackbackUrl	= @TrackbackUrl,
				PublicFlag		= @PublicFlag, 
				PublicRss		= @PublicRss, 
				AllowComment	= @AllowComment,
				AllowTrackback	= @AllowTrackback, 
				UpdateDate		= GETDATE()
	WHERE ArticleNo=@ArticleNo
				
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBB_CompareBreakerIP
	@UserIP				VARCHAR(20)
AS
	IF( (SELECT COUNT(SeqNo) FROM Breaker WHERE UserIP=@UserIP ) > 0 ) RETURN 1
	
	RETURN 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

create PROCEDURE dbo.UBB_InsertBreaker 
	@UserIP			VARCHAR(20)
AS
	IF( (SELECT COUNT(SeqNo) FROM Breaker WHERE UserIP=@UserIP) > 0 )
		RETURN -1
	
	INSERT INTO Breaker(UserIP, InsertDate)
	VALUES( @UserIP, GETDATE() )
	
	RETURN @@IDENTITY
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBB_RemoveBreaker
	@UserIP				VARCHAR(20)
AS
	
	DELETE Breaker WHERE UserIP=@UserIP
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBC_GetComment 
	@CommentNo		INT
AS
	
	SELECT	CommentNo, ArticleNo, CommentGroup, CommentStep, 
			CommentOrder, UserEmail, UserName, UserBlogUrl, Content, 
			Password, UserIP, InsertDate, UpdateDate
	FROM      Comment
	WHERE   (CommentNo = @CommentNo)
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBC_GetCommentList 
	@ArticleNo		INT
AS
	SELECT   CommentNo, ArticleNo, CommentGroup, CommentStep, 
	         CommentOrder, UserEmail, UserName, UserBlogUrl, Content, Password, UserIP,
	         InsertDate, UpdateDate
	FROM      Comment
	WHERE ArticleNo=@ArticleNo
	ORDER BY CommentGroup ASC, CommentOrder ASC
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBC_GetRecentCommentList 
	@Count			INT
AS
	DECLARE @Query	 VARCHAR(1000)
	
	SET @Query = ' SELECT TOP '+CAST(@Count AS VARCHAR(10))+' * '
				+ ' FROM Comment '
				+ ' ORDER BY InsertDate DESC '
				
	EXEC(@Query)
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBC_InsertComment 
	@ArticleNo			INT,
	@CommentGroup		INT,
	@CommentStep		INT,
	@CommentOrder		INT,
	@UserEmail			VARCHAR(20),
	@UserName			VARCHAR(20),
	@UserBlogUrl		VARCHAR(255),
	@Content			TEXT,
	@Password			VARCHAR(100),
	@UserIP				VARCHAR(20),
	@Mode				INT
AS
	DECLARE @NewGroup	INT
	DECLARE @NewStep	INT
	DECLARE @NewOrder	INT
	DECLARE @Parent		INT
	DECLARE @HasChild	INT
	IF(@Mode=0)         -- 새 댓글
	BEGIN
		SET @NewGroup	= ( SELECT ISNULL(MAX(CommentGroup)+1, 0) FROM Comment )
		SET @NewStep	= @CommentStep
		SET @NewOrder	= @CommentOrder
	END
	ELSE IF(@Mode=1)		-- 답변 댓글
	BEGIN
		SET @NewGroup	= @CommentGroup
		SET @NewStep	= @CommentStep+1
		
		SET @HasChild	= ( SELECT COUNT(*) FROM Comment WHERE CommentGroup=@CommentGroup AND CommentStep<=@CommentStep AND CommentOrder>@CommentOrder )
	
		IF (@HasChild=0)
		BEGIN
			SET @NewOrder	= ( SELECT ISNULL(MAX(CommentOrder),0)+1 FROM Comment WHERE CommentGroup=@CommentGroup )
		END
		ELSE 
		BEGIN
			SET @NewOrder	= ( SELECT ISNULL(MIN(CommentOrder),0) FROM Comment WHERE CommentGroup=@CommentGroup AND CommentStep<=@CommentStep AND CommentOrder>@CommentOrder )
			
		END
		
		UPDATE Comment SET CommentOrder=CommentOrder+1
		WHERE CommentGroup=@CommentGroup AND CommentOrder>=@NewOrder
	END
	
	INSERT INTO Comment
	                (ArticleNo, CommentGroup, CommentStep, CommentOrder,
	                 UserEmail,
	                UserName, UserBlogUrl, Content, Password, UserIP)
	VALUES   (@ArticleNo, @NewGroup, @NewStep, @NewOrder,
				@UserEmail, @UserName, @UserBlogUrl, @Content, @Password, @UserIP)
	
	-- 댓글 갯수 증가			
	UPDATE Article
	SET CommentCount=CommentCount+1
	WHERE ArticleNo=@ArticleNo
	
	RETURN @@IDENTITY

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBC_RemoveComment
	@CommentNo				INT
AS
	DECLARE @HasChild		INT
	DECLARE @CommentGroup	INT
	DECLARE @CommentStep	INT
	DECLARE @CommentOrder	INT
	DECLARE @ArticleNo		INT
	
	SELECT @CommentGroup=CommentGroup, @CommentStep=CommentStep, @CommentOrder=CommentOrder, @ArticleNo=ArticleNo
	FROM Comment
	WHERE CommentNo=@CommentNo
	
	SET @HasChild	=	( 
						SELECT COUNT(*) 
						FROM Comment 
						WHERE CommentGroup=@CommentGroup AND 
							CommentStep=@CommentStep+1 AND 
							CommentOrder=@CommentOrder+1 
						)
	IF( @HasChild > 0 )		RETURN 0	
	
	DELETE Comment WHERE CommentNo=@CommentNo
	
	
	-- 댓글 갯수 감소
	UPDATE Article
	SET CommentCount=CommentCount-1
	WHERE ArticleNo=@ArticleNo	
	
	RETURN 1

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBC_UpdateComment 
	@CommentNo		INT,
	@UserName		VARCHAR(20),
	@UserBlogUrl	VARCHAR(255),
	@Content		TEXT,
	@Password		VARCHAR(100)
AS
	UPDATE  Comment
	SET         UserName = @UserName, 
				UserBlogUrl = @UserBlogUrl, 
				Content = @Content, 
				Password = @Password, 
				UpdateDate = GETDATE()
	WHERE CommentNo=@CommentNo
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBE_GetEmoticonBySeqNo
	@SeqNo			INT
AS
	
	SELECT *
	FROM Emoticon
	WHERE SeqNo=@SeqNo
	
	RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBE_GetEmoticonList
AS
	SELECT *
	FROM Emoticon
	ORDER BY InsertDate
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBE_InsertEmoticon 
	@String			VARCHAR(50),
	@Value			VARCHAR(50),
	@Description	TEXT
AS

	DECLARE @Count		INT
	
	SET @Count	= ( SELECT COUNT(*) FROM Emoticon WHERE String=@String )
	
	IF( @COUNT > 0 ) RETURN -1;

	INSERT INTO Emoticon(String,Value,Description)
	VALUES( @String, @Value, @Description)
	
	RETURN @@IDENTITY
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBE_RemoveEmoticon
	@SeqNo			INT,
	@FileName		VARCHAR(255)	OUTPUT
AS
	
	SELECT @FileName=[Value]
	FROM Emoticon
	WHERE SeqNo=@SeqNo
	
	DELETE Emoticon
	WHERE SeqNo=@SeqNo
	
	RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBE_UpdateEmoticon 
	@SeqNo				INT,
	@String				VARCHAR(50),
	@Value				VARCHAR(255),
	@Description		TEXT,
	@InsertDate			DATETIME,
	@OldFileName		VARCHAR(255)	OUTPUT
AS
	
	SELECT @OldFileName=[Value]
	FROM Emoticon
	WHERE SeqNo=SeqNo
	
	UPDATE  Emoticon
	SET         String = @String, 
				Value = @Value, 
				Description = @Description,
				InsertDate = @InsertDate
	WHERE SeqNo=@SeqNo
	
	RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBI_GetCategoryCodes 
	@LCode		INT
AS
	-- 대분류를 가져온다
	SELECT CategoryLCode, CategoryLTitle
	FROM CategoryLCode
	ORDER BY CategoryLCode ASC
	
	-- 중분류를 가져온다.
	SELECT CategoryMCode, CategoryMTitle
	FROM CategoryMCode
	WHERE CategoryLCode=@LCode
	ORDER BY CategoryMCode ASC
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBI_GetMyCategorys
	@PeridoNewIcon			INT
AS
	
		SELECT  CV.CategoryID,			-- 카테고리 아이디
			CV.CategoryTitle,		-- 카테고리 타이틀
			CV.CategoryLCode,		-- 카테고리 대분류 코드
			CV.CategoryMCode,		-- 카테고리 중분류 코드
			CV.CategoryLTitle,		-- 카테고리 대분류
			CV.CategoryMTitle,		-- 카테고리 중분류
			CV.CategoryGroup,		-- 카테고리 구룹
			CV.CategoryStep,		-- 카테고리 들여쓰기
			CV.CategoryOrder,		-- 카테고리 구룹 내 순서
			(
				CASE
					WHEN CV.CategoryStep>1 THEN 
					(
						SELECT COUNT(ArticleNo) 
						FROM Article
						WHERE CV.CategoryID=CategoryID
					)
					WHEN CV.CategoryStep=1 THEN
					(
						SELECT COUNT(ArticleNo)
						FROM Article A
						INNER JOIN Category C ON C.CategoryID=A.CategoryID
						WHERE CV.CategoryGroup=C.CategoryGroup
					)
				END
			) 'ArticleCount',
			CAST(ISNULL(
			(
				CASE
					WHEN CV.CategoryStep>1 THEN 
					(
						SELECT TOP 1 CASE
										WHEN GETDATE()-@PeridoNewIcon<InsertDate THEN '1'
										ELSE '0'
									  END
						FROM Article
						WHERE CV.CategoryID=CategoryID
						ORDER BY InsertDate DESC
					)
					WHEN CV.CategoryStep=1 THEN
					(
						SELECT TOP 1 CASE
										WHEN GETDATE()-@PeridoNewIcon<InsertDate THEN '1'
										ELSE '0'
									 END
						FROM Article A
						INNER JOIN Category C ON C.CategoryID=A.CategoryID
						WHERE CV.CategoryGroup=C.CategoryGroup
						ORDER BY InsertDate DESC
					)
				END
			), '0') AS BIT) 'NewIcon'
	FROM	CategoryView CV
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBI_InsertNewCategory 
	@Title		VARCHAR(50),
	@LCode		INT,
	@MCode		INT,
	@Group		INT,
	@Step		INT,
	@Order		INT,
	@Mode		INT		-- 1이면 루트, 2면 자식 카테고리 추가
AS
			
	IF(@Mode = 1)		-- 신규 루트 카테고리 일경우
	BEGIN
		DECLARE @MaxGroup	INT;
		
		-- 가장 높은 새로운 카테고리 구룹
		SELECT @MaxGroup=ISNULL(MAX(CategoryGroup)+1, 0)
		FROM Category
	
		INSERT INTO Category
						(CategoryTitle, 
						CategoryLCode, 
						CategoryMCode, 
						CategoryGroup,
						CategoryStep, 
						CategoryOrder)
		VALUES   (	@Title,
					@LCode,
					@MCode,
					@MaxGroup,
					1,
					1)
	END
	ELSE			-- 자식 카테고리 일경우
	BEGIN
		DECLARE @MaxOrder	INT;
		-- 구룹 내 카테고리 추가될 정렬 순서
		SELECT @MaxOrder=ISNULL(MAX(CategoryOrder)+1,1)
		FROM Category
		WHERE	CategoryGroup=@Group AND CategoryStep=@Step
	
		INSERT INTO Category
						(CategoryTitle, 
						CategoryLCode, 
						CategoryMCode, 
						CategoryGroup,
						CategoryStep, 
						CategoryOrder)
		VALUES   (	@Title,
					@LCode,
					@MCode,
					@Group,
					2,
					@MaxOrder)
	END
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBI_RemoveCategoryNode 
	@ID		INT,
	@Step	INT,
	@Group	INT
AS
	
	-- 카테고리를 삭제한다.
	
	IF(@Step = 2)			-- 자식 카테고리면 카테고리만 삭제한다.
	BEGIN
		DECLARE @CurrentOrder	INT
		-- 지우게될 카테고리 정렬순서를 가져온다.
		SELECT CategoryOrder
		FROM Category
		WHERE CategoryID=@ID
	
		DELETE Category WHERE CategoryID=@ID
		
		-- 지운 카테고리의 공백으로 CategoryOrder 를 재수정 한다.
		UPDATE Category
		SET CategoryOrder=CategoryOrder-1
		WHERE CategoryGroup=@Group AND CategoryOrder>@CurrentOrder
	END
	
	IF(@Step = 1)			-- 카테고리 구룹을 삭제할때
	BEGIN
		DELETE Category
		WHERE CategoryGroup=@Group
	END
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBI_UpdateCategoryNodeValue 
	@ID			INT,
	@Title		VARCHAR(50),
	@LCode		INT,
	@MCode		INT,
	@NewGroup	INT
AS
	DECLARE @Group	INT
	
	SELECT @Group=CategoryGroup		-- 원래의 카테고리 구룹을 가져온다.
	FROM Category
	WHERE CategoryID=@ID
	
	IF( @Group <> @NewGroup )		-- 카테고리 구룹을 새로 바꾸는 경우
	BEGIN
		DECLARE @NewGroupOrder INT	-- 새로바뀔 구룹의 MAX+1 정렬 순서로 업데이트
		
		SELECT @NewGroupOrder=ISNULL(MAX(CategoryOrder)+1, 1)
		FROM Category
		WHERE CategoryGroup=@NewGroup AND CategoryStep > 1
		
		UPDATE Category				-- 새로운 구룹의 정렬 맨 마지막으로 가져다 놓는다
		SET CategoryOrder=@NewGroupOrder, CategoryGroup=@NewGroup
		WHERE CategoryID=@ID
	END
	
	UPDATE Category
	SET		CategoryTitle=@Title,
			CategoryLCode=@LCode,
			CategoryMCode=@MCode
	WHERE CategoryID=@ID			
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBI_UpdateMoveCategoryChildNode 
	@ID			INT,
	@Group		INT,
	@Step		INT,
	@Order		INT,
	@Mode		VARCHAR(10)
AS
	-- 하위 카테고리 위치를 이동한다.
	
	-- 현재 노드의 최하위,최상위 노드를 가져온다.
	DECLARE @OrderMax	INT
	DECLARE @OrderTop	INT
	SELECT @OrderTop = MIN(CategoryOrder) FROM Category 
	WHERE CategoryGroup=@Group AND CategoryStep>1
	SELECT @OrderMax = MAX(CategoryOrder) FROM Category 
	WHERE CategoryGroup=@Group AND CategoryStep>1
	
	-- 위로 이동시 최상위 노드라면 이동할 필요 없음
	IF( @Mode = 'up' AND @Order = @OrderTop ) RETURN 0;
	
	-- 아래 이동시 최하위 노드라면 이동할 필요 없음
	IF( @Mode = 'down' AND @Order = @OrderMax ) RETURN 0;
	
			
	-- 이동할 위치의 노드
	DECLARE @NewID INT, @NewGroup INT, @NewStep INT, @NewOrder INT;
	
	-- 바뀔 노드의 ID 를 가져온다.
	IF( @Mode = 'up' )
	BEGIN
		SELECT TOP 1 @NewID = CategoryID, @NewOrder = CategoryOrder
		FROM Category
		WHERE CategoryGroup=@Group AND CategoryStep=@Step AND CategoryOrder<@Order
		ORDER BY CategoryOrder DESC
	END
	ELSE IF( @Mode = 'down' )
	BEGIN
		SELECT TOP 1 @NewID = CategoryID , @NewOrder = CategoryOrder
		FROM Category
		WHERE CategoryGroup=@Group AND CategoryStep=@Step AND CategoryOrder>@Order
		ORDER BY CategoryOrder ASC
	END
	
	UPDATE Category SET CategoryOrder=@NewOrder WHERE CategoryID=@ID
	
	UPDATE Category SET CategoryOrder=@Order WHERE CategoryID=@NewID
	
	RETURN 1

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBI_UpdateMoveCategoryNode 
	@ID			INT,
	@Group		INT,
	@Step		INT,
	@Order		INT,
	@Mode		VARCHAR(10)
AS
	-- 루트 카테고리 노드를 이동한다
	
	-- 최상위 구룹과 최하위 구룹을 가져온다.
	DECLARE @MinGroup INT, @MaxGroup INT
	SELECT @MinGroup = MIN(CategoryGroup), @MaxGroup = MAX(CategoryGroup) FROM Category
	
	-- 이동할 현재 구룹이 최상위, 또는 최하위면 이동하지 않는다.
	IF( @Mode = 'up' AND @Group = @MinGroup )	RETURN 0;
	IF( @Mode = 'down' AND @Group = @MaxGroup ) RETURN 0;
	
	-- 이동할 구룹 아이디를 가져온다.
	DECLARE @NewGroup INT
	IF (@Mode='up')
	BEGIN
		SELECT TOP 1 @NewGroup = CategoryGroup
		FROM Category
		WHERE CategoryGroup<@Group
		ORDER BY CategoryGroup DESC
	END
	ELSE
	IF (@Mode='down')
	BEGIN
		SELECT TOP 1 @NewGroup = CategoryGroup
		FROM Category
		WHERE CategoryGroup>@Group
		ORDER BY CategoryGroup ASC
	END
	
	-- 현재 구룹을 임시의 구룹(-1) 으로 바꾼다.
	UPDATE Category SET CategoryGroup=-1 WHERE CategoryGroup=@Group
	
	-- 옮기게될 구룹들을 현재 구룹으로 바꾼다
	UPDATE Category SET CategoryGroup=@Group WHERE CategoryGroup=@NewGroup
	
	-- 임시로 바꾼 구룹을 옮기게될 구룹으로 바꾼다.
	UPDATE Category SET CategoryGroup=@NewGroup WHERE CategoryGroup=-1
	RETURN 1

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBS_GetConnectionLogList 
	@CurrentPage			INT,
	@PageSize				INT,
	@SearchKeyword			VARCHAR(20),
	@SearchString			VARCHAR(100)
AS
	DECLARE @Query			VARCHAR(2000)
	DECLARE @Count			VARCHAR(2000)
	
	SET @Count	= ' SELECT COUNT(SeqNo) '
				+ ' FROM ConnectionLog '
	
	SET @Query	= ' SELECT TOP ' + CAST(@PageSize AS VARCHAR(10)) + ' C.*, '
				+ ' CASE '
				+ '		WHEN B.UserIP IS NULL THEN ''False'' '
				+ '		ELSE ''True'' '
				+ ' END AS BreakerFlag '
				+ ' FROM ConnectionLog C '
				+ ' LEFT OUTER JOIN Breaker B ON B.UserIP=C.UserIP '
				+ ' WHERE C.SeqNo > 0 '
				+ ' AND C.SeqNo NOT IN '
					+ ' ( '
					+ ' SELECT TOP ' + CAST(@PageSize*@CurrentPage AS VARCHAR(10)) + ' C.SeqNo '
					+ ' FROM ConnectionLog C '
					+ ' WHERE C.SeqNo > 0 '
					+ ' ORDER BY C.InsertDate DESC '
					+ ' ) '
				+ ' ORDER BY C.InsertDate DESC '
				
	
	EXEC (@Count)
	EXEC (@Query)
	
	RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBT_GetTrackbackList
	@ArticleNo					INT
AS
	SELECT *
	FROM Trackback
	WHERE ArticleNo=@ArticleNo
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBT_InsertTrackback
	@ArticleNo			INT,
	@Url				VARCHAR(255),
	@Blog_Name			VARCHAR(255),
	@Title				VARCHAR(255),
	@Exceprt			TEXT,
	@UserIP				VARCHAR(20)
AS
	INSERT INTO Trackback( ArticleNo, Url, Blog_Name, Title, Exceprt, UserIP )
	VALUES ( @ArticleNo, @Url, @Blog_Name, @Title, @Exceprt, @UserIP )
	
	UPDATE Article
	SET		TrackbackCount=TrackbackCount+1
	WHERE ArticleNo=@ArticleNo
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBU_CompareEmailAndPassword
	@Email				VARCHAR(255),
	@Password			VARCHAR(100)
AS
	DECLARE @Count		INT
	
	SELECT @Count = COUNT(*) 
	FROM UserInfo 
	WHERE EMail=@Email
	
	IF( @Count = 0 ) RETURN -1			-- 이메일이 존재하지 않음
	
	SELECT @Count = COUNT(*)
	FROM UserInfo
	WHERE EMail=@Email AND Password=@Password
	
	IF( @Count = 1 ) RETURN 1			-- 아이디 패스워드 맞음
	
	IF( @Count = 2 ) RETURN 2			-- 중복 가입 된 상태
	
	RETURN 0							-- 아이디 패스워드 일치하지 않음.

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBU_GetUserList 
	@CurrentPage		INT,
	@PageSize			INT,
	@SearchKeyword		VARCHAR(20),
	@SearchString		VARCHAR(100)
AS
	DECLARE @CountQuery	VARCHAR(2000)
	DECLARE @Query		VARCHAR(2000)
	DECLARE @Search		VARCHAR(2000)
	
	
	SET @Search		= ''
	
	IF( @SearchKeyword = 'email' )
		SET @Search	= ' AND EMail LIKE ''%' + @SearchString + '%'' '
	IF( @SearchKeyword = 'name' )
		SET @Search	= ' AND Name LIKE ''%' + @SearchString + '%'' '
	IF( @SearchKeyword = 'nickname' )
		SET @Search	= ' AND NickName LIKE ''%' + @SearchString + '%'' '
	IF( @SearchKeyword = 'level' )
		SET @Search	= ' AND Level LIKE ''%' + @SearchString + '%'' '
	IF( @SearchKeyword = 'homepage' )
		SET @Search	= ' AND HomePage LIKE ''%' + @SearchString + '%'' '
	
	SET @CountQuery	= ' SELECT COUNT(EMail) AS TotalCount '
					+ ' FROM UserInfo '
					+ ' WHERE EMail IS NOT NULL ' + @Search
	EXEC(@CountQuery)
	
	SET @Query	= ' SELECT TOP ' + CAST(@PageSize AS VARCHAR(20)) + ' * '
				+ ' FROM UserInfo UI '
				+ ' WHERE EMail IS NOT NULL ' + @Search
				+ ' AND EMail NOT IN '
				+ ' ( '
					+ ' SELECT TOP ' + CAST(@PageSize*@CurrentPage AS VARCHAR(20))
					+ ' EMail '
					+ ' FROM UserInfo '
					+ ' WHERE EMail IS NOT NULL ' + @Search
					+ ' ORDER BY InsertDate DESC '
				+ ' ) '
				+ ' ORDER BY InsertDate DESC '
	
	EXEC(@Query)
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UBU_UpdateUserInfo 
	@OldEMail		VARCHAR(255),
	@NewEMail		VARCHAR(255),
	@Name			VARCHAR(20),
	@NickName		VARCHAR(20),
	@HomePage		VARCHAR(255),
	@Level			VARCHAR(20)
AS
	
	UPDATE UserInfo
	SET	EMail		= @NewEmail,
		[Name]		= @Name,
		NickName	= @NickName,
		HomePage	= @HomePage,
		[Level]		= @Level
	WHERE Email=@OldEmail
	
	RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UUI_GetUserInfo 
	@EMail		VARCHAR(255)
AS
	
	SELECT   EMail, Password, Name, NickName, Homepage, Level
	FROM      UserInfo
	WHERE   (EMail = @Email)
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UUI_InsertUser
	@Email		VARCHAR(20),
	@Name		VARCHAR(20),
	@NickName	VARCHAR(20),
	@Password	VARCHAR(100),
	@Homepage	VARCHAR(255),
	@Level		VARCHAR(20),
	@ReturnCode	VARCHAR(100) OUTPUT
AS
	-- 회원을 가입 시킨다.
	
	SELECT TOP 1 EMail
	FROM UserInfo
	WHERE Email=@Email
	
	-- 회원이 존재하면 중복 이메일 (가입실패)
	IF( @@ROWCOUNT > 0 ) 
	BEGIN
		SET @ReturnCode	= 'message.double.email';
		RETURN
	END
	
	INSERT INTO UserInfo (EMail, Password, [Name], NickName, Homepage, [Level])
	VALUES   (@Email, @Password,@Name, @NickName, @Homepage, @Level)
	
	SET @ReturnCode = 'message.success.userjoin';
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

