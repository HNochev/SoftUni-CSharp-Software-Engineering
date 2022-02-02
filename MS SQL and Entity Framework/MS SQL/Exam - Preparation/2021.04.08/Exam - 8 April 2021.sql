--Problem 1
CREATE DATABASE [Service]

USE [Service]

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(30),
	Birthdate DATE,
	Age INT CHECK(Age BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATE,
	Age INT CHECK(Age BETWEEN 18 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status]
(
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
	OpenDate DATE NOT NULL,
	CloseDate DATE,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--Problem 2
INSERT Employees(FirstName, LastName, Birthdate, DepartmentId) 
VALUES('Marlo',	'O''Malley', '09/21/1958',	1),
('Niki',	'Stanaghan',	'11/26/1969',	4),
('Ayrton',	'Senna',	'03/21/1960',	9	 ),
('Ronnie',	'Peterson',	'02/14/1944',	9),
('Giovanna',	'Amati',	'07/20/1959',	5)

INSERT Reports(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES(1, 1, '04/13/2017', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, '09/05/2015', '12/06/2015', 'Charity trail running', 3, 5),
(14, 2, '09/07/2015', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, '07/03/2017', '07/06/2017', 'Cut off streetlight on Str.11', 1, 1)

--Problem 3
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--Problem 4
DELETE Reports WHERE StatusId = 4

--Problem 5
SELECT [Description], FORMAT( OpenDate, 'dd-MM-yyyy') 
	FROM Reports
	WHERE EmployeeId IS NULL
	ORDER BY OpenDate, [Description] ASC

--Problem 6
SELECT r.[Description], c.[Name]
	FROM Reports AS r
	JOIN Categories AS c ON c.Id = r.CategoryId
	ORDER BY r.[Description], c.[Name]

--Problem 7
SELECT TOP(5) c.[Name] , COUNT(*) AS [ReportsNumber]
	FROM Reports AS r
	JOIN Categories AS c ON c.Id = r.CategoryId
	GROUP BY r.CategoryId, c.[Name]
	ORDER BY [ReportsNumber] DESC, c.[Name] ASC

--Problem 8
SELECT u.Username, c.[Name]
	FROM Users AS u
	JOIN Reports AS r ON r.UserId = u.Id
	JOIN Categories AS c ON c.Id = r.CategoryId
	WHERE DATEPART(MONTH,r.OpenDate) = DATEPART(MONTH, u.Birthdate) AND DATEPART(DAY,r.OpenDate) = DATEPART(DAY, u.Birthdate)
	ORDER BY u.Username, c.[Name]

--Problem 9
SELECT e.FirstName + ' ' + e.LastName AS [FullName], COUNT(r.UserId) AS [UsersCount]
	FROM Employees AS e
	LEFT JOIN Reports AS r ON r.EmployeeId = e.Id
	GROUP BY e.Id, e.FirstName, e.LastName
	ORDER BY UsersCount DESC, FullName

--Problem 10
SELECT	ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee,
		ISNULL(d.[Name], 'None') AS Department,
		ISNULL(c.[Name], 'None') AS Category,
		ISNULL(r.[Description], 'None'),
		ISNULL(FORMAT( r.OpenDate, 'dd.MM.yyyy'), 'None'),
		ISNULL(s.[Label], 'None'),
		ISNULL(u.[Name], 'None')
 	FROM Reports AS r
	LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
	LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
	LEFT JOIN Users AS u ON u.Id = r.UserId
	LEFT JOIN Categories AS c ON c.Id = r.CategoryId
	LEFT JOIN [Status] AS s ON s.Id = r.StatusId
	ORDER BY e.FirstName DESC, e.LastName DESC, Department ASC, Category ASC, r.[Description] ASC, r.OpenDate ASC, s.[Label] ASC, u.[Name] ASC

--Problem 11
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	If(@StartDate IS NULL OR @EndDate IS NULL)
	BEGIN
		RETURN 0
	END

   RETURN DATEDIFF(HOUR, @StartDate, @EndDate) 
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

--Problem 12
CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
if((SELECT TOP(1) d.Id FROM Employees AS e JOIN Departments AS d ON d.Id = e.DepartmentId WHERE e.Id = @EmployeeId) = (SELECT TOP(1) c.DepartmentId FROM Reports AS r JOIN Categories AS c ON c.Id = r.CategoryId WHERE r.Id = @ReportId))
BEGIN
	UPDATE Reports
	SET EmployeeId = @EmployeeId
	WHERE Id = @ReportId
END
ELSE
BEGIN
	THROW 51001, 'Employee doesn''t belong to the appropriate department!', 1; 
END

EXEC usp_AssignEmployeeToReport 30, 1

EXEC usp_AssignEmployeeToReport 17, 2