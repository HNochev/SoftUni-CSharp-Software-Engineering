--Problem 3
CREATE PROC usp_GetTownsStartingWith @townString NVARCHAR(30)
AS
SELECT [Name]
	FROM Towns
	WHERE [Name] LIKE @townString + '%'

EXEC usp_GetTownsStartingWith 'R'