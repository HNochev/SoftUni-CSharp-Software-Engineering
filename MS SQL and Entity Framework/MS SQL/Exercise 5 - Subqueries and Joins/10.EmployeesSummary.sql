--Problem 10
SELECT TOP(50) e.EmployeeID, CONCAT(e.FirstName,' ' , e.LastName) AS EmployeeName, CONCAT(mng.FirstName,' ' , mng.LastName) AS ManagerName, d.[Name]
	FROM Employees AS e
	JOIN Employees AS mng ON mng.EmployeeID = e.ManagerID
	JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	ORDER BY e.EmployeeID