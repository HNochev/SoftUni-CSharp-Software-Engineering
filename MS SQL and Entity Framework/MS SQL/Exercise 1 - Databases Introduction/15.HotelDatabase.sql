--Problem 15
CREATE DATABASE Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Ivan', 'Goranov', 'Emp', NULL),
('Ivana', 'Dimitrova', 'Mng', 'ABC'),
('Diana', 'Ivanova', 'Emp', NULL)


CREATE TABLE Customers
(
	AccountNumber VARCHAR(50) NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	EmergencyName NVARCHAR(50) NOT NULL,
	EmergencyNumber CHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
(21, 'Ivan', 'Goranov', '0985426633', 'Petar Petkov', '0524632743', NULL),
(43, 'Ivana', 'Dimitrova', '0964326633', 'Dimo Vratanov', '0524632743', NULL),
(26, 'Diana', 'Ivanova', '0985463533', 'Sesil Petrova', '0524632743', NULL)

CREATE TABLE RoomStatus
(
	RoomStatus NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus(RoomStatus, Notes) VALUES
('Cleaning', NULL),
('Free', NULL),
('Not Free', NULL)

CREATE TABLE RoomTypes
(
	RoomType NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes(RoomType, Notes) VALUES
('Studio', NULL),
('One-Room', NULL),
('Two-Room', NULL)

CREATE TABLE BedTypes
(
	BedType NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes(BedType, Notes) VALUES
('One-Two Person', NULL),
('Two People', NULL),
('Two-Three People', NULL)

CREATE TABLE Rooms
(
	RoomNumber INT NOT NULL,
	RoomType NVARCHAR(20) NOT NULL,
	BedType NVARCHAR(20) NOT NULL,
	Rate DECIMAL(5,2),
	RoomStatus NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(11, 'Studio', 'One-Two Person', NULL, 'Not Free', NULL),
(12, 'Two-Room', 'Two-Three People', NULL, 'Not Free', NULL),
(13, 'One-Room', 'Two People', NULL, 'Free', NULL)

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber VARCHAR(50) NOT NULL,
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(5,2) NOT NULL,
	TaxRate DECIMAL(5,2),
	TaxAmount DECIMAL(5,2),
	PaymentTotal DECIMAL(5,2) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
(2, '2021-04-06', 43, '2021-04-05', '2021-04-09', 4, 112.00, NULL, NULL, 112.00, NULL),
(3, '2021-04-07', 26, '2021-04-05', '2021-04-15', 10, 323.00, NULL, NULL, 323.00, NULL),
(1, '2021-04-05', 21, '2021-04-05', '2021-04-14', 8, 208.00, NULL, NULL, 208.00, NULL)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT NOT NULL,
	DateOccupied DATE NOT NULL,
	AccountNumber VARCHAR(50) NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied DECIMAL(5,2),
	PhoneCharge CHAR(10),
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(1, '2021-04-05', 21, 11, NULL, NULL, NULL),
(2, '2021-04-05', 26, 12, NULL, NULL, NULL),
(3, '2021-04-05', 43, 13, NULL, NULL, NULL)
