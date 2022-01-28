--Problem 3
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits
	GROUP BY DepositGroup