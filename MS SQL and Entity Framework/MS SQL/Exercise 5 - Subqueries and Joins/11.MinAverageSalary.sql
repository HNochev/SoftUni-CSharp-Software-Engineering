--Problem 11
SELECT TOP(1) AVG(e.Salary) AS MinAverageSalary
	FROM Employees AS e
	JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	GROUP BY d.[Name]
	ORDER BY MinAverageSalary