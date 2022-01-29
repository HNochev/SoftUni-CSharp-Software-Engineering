--Problem 1
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000

EXEC usp_GetEmployeesSalaryAbove35000