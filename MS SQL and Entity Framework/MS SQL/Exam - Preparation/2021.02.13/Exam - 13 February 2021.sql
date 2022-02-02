--Problem 1
CREATE DATABASE Bitbucket

USE Bitbucket

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL

	 CONSTRAINT PK_RepositoriesContributors PRIMARY KEY(RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus VARCHAR(6) CHECK(LEN(IssueStatus) <= 6) NOT NULL,
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	Size DECIMAL(15,2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)

--Problem 2
INSERT INTO Files([Name], Size, ParentId, CommitId)
VALUES('Trade.idk',	2598.0,	1,	1),
('menu.net',	9238.31,	2,	2),
('Administrate.soshy',	1246.93,	3,	3),
('Controller.php',	7353.15,	4,	4),
('Find.java',	9957.86,	5,	5),
('Controller.json',	14034.87,	3,	6),
('Operate.xix',	7662.92,	7,	7)

INSERT INTO Issues(Title, IssueStatus, RepositoryId, AssigneeId)
VALUES('Critical Problem with HomeController.cs file',	'open',	1,	4),
('Typo fix in Judge.html',	'open',	4,	3),
('Implement documentation for UsersService.cs',	'closed',	8,	2),
('Unreachable code in Index.cs',	'open',	9,	8)

--Problem 3
UPDATE Issues
SET IssueStatus = 'closed'
WHERE Id = 6

--Problem 4
DELETE Issues WHERE RepositoryId = 3
DELETE RepositoriesContributors WHERE RepositoryId = 3

--Problem 5
SELECT Id, [Message], RepositoryId, ContributorId
	FROM Commits
	ORDER BY Id, [Message], RepositoryId, ContributorId

--Problem 6
SELECT Id, [Name], Size
	FROM Files
	WHERE Size > 1000 AND [Name] LIKE '%html%'
	ORDER BY Size DESC, Id, [Name]

--Problem 7
SELECT i.Id, u.Username + ' : ' + i.Title
	FROM Issues AS i
	JOIN Users AS u ON u.Id = i.AssigneeId
	ORDER BY i.Id DESC, u.Username ASC

--Problem 8
SELECT Id, [Name], CONVERT(VARCHAR(20),Size) + 'KB'
	FROM Files
	WHERE Id NOT IN(SELECT ParentId FROM Files WHERE ParentId IS NOT NULL)
	ORDER BY Id ASC, [Name] ASC, Size DESC
	
--Problem 9
SELECT TOP(5) r.Id, r.[Name], COUNT(*) AS Commits
	FROM Repositories AS r
	JOIN Commits AS c ON c.RepositoryId = r.Id
	JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
	GROUP BY r.Id, r.[Name]
	ORDER BY Commits DESC, r.Id, r.[Name]

--Problem 10
SELECT u.Username, AVG(f.Size) AS [avg]
	FROM Commits AS c
	JOIN Users AS u ON u.Id = c.ContributorId
	JOIN Files AS f ON f.CommitId = c.Id
	GROUP BY u.Id, u.Username
	ORDER BY [avg] DESC, u.Username 

--Problem 11
CREATE FUNCTION udf_AllUserCommits (@username VARCHAR(30))
RETURNS INT
AS
BEGIN
    RETURN (SELECT COUNT(*)
		FROM Users AS u
		JOIN Commits AS c ON c.ContributorId = u.Id
		WHERE Username = @username)
END

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

--Problem 12
CREATE PROCEDURE usp_SearchForFiles (@fileExtension VARCHAR(30))
AS
SELECT Id, [Name], CONVERT(VARCHAR(30), Size) + 'KB' AS Sizee
	FROM Files
	WHERE [Name] LIKE '%' + @fileExtension
	ORDER BY Id, [Name], Size DESC

EXEC usp_SearchForFiles 'txt'