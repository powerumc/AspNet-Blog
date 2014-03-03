if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_AttachFile_Article]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[AttachFile] DROP CONSTRAINT FK_AttachFile_Article
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Comment_Article]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Comment] DROP CONSTRAINT FK_Comment_Article
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Tag_Article]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Tag] DROP CONSTRAINT FK_Tag_Article
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Article]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Article]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AttachFile]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AttachFile]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Breaker]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Breaker]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Category]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Category]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CategoryLCode]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CategoryLCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CategoryMCode]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CategoryMCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Comment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Comment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ConnectionLog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ConnectionLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Emoticon]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Emoticon]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Level]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Level]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Tag]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Tag]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Trackback]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Trackback]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UserInfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[UserInfo]
GO

CREATE TABLE [dbo].[Article] (
	[ArticleNo] [int] IDENTITY (1, 1) NOT NULL ,
	[CategoryID] [int] NOT NULL ,
	[Title] [varchar] (255) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[Content] [text] COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[TrackbackUrl] [varchar] (255) COLLATE Korean_Wansung_CI_AS NULL ,
	[ViewCount] [int] NOT NULL ,
	[TrackbackCount] [int] NOT NULL ,
	[CommentCount] [int] NOT NULL ,
	[PublicFlag] [bit] NOT NULL ,
	[PublicRss] [bit] NOT NULL ,
	[AllowComment] [bit] NOT NULL ,
	[AllowTrackback] [bit] NOT NULL ,
	[InsertDate] [datetime] NOT NULL ,
	[UpdateDate] [datetime] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[AttachFile] (
	[FileNo] [int] IDENTITY (1, 1) NOT NULL ,
	[ArticleNo] [int] NOT NULL ,
	[FilePath] [varchar] (255) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[FileSize] [int] NOT NULL ,
	[DownCount] [int] NOT NULL ,
	[InsertDate] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Breaker] (
	[SeqNo] [int] IDENTITY (1, 1) NOT NULL ,
	[UserIP] [varchar] (20) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[InsertDate] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Category] (
	[CategoryID] [int] IDENTITY (1, 1) NOT NULL ,
	[CategoryTitle] [varchar] (50) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[CategoryLCode] [int] NOT NULL ,
	[CategoryMCode] [int] NOT NULL ,
	[CategoryGroup] [int] NOT NULL ,
	[CategoryStep] [int] NOT NULL ,
	[CategoryOrder] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CategoryLCode] (
	[CategoryLCode] [int] NOT NULL ,
	[CategoryLTitle] [varchar] (50) COLLATE Korean_Wansung_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CategoryMCode] (
	[CategoryLCode] [int] NOT NULL ,
	[CategoryMCode] [int] NOT NULL ,
	[CategoryMTitle] [varchar] (50) COLLATE Korean_Wansung_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Comment] (
	[CommentNo] [int] IDENTITY (1, 1) NOT NULL ,
	[ArticleNo] [int] NOT NULL ,
	[CommentGroup] [int] NOT NULL ,
	[CommentStep] [int] NOT NULL ,
	[CommentOrder] [int] NOT NULL ,
	[UserEmail] [varchar] (255) COLLATE Korean_Wansung_CI_AS NULL ,
	[UserName] [varchar] (20) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[UserBlogUrl] [varchar] (255) COLLATE Korean_Wansung_CI_AS NULL ,
	[Content] [text] COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[Password] [varchar] (100) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[UserIP] [varchar] (20) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[InsertDate] [datetime] NOT NULL ,
	[UpdateDate] [datetime] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[ConnectionLog] (
	[SeqNo] [int] IDENTITY (1, 1) NOT NULL ,
	[SessionID] [varchar] (100) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[UrlReferrer] [varchar] (255) COLLATE Korean_Wansung_CI_AS NULL ,
	[UserIP] [varchar] (20) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[InsertDate] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Emoticon] (
	[SeqNo] [int] IDENTITY (1, 1) NOT NULL ,
	[String] [varchar] (50) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[Value] [varchar] (255) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[Description] [text] COLLATE Korean_Wansung_CI_AS NULL ,
	[InsertDate] [datetime] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Level] (
	[Level] [varchar] (20) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[LevelString] [varchar] (20) COLLATE Korean_Wansung_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Tag] (
	[TagNo] [int] IDENTITY (1, 1) NOT NULL ,
	[ArticleNo] [int] NOT NULL ,
	[TagName] [varchar] (50) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[InsertDate] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Trackback] (
	[SeqNo] [int] IDENTITY (1, 1) NOT NULL ,
	[ArticleNo] [int] NOT NULL ,
	[Url] [varchar] (255) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[Blog_Name] [varchar] (255) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[Title] [varchar] (255) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[Exceprt] [text] COLLATE Korean_Wansung_CI_AS NULL ,
	[UserIP] [varchar] (20) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[InsertDate] [datetime] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[UserInfo] (
	[EMail] [varchar] (255) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[Password] [varchar] (100) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[Name] [varchar] (20) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[NickName] [varchar] (20) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[Homepage] [varchar] (255) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[Level] [varchar] (20) COLLATE Korean_Wansung_CI_AS NOT NULL ,
	[InsertDate] [datetime] NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Article] WITH NOCHECK ADD 
	CONSTRAINT [PK_Article] PRIMARY KEY  CLUSTERED 
	(
		[ArticleNo]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[AttachFile] WITH NOCHECK ADD 
	CONSTRAINT [PK_AttachFile] PRIMARY KEY  CLUSTERED 
	(
		[FileNo]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Breaker] WITH NOCHECK ADD 
	CONSTRAINT [PK_Breaker] PRIMARY KEY  CLUSTERED 
	(
		[SeqNo]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Category] WITH NOCHECK ADD 
	CONSTRAINT [PK_Category] PRIMARY KEY  CLUSTERED 
	(
		[CategoryID],
		[CategoryGroup],
		[CategoryStep],
		[CategoryOrder]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CategoryLCode] WITH NOCHECK ADD 
	CONSTRAINT [PK_CategoryLCode] PRIMARY KEY  CLUSTERED 
	(
		[CategoryLCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CategoryMCode] WITH NOCHECK ADD 
	CONSTRAINT [PK_CategoryMCode] PRIMARY KEY  CLUSTERED 
	(
		[CategoryLCode],
		[CategoryMCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Comment] WITH NOCHECK ADD 
	CONSTRAINT [PK_Comment] PRIMARY KEY  CLUSTERED 
	(
		[CommentNo]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ConnectionLog] WITH NOCHECK ADD 
	CONSTRAINT [PK_ConnectionLog] PRIMARY KEY  CLUSTERED 
	(
		[SeqNo]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Emoticon] WITH NOCHECK ADD 
	CONSTRAINT [PK_Emoticon_1] PRIMARY KEY  CLUSTERED 
	(
		[SeqNo]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Level] WITH NOCHECK ADD 
	CONSTRAINT [PK_Level] PRIMARY KEY  CLUSTERED 
	(
		[Level]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Tag] WITH NOCHECK ADD 
	CONSTRAINT [PK_Tag] PRIMARY KEY  CLUSTERED 
	(
		[TagNo]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Trackback] WITH NOCHECK ADD 
	CONSTRAINT [PK_Trackback] PRIMARY KEY  CLUSTERED 
	(
		[SeqNo]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[UserInfo] WITH NOCHECK ADD 
	CONSTRAINT [PK_UserInfo] PRIMARY KEY  CLUSTERED 
	(
		[EMail],
		[Name],
		[Homepage]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Article] ADD 
	CONSTRAINT [DF_Article_ViewCount] DEFAULT (0) FOR [ViewCount],
	CONSTRAINT [DF_Article_TrackbackCount] DEFAULT (0) FOR [TrackbackCount],
	CONSTRAINT [DF_Article_CommentCount] DEFAULT (0) FOR [CommentCount],
	CONSTRAINT [DF_Article_InsertDate] DEFAULT (getdate()) FOR [InsertDate]
GO

ALTER TABLE [dbo].[AttachFile] ADD 
	CONSTRAINT [DF_AttachFile_DownCount] DEFAULT (0) FOR [DownCount],
	CONSTRAINT [DF_AttachFile_InsertDate] DEFAULT (getdate()) FOR [InsertDate]
GO

 CREATE  INDEX [IX_Category] ON [dbo].[Category]([CategoryID]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Comment] ADD 
	CONSTRAINT [DF_Comment_InsertDate] DEFAULT (getdate()) FOR [InsertDate]
GO

ALTER TABLE [dbo].[ConnectionLog] ADD 
	CONSTRAINT [DF_ConnectionLog_InsertDate] DEFAULT (getdate()) FOR [InsertDate]
GO

ALTER TABLE [dbo].[Emoticon] ADD 
	CONSTRAINT [DF_Emoticon_InsertDate] DEFAULT (getdate()) FOR [InsertDate]
GO

ALTER TABLE [dbo].[Tag] ADD 
	CONSTRAINT [DF_Tag_InsertDate] DEFAULT (getdate()) FOR [InsertDate]
GO

ALTER TABLE [dbo].[Trackback] ADD 
	CONSTRAINT [DF_Trackback_InsertDate] DEFAULT (getdate()) FOR [InsertDate]
GO

ALTER TABLE [dbo].[UserInfo] ADD 
	CONSTRAINT [DF_UserInfo_InsertDate] DEFAULT (getdate()) FOR [InsertDate]
GO

ALTER TABLE [dbo].[AttachFile] ADD 
	CONSTRAINT [FK_AttachFile_Article] FOREIGN KEY 
	(
		[ArticleNo]
	) REFERENCES [dbo].[Article] (
		[ArticleNo]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[Comment] ADD 
	CONSTRAINT [FK_Comment_Article] FOREIGN KEY 
	(
		[ArticleNo]
	) REFERENCES [dbo].[Article] (
		[ArticleNo]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[Tag] ADD 
	CONSTRAINT [FK_Tag_Article] FOREIGN KEY 
	(
		[ArticleNo]
	) REFERENCES [dbo].[Article] (
		[ArticleNo]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

