--Problem 14
SELECT DepartmentID, MIN(Salary) AS MinSalary
	FROM Employees
	WHERE DepartmentID IN(2, 5, 7) AND HireDate > '01/01/2000'
	GROUP BY DepartmentID