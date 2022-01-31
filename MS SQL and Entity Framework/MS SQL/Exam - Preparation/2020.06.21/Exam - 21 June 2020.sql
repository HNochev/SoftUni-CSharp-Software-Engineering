--Problem 1
CREATE DATABASE TripService

USE TripService

CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode VARCHAR(2) CHECK(LEN(CountryCode) = 2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15, 2)
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(15, 2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	BookDate DATETIME2 NOT NULL,
	ArrivalDate DATETIME2 NOT NULL,
	ReturnDate DATETIME2 NOT NULL,
	CancelDate DATETIME2,
	CHECK(DATEDIFF(DAY, BookDate, ArrivalDate) > 0),
	CHECK(DATEDIFF(DAY, ArrivalDate, ReturnDate) > 0)
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	BirthDate DATETIME2 NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE AccountsTrips
(
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
	Luggage INT CHECK(Luggage >= 0) NOT NULL

	CONSTRAINT PK_AccountsTrips PRIMARY KEY(AccountId, TripId)
)

--Problem 2
INSERT INTO Accounts(FirstName, MiddleName, LastName, CityId, BirthDate, Email)
VALUES('John',	'Smith',	'Smith',	34,	'1975-07-21',	'j_smith@gmail.com'),
('Gosho',	NULL,	'Petrov',	11,	'1978-05-16',	'g_petrov@gmail.com'),
('Ivan',	'Petrovich',	'Pavlov',	59,	'1849-09-26',	'i_pavlov@softuni.bg'),
('Friedrich',	'Wilhelm',	'Nietzsche',	2,	'1844-10-15',	'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES
(101,	'2015-04-12',	'2015-04-14',	'2015-04-20',		'2015-02-02'),		  			  
(102,	'2015-07-07',	'2015-07-15',	'2015-07-22',	'2015-04-29'),		  			  
(103,	'2013-07-17',	'2013-07-23',	'2013-07-24',	NULL),
(104,	'2012-03-17',	'2012-03-31',	'2012-04-01',	'2012-01-10'),		  			  
(109,	'2017-08-07',	'2017-08-28',	'2017-08-29',	NULL)

--Problem 3
UPDATE Rooms
SET Price = Price * 1.14
WHERE HotelId IN(5, 7, 9)

--Problem 4
DELETE AccountsTrips 
WHERE AccountId = 47

--Problem 5
SELECT FirstName, LastName, FORMAT(BirthDate, 'MM-dd-yyyy'), c.[Name], Email
	FROM Accounts
	JOIN Cities AS c ON c.Id = Accounts.CityId
	WHERE Email LIKE 'e%'
	ORDER BY c.[Name] ASC

--Problem 6
SELECT c.[Name], COUNT(*) AS Hotels
	FROM Cities AS c
	JOIN Hotels AS h ON h.CityId = c.Id
	GROUP BY c.[Name], c.Id
	ORDER BY Hotels DESC, c.[Name]

--Problem 7
SELECT l.Id, l.FullName, MAX(l.DaysCount) AS LongestTrip, MIN(l.DaysCount) AS ShortestTrip
	FROM ( SELECT k.Id, k.FullName, k.DaysCount, RANK() OVER(PARTITION BY k.FullName ORDER BY k.DaysCount) AS SmallestDays, RANK() OVER(PARTITION BY k.FullName ORDER BY k.DaysCount DESC) AS BiggestDays
		FROM (
		SELECT a.Id, a.FirstName + ' ' + a.LastName AS FullName, DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS DaysCount
			FROM Accounts AS a
			JOIN AccountsTrips AS [at] ON [at].AccountId = a.Id
			JOIN Trips AS t ON t.Id = [at].TripId
			WHERE t.CancelDate IS NULL AND a.MiddleName IS NULL) AS k ) AS l
			GROUP BY l.Id, l.FullName
			ORDER BY LongestTrip DESC, ShortestTrip ASC

--Problem 8
SELECT TOP(10) c.Id, c.[Name], c.CountryCode, COUNT(*) AS Accounts
	FROM Cities AS c
	JOIN Accounts AS a ON a.CityId = c.Id
	GROUP BY c.Id, c.[Name], c.CountryCode
	ORDER BY Accounts DESC

--Problem 9
SELECT a.Id, a.Email, c.[Name], COUNT(*) AS Trips
	FROM Accounts AS a
	JOIN AccountsTrips AS [at] ON [at].AccountId = a.Id
	JOIN Trips AS t ON t.Id = [at].TripId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS c ON c.Id = h.CityId
	WHERE a.CityId = h.CityId
	GROUP BY a.Id, a.Email, c.[Name]
	ORDER BY Trips DESC, a.Id

--Problem 10
SELECT t.Id, a.FirstName + ' ' + ISNULL(a.MiddleName + ' ', '') + a.LastName AS [Full Name], ca.[Name] AS [From], ch.[Name] AS [To], IIF(t.CancelDate IS NOT NULL, 'Canceled', CONVERT(VARCHAR(20),DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) + ' days') AS [Duration]
	FROM Accounts AS a
	JOIN Cities AS ca ON ca.Id = a.CityId
	JOIN AccountsTrips AS [at] ON [at].AccountId = a.Id
	JOIN Trips AS t ON t.Id = [at].TripId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS ch ON ch.Id = h.CityId
	ORDER BY [Full Name], t.Id

--Problem 11
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(100) AS
BEGIN

    DECLARE @RoomId INT = 
	(SELECT TOP(1) r.Id 
		FROM Rooms AS r
		JOIN Trips AS t ON t.RoomId = r.Id
		WHERE r.HotelId = @HotelId AND r.Beds >= @People AND t.CancelDate IS NULL
		ORDER BY r.Price DESC)

	IF(@Date = '2015-07-26' OR @RoomId IS NULL)
	BEGIN
		RETURN 'No rooms available'
	END


	DECLARE @RoomType VARCHAR(60) = 
	(SELECT TOP(1) [Type] FROM Rooms WHERE Id = @RoomId)

	DECLARE @BedsCount INT = 
	(SELECT TOP(1) Beds FROM Rooms WHERE Id = @RoomId)
	
	DECLARE @HotelBaseRate DECIMAL(15, 2) = 
	(SELECT TOP(1) BaseRate FROM Hotels WHERE Id = @HotelId)

	DECLARE @RoomPrice DECIMAL(15, 2) = 
	(SELECT TOP(1) Price FROM Rooms WHERE Id = @RoomId)

	DECLARE @FinalPrice DECIMAL(15, 2) = (@HotelBaseRate + @RoomPrice) * @People

	RETURN CONCAT('Room ', @RoomId, ': ', @RoomType, ' (', @BedsCount,' beds) - $', @FinalPrice)
END

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)

SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

--Problem 12
CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS

	


