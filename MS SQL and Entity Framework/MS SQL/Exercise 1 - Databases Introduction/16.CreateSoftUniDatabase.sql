--Problem 16
CREATE DATABASE SoftUni

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	AddressText NVARCHAR(100),
	TownId INT NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL,
	HireDate DATE,
	Salary DECIMAL(10,2) NOT NULL,
	AddressId INT
)
