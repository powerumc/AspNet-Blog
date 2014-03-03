if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetStartDateOfWeek]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[GetStartDateOfWeek]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTagByArticleNo]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[GetTagByArticleNo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE FUNCTION dbo.GetStartDateOfWeek
	(
		@Date		VARCHAR(20)
	)
RETURNS DATETIME
AS
BEGIN
	DECLARE @CurrentDate		DATETIME
	
	SET @CurrentDate	= CAST(@Date AS DATETIME)
	WHILE ( DATENAME(WEEKDAY, @CurrentDate) <> '¿œø‰¿œ' )
	BEGIN
		SET @CurrentDate = DATEADD(DAY, -1, @CurrentDate)
	END
	
	RETURN @CurrentDate
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE FUNCTION dbo.GetTagByArticleNo 
	(
		@ArticleNo		INT
	)
RETURNS VARCHAR(1000)
AS
BEGIN
	DECLARE @Str		VARCHAR(1000)
	DECLARE @TagName	VARCHAR(100)
	DECLARE TempTags	CURSOR FOR
	SELECT TagName
	FROM Tag
	WHERE ArticleNo=@ArticleNo
	
	SET @Str = ''
	
	OPEN  TempTags
	
	FETCH NEXT FROM TempTags INTO @TagName
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @Str = @Str + @TagName + ','
		FETCH NEXT FROM TempTags INTO @TagName
	END
	
	CLOSE TempTags
	DEALLOCATE TempTags
	
	IF( LEN(@Str) <> 0 ) SET @Str = LEFT( @Str, LEN(@Str)-1 )
	
	RETURN @Str
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

