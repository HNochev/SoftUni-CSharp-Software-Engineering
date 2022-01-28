--Problem 18
SELECT k.DepartmentID, k.Salary
	FROM(SELECT DepartmentID, Salary, DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
	FROM Employees
	GROUP BY DepartmentID, Salary) AS k
	WHERE k.[Rank] = 3