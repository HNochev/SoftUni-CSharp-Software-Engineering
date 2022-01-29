--Problem 12
CREATE PROCEDURE usp_CalculateFutureValueForAccount(@accountID INT, @intrestRate FLOAT)
AS
SELECT a.Id, ah.FirstName, ah.LastName, a.Balance, dbo.ufn_CalculateFutureValue(a.Balance, @intrestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.AccountHolderId = ah.Id
	WHERE a.Id = @accountID

EXEC usp_CalculateFutureValueForAccount 1, 0.1