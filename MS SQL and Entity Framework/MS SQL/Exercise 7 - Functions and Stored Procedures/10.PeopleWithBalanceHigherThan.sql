--Problem 10
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan @money FLOAT
AS
SELECT k.FirstName, k.LastName
	FROM(
	SELECT ah.FirstName, ah.LastName, SUM(a.Balance) AS SumBalance
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.AccountHolderId = ah.Id
	GROUP BY ah.Id, ah.FirstName, ah.LastName) AS k
		WHERE k.SumBalance > @money
		ORDER BY k.FirstName, k.LastName

EXEC usp_GetHoldersWithBalanceHigherThan 100000