--Problem 8
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN(SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

UPDATE Employees
	SET ManagerID = NULL
	WHERE EmployeeID IN(SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @departmentId

DELETE FROM Employees
	WHERE DepartmentID = @departmentId

DELETE FROM Departments
	WHERE DepartmentID = @departmentId

SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @departmentId