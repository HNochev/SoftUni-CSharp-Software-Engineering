--Problem 12
SELECT SUM([first].DepositAmount - [second].DepositAmount) AS SumDifference
	FROM WizzardDeposits AS [first]
	JOIN WizzardDeposits AS [second] ON [second].Id = [first].Id + 1

SELECT SUM(k.Diff)
	FROM(
		SELECT [first].DepositAmount -
			LEAD([first].DepositAmount, 1) OVER (ORDER BY [first].Id) AS Diff
	FROM WizzardDeposits AS [first]) AS k