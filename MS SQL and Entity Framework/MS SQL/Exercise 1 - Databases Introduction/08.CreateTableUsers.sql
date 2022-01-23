--Problem 8
CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARCHAR(MAX),
	LastLoginTime DATETIME DEFAULT GETDATE(),
	IsDeleted BIT DEFAULT 'false'
)

INSERT INTO Users(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) VALUES
('Ivan', '123456', NULL, '2000-02-25', 1),
('Ivana', '1232323456', NULL, '2000-02-25', 0),
('Hristo', '1232324456', NULL, '2021-02-25', 0),
('Georgi', '123dfds456', NULL, '2020-02-25', 0),
('Daria', '12345dsgs6', NULL, '2014-02-25', 1)
