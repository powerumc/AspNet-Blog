if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CategoryView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[CategoryView]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.CategoryView
AS
SELECT   TOP 100 PERCENT C.CategoryID, C.CategoryTitle, C.CategoryLCode, 
                C.CategoryMCode, C.CategoryGroup, C.CategoryStep, C.CategoryOrder, 
                CL.CategoryLTitle, CM.CategoryMTitle
FROM      dbo.Category AS C LEFT OUTER JOIN
                dbo.CategoryLCode AS CL ON 
                C.CategoryLCode = CL.CategoryLCode LEFT OUTER JOIN
                dbo.CategoryMCode AS CM ON C.CategoryLCode = CM.CategoryLCode AND 
                C.CategoryMCode = CM.CategoryMCode
ORDER BY C.CategoryGroup, C.CategoryStep, C.CategoryOrder

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

