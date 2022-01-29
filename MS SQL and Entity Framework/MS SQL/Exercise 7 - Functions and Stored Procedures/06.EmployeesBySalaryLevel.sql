--Problem 6
CREATE PROCEDURE usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(10)
AS
SELECT FirstName, LastName
	FROM(
		SELECT FirstName, LastName, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
			FROM Employees ) AS k
	WHERE k.[Salary Level] = @salaryLevel

EXEC usp_EmployeesBySalaryLevel 'High'