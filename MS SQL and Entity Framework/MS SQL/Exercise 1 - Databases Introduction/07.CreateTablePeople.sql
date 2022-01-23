--Problem 7
CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(200) NOT NULL,
	Picture BIT,
	Height DECIMAL(10,2),
	[Weight] DECIMAL(10,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(max)
)

INSERT INTO People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES
('Ivan', 1, 1.80, 85.50, 'm', '2000-02-25', 'Hello'),
('Georgi', 1, 1.82, 65.50, 'm', '2000-02-01', NULL),
('Hristo', 2, 1.74, NULL, 'm', '2000-02-04', 'Hello its me'),
('Yasen', 2, NULL, 95.50, 'm', '2000-09-30', 'adaffsfas'),
('Angela', 1, 1.65, 55.50, 'f', '1999-02-21', 'asfasfaswrrw')