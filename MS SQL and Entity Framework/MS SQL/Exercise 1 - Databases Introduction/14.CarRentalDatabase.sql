--Problem 14
CREATE DATABASE CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CategoryName VARCHAR(100) NOT NULL,
	DailyRate INT NOT NULL,
	WeeklyRate INT NOT NULL,
	MonthlyRate INT NOT NULL,
	WeekendRate INT NOT NULL,
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('First', 1, 2, 3, 4),
('Second', 3, 2, 1, 4),
('Third', 2, 1, 4, 3)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	PlateNumber VARCHAR(8) NOT NULL,
	Manufacturer VARCHAR(100) NOT NULL,
	Model VARCHAR(100) NOT NULL,
	CarYear DATE NOT NULL,
	CategoryId INT NOT NULL,
	Doors INT NOT NULL,
	Picture VARCHAR(MAX),
	Condition VARCHAR(MAX),
	Available BIT NOT NULL
)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('X1234BC', 'Opel', 'Astra', '2020', 1, 4, 'Example Picture', 'Excellent', 0),
('CA5226KA', 'Dodge', 'Avenger', '2014', 2, 4, NULL, 'Excellent', 1),
('PB4252KB', 'Fiat', 'Freemont', '2017', 3, 5, NULL, 'Excellent', 1)

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	Title VARCHAR(100) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Ivan', 'Ivanov', 'Manager', 'Good'),
('Iordan', 'Petrov', 'Sales', 'Good'),
('Cvetan', 'Dimitrov', 'Acountant', NULL)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DriverLicenceNumber VARCHAR(20) NOT NULL,
	FullName VARCHAR(200) NOT NULL,
	[Address] VARCHAR(MAX),
	City VARCHAR(50) NOT NULL,
	ZIPCode VARCHAR(100) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
('5353252315', 'Elena Antonova', NULL, 'Haskovo', 6300, NULL),
('2352352352', 'Miroslava Georgieva', NULL, 'Haskovo', 6300, NULL),
('3252365326', 'Todor Todorov', NULL, 'Dimitrovgrad', 6400, NULL)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel DECIMAL(10,2) NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate	DATE NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied DECIMAL(10,2),
	TaxRate DECIMAL(10,2),
	OrderStatus VARCHAR(10) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(1, 1, 3, 50.00, 142522, 151111, 1000, '2020-03-21', '2020-03-30', 9, NULL, NULL, 'Ended', NULL),
(3, 2, 1, 45.00, 242233, 248999, 1000, '2020-03-21', '2020-03-28', 7, NULL, NULL, 'Ended', NULL),
(2, 3, 2, 55.50, 174534, 179099, 1000, '2020-03-21', '2020-03-29', 8, NULL, NULL, 'Ended', NULL)
