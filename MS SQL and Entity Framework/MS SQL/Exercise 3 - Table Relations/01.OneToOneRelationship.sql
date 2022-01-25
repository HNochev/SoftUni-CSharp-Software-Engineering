--Problem 1
CREATE DATABASE LectureThree
CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY IDENTITY(101, 1),
	PassportNumber CHAR(8)
)
CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY(1, 1),
	FirstName NVARCHAR(30),
	Salary DECIMAL(10,2),
	PassportID INT UNIQUE FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Passports(PassportNumber)
VALUES ('N34FG21B')
INSERT INTO Passports(PassportNumber)
VALUES ('K65LO4R7')
INSERT INTO Passports(PassportNumber)
VALUES ('ZE657QP2')

INSERT INTO Persons(FirstName, Salary, PassportID)
VALUES ('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101)
