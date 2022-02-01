--Problem 1
CREATE DATABASE ColonialJourney

USE ColonialJourney

CREATE TABLE Planets
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT FOREIGN KEY REFERENCES Planets(Id)
)

CREATE TABLE Spaceships
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT(0)
)


CREATE TABLE Colonists
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) UNIQUE NOT NULL,
	BirthDate DATE NOT NULL
)

CREATE TABLE Journeys
(
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) CHECK(Purpose IN('Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
)

CREATE TABLE TravelCards
(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber CHAR(10) CHECK(LEN(CardNumber) = 10) UNIQUE NOT NULL,
	JobDuringJourney VARCHAR(8) CHECK(JobDuringJourney IN('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId INT FOREIGN KEY REFERENCES Colonists(Id),
	JourneyId INT FOREIGN KEY REFERENCES Journeys(Id)
)

--Problem 2
INSERT INTO Planets([Name]) VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships([Name], Manufacturer, LightSpeedRate ) VALUES
('Golf', 'VW',	3),
('WakaWaka', 'Wakanda',	4),
('Falcon9', 'SpaceX',	1 ),
('Bed', 'Vidolov',	6)

--Problem 3
UPDATE Spaceships
SET LightSpeedRate = LightSpeedRate + 1
WHERE Id BETWEEN 8 AND 12

--Problem 4
DELETE TravelCards WHERE JourneyId IN(1, 2, 3)

DELETE TOP(3) Journeys

--Problem 5
SELECT Id, FORMAT(JourneyStart, 'dd/MM/yyyy'), FORMAT(JourneyEnd, 'dd/MM/yyyy')
	FROM Journeys
	WHERE Purpose = 'Military'
	ORDER BY JourneyStart

--Problem 6
SELECT c.Id, CONCAT(FirstName, ' ', LastName)
	FROM Colonists AS c
	JOIN TravelCards AS tc ON tc.ColonistId = c.Id
	WHERE JobDuringJourney = 'Pilot'
	ORDER BY c.Id

--Problem 7
SELECT COUNT(*) AS [count]
	FROM Colonists AS c
	JOIN TravelCards AS tc ON tc.ColonistId = c.Id
	JOIN Journeys AS j ON j.Id = tc.JourneyId
	WHERE j.Purpose = 'Technical'

--Problem 8
SELECT s.[Name], s.Manufacturer
	FROM Spaceships AS s
	JOIN Journeys AS j ON j.SpaceshipId = s.Id
	JOIN TravelCards AS tc ON tc.JourneyId = j.Id
	JOIN Colonists AS c ON c.Id = tc.ColonistId
	WHERE tc.JobDuringJourney = 'Pilot' AND DATEDIFF(YEAR, c.BirthDate, '01/01/2019') < 30
	ORDER BY s.[Name]

--Problem 9
SELECT p.[Name], COUNT(*) AS [JourneysCount]
	FROM Planets AS p
	JOIN Spaceports AS sp ON sp.PlanetId = p.Id
	JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id
	GROUP BY p.Id, p.[Name]
	ORDER BY [JourneysCount] DESC, p.[Name]

--Problem 10

SELECT k.JobDuringJourney, k.FullName, k.JobRank
	FROM (
		SELECT tc.JobDuringJourney, CONCAT(c.FirstName, ' ', c.LastName) AS [FullName], RANK() OVER(PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate ASC) AS [JobRank]
			FROM Colonists AS c
			JOIN TravelCards AS tc ON tc.ColonistId = c.Id) AS k
	WHERE k.JobRank = 2

--Problem 11
CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30)) 
RETURNS INT 
AS
BEGIN
    RETURN (SELECT COUNT(*) AS [Count]
		FROM Planets AS p
		JOIN Spaceports AS sp ON sp.PlanetId = p.Id
		JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id
		JOIN TravelCards AS tc ON tc.JourneyId = j.Id
		JOIN Colonists AS c ON c.Id = tc.ColonistId
		WHERE p.[Name] = @PlanetName)
END
    
SELECT dbo.udf_GetColonistsCount('Otroyphus')

--Problem 12
CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(12))
AS
IF(NOT EXISTS (SELECT * FROM Journeys WHERE Id = @JourneyId))
	BEGIN
		;THROW 50001, 'The journey does not exist!', 1
	END

IF((SELECT TOP(1) Purpose FROM Journeys WHERE Id = @JourneyId) = @NewPurpose)
	BEGIN
		;THROW 50002, 'You cannot change the purpose!', 1
	END

UPDATE Journeys
SET Purpose = @NewPurpose
WHERE Id = @JourneyId

EXEC usp_ChangeJourneyPurpose 4, 'Technical'

EXEC usp_ChangeJourneyPurpose 2, 'Educational'

EXEC usp_ChangeJourneyPurpose 196, 'Technical'