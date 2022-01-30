--Problem 8
CREATE PROCEDURE usp_AssignProject (@employeeId INT, @projectId INT)
AS
BEGIN TRANSACTION
DECLARE @employee INT = (SELECT EmployeeID FROM Employees WHERE EmployeeID = @employeeId)
DECLARE @project INT = (SELECT ProjectID FROM Projects WHERE ProjectID = @projectId)

IF(@employee IS NULL OR @project IS NULL)
BEGIN
	ROLLBACK
	RAISERROR('Invalid employee id or project id!', 16, 1)
	RETURN
END

DECLARE @employeeProject INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @employeeId)

IF(@employeeProject >= 3)
BEGIN
	ROLLBACK
	RAISERROR('The employee has too many projects!', 16, 2) 
	RETURN
END

INSERT INTO EmployeesProjects(EmployeeID, ProjectID) VALUES (@employeeId, @projectId)
COMMIT

EXEC usp_AssignProject 2, 4

SELECT *
	FROM EmployeesProjects
	WHERE EmployeeID = 2