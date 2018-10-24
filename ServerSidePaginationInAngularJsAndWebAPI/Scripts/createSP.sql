USE [sample]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE Procedure [dbo].[GetEmployees]
(
 @PageIndex INT,
 @pageSize INT 
) 
As
 Begin
 SELECT * FROM employee ORDER BY id OFFSET @PageSize*(@PageIndex-1) ROWS FETCH NEXT @PageSize ROWS ONLY;

 SELECT count(*) as totalCount FROM employee;
 End

GO

