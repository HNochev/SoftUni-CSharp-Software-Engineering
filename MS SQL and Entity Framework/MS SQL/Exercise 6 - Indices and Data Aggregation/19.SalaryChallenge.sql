--Problem 19
SELECT TOP(10) eOne.FirstName, eOne.LastName, eOne.DepartmentID
	FROM Employees AS eOne
	WHERE Salary > (SELECT AVG(Salary) AS AverageSalary
		FROM Employees AS eTwo
		WHERE eTwo.DepartmentID = eOne.DepartmentID
		GROUP BY DepartmentID)
	ORDER BY eOne.DepartmentID