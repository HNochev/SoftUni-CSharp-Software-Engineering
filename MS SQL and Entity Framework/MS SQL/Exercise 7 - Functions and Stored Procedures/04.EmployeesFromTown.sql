--Problem 4
CREATE PROC usp_GetEmployeesFromTown @townName NVARCHAR(30)
AS
SELECT e.FirstName, e.LastName
	FROM Employees AS e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
	WHERE t.[Name] = @townName

EXEC usp_GetEmployeesFromTown 'Sofia'