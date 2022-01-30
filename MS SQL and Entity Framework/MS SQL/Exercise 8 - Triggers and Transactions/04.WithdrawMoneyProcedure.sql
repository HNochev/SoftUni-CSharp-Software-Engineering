--Problem 4
CREATE PROCEDURE usp_WithdrawMoney @accountId INT, @moneyAmount DECIMAL(15, 4)
AS
BEGIN TRANSACTION

DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)
DECLARE @accountBalance DECIMAL(15, 4) = (SELECT Balance FROM Accounts WHERE Id = @accountId)

IF(@account IS NULL)
BEGIN
	ROLLBACK
	RAISERROR('Invalid account id!', 16, 1)
	RETURN
END

IF(@moneyAmount < 0)
BEGIN
	ROLLBACK
	RAISERROR('Negative amount!', 16, 1)
	RETURN
END

IF(@accountBalance - @moneyAmount < 0)
BEGIN
	ROLLBACK
	RAISERROR('You dont have enough money!', 16, 1)
	RETURN
END

UPDATE Accounts
SET Balance = Balance - @moneyAmount
WHERE Id = @accountId
COMMIT

EXEC usp_WithdrawMoney 1, 247.00

SELECT * 
	FROM Accounts
	WHERE Id = 1