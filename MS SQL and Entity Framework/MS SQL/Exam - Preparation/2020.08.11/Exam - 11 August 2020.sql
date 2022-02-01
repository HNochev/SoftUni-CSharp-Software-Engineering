--Problem 1
CREATE DATABASE Bakery

USE Bakery

CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR(1) CHECK(Gender IN('M', 'F')),
	Age INT,
	PhoneNumber CHAR(10) CHECK(LEN(PhoneNumber) = 10),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE,
	[Description] NVARCHAR(250),
	Recipe NVARCHAR(MAX),
	Price DECIMAL(15,4) CHECK(Price >= 0)
)

CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(255),
	Rate DECIMAL(15,2) CHECK(Rate >= 0 AND Rate <= 10),
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
)

CREATE TABLE Distributors
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE,
	AddressText NVARCHAR(30),
	Summary NVARCHAR(200),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30),
	[Description] NVARCHAR(200),
	OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id),
	DistributorId INT FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	IngredientId INT FOREIGN KEY REFERENCES Ingredients(Id)

	CONSTRAINT PK_ProductsIngredients PRIMARY KEY (ProductId, IngredientId)
)

--Problem 2
INSERT INTO Distributors([Name], CountryId, AddressText, Summary)
VALUES('Deloitte & Touche',	2,	'6 Arch St #9757',	'Customizable neutral traveling'),
('Congress Title',	13,	'58 Hancock St', 'Customer loyalty'),
('Kitchen People',	1,	'3 E 31st St #77',	'Triple-buffered stable delivery'),
('General Color Co Inc',	21,	'6185 Bohn St #72',	'Focus group'),
('Beck Corporation',	23,	'21 E 64th Ave',	'Quality-focused 4th generation hardware')

INSERT INTO Customers(FirstName, LastName, Age, Gender, PhoneNumber, CountryId)
VALUES('Francoise',	'Rautenstrauch',	15,	'M',	'0195698399',	5),
('Kendra',	'Loud',	22,	'F',	'0063631526',	11),
('Lourdes',	'Bauswell',	50,	'M',	'0139037043',	8),
('Hannah',	'Edmison',	18,	'F',	'0043343686',	1),
('Tom',	'Loeza',	31,	'M',	'0144876096',	23),
('Queenie',	'Kramarczyk',	30,	'F',	'0064215793',	29),
('Hiu',	'Portaro',	25,	'M',	'0068277755',	16),
('Josefa',	'Opitz',	43,	'F',	'0197887645',	17)

--Problem 3
UPDATE Ingredients
SET DistributorId = 35
WHERE [Name] IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

--Problem 4
DELETE Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

--Problem 5
SELECT [Name], Price, [Description]
	FROM Products
	ORDER BY Price DESC, [Name]

--Problem 6
SELECT f.ProductId, f.Rate, f.[Description], f.CustomerId, c.Age, c.Gender
	FROM Feedbacks AS f
	JOIN Customers AS c ON c.Id = f.CustomerId
	WHERE f.Rate < 5.0
	ORDER BY f.ProductId DESC, f.Rate

--Problem 7
SELECT CONCAT(c.FirstName, ' ', c.LastName), c.PhoneNumber, c.Gender
	FROM Customers AS c
	WHERE c.Id NOT IN(SELECT CustomerId FROM Feedbacks)
	ORDER BY c.Id

--Problem 8
SELECT cu.FirstName, cu.Age, cu.PhoneNumber
	FROM Customers AS cu
	JOIN Countries AS co ON co.Id = cu.CountryId
	WHERE (cu.Age >= 21 AND cu.FirstName LIKE '%an%') OR cu.PhoneNumber LIKE '%38' AND co.[Name] NOT IN('Greece')
	ORDER BY cu.FirstName, cu.Age DESC 

--Problem 9
SELECT d.[Name], i.[Name], p.[Name], AVG(f.Rate) AS [Average]
	FROM Distributors AS d
	JOIN Ingredients AS i ON i.DistributorId = d.Id
	JOIN ProductsIngredients AS [pi] ON [pi].IngredientId = i.Id
	JOIN Products AS p ON p.Id = [pi].ProductId
	JOIN Feedbacks AS f ON f.ProductId = p.Id
	GROUP BY d.[Name], i.[Name], p.[Name]
	HAVING AVG(f.Rate) BETWEEN 5 AND 8
	ORDER BY d.[Name], i.[Name], p.[Name]

--Problem 10
SELECT k.CountryName, k.DistributorName
	FROM (SELECT c.[Name] AS CountryName, d.[Name] AS DistributorName, COUNT(*) AS Coun, RANK() OVER(PARTITION BY c.[Name] ORDER BY COUNT(*) DESC) AS Ranked
	FROM Countries AS c
	JOIN Distributors AS d ON d.CountryId = c.Id
	JOIN Ingredients AS i ON i.DistributorId = d.Id
	GROUP BY c.Id, c.[Name], d.Id, d.[Name]
	) AS k
	WHERE k.Ranked = 1
	ORDER BY k.CountryName, k.DistributorName

--Problem 11
CREATE VIEW v_UserWithCountries AS
SELECT cu.FirstName + ' ' + cu.LastName AS [CustomerName], cu.Age, cu.Gender, co.[Name] AS [CountryName]
	FROM Customers AS cu
	JOIN Countries AS co ON co.Id = cu.CountryId

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

--Problem 12
CREATE TRIGGER tr_deleteFromTables
ON Products FOR DELETE
AS
  DELETE FROM ProductsIngredients WHERE ProductId = (SELECT deleted.id FROM deleted)
  DELETE FROM Feedbacks WHERE ProductId = (SELECT deleted.id FROM deleted)
  DELETE FROM Customers WHERE Id = (SELECT CustomerId FROM Feedbacks WHERE ProductId = (SELECT deleted.id FROM deleted))
GO

DELETE FROM Products WHERE Id = 7