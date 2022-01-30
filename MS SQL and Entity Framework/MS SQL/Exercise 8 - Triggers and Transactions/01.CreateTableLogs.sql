--Problem 1
CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY(1, 1),
	AccountId INT,
	OldSum DECIMAL(15, 2),
	NewSum DECIMAL(15, 2)
)

CREATE TRIGGER tr_InsertAccountInfo ON Accounts FOR UPDATE
AS
DECLARE @newSum DECIMAL(15,2) = (SELECT Balance FROM inserted)
DECLARE @oldSum DECIMAL(15,2) = (SELECT Balance FROM deleted)
DECLARE @accountId INT = (SELECT Id FROM inserted)

INSERT INTO Logs (AccountId, NewSum, OldSum) VALUES (@accountId, @newSum, @oldSum)

UPDATE Accounts
SET Balance = Balance + 20
WHERE Id = 1

SELECT *
	FROM Logs