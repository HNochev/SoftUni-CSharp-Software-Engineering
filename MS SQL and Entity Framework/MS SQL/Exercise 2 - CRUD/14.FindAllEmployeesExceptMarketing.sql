--Problem 14
SELECT FirstName, LastName
	FROM Employees
	WHERE DepartmentID != 4

SELECT FirstName, LastName
	FROM Employees
	WHERE NOT DepartmentID = 4