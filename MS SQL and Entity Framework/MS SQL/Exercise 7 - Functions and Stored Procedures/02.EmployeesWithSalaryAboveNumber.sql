--Problem 2
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@minSalary DECIMAL(18,4))
AS
SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @minSalary

EXEC usp_GetEmployeesSalaryAboveNumber 48100
