--Problem 13
CREATE DATABASE	Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DirectorName VARCHAR(100) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Directors(DirectorName, Notes) VALUES 
('Ed', NULL),
('Adam', NULL),
('Shen', 'Best One'),
('Galio', NULL),
('New', 'Hello')

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	GenreName VARCHAR(100) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Genres(GenreName, Notes) VALUES 
('Comedy', 'One'),
('Horror', 'Five'),
('Action', 'Three'),
('Romantic', 'Four'),
('Documental', 'Two')

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CategoryName VARCHAR(100) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Categories(CategoryName, Notes) VALUES 
('First', NULL),
('Second', NULL),
('Third', NULL),
('Fourht', NULL),
('Fifth', NULL)


CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title VARCHAR(100) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear VARCHAR(5) NOT NULL,
	[Length] TIME,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating DECIMAL(10,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) VALUES
('The One', 1, '2019', '01:58',1, 2, NULL, NULL),
('The Two', 3, '2019', '01:52',2, 3, 6.99, NULL),
('The Three', 2, '2018', '01:43',3, 1, 8.53, NULL),
('The Four', 4, '2020', '01:53',4, 5, 7.77, NULL),
('The Five', 5, '2019', '01:19',5, 4, 3.33, NULL)
