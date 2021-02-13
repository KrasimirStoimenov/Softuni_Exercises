--12.	 Search for Files

CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(MAX))
AS
	SELECT Id,[Name],CONCAT(Size,'KB') AS Size
	FROM Files
	WHERE SUBSTRING([Name],CHARINDEX('.',[Name])+1,LEN([Name])) = @fileExtension
GO

EXEC usp_SearchForFiles 'txt'