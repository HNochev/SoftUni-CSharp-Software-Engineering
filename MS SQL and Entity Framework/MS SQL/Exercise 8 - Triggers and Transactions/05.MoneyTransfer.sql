--Problem 5
CREATE PROCEDURE usp_TransferMoney(@senderId INT, @recieverId INT, @amount DECIMAL(15, 4))
AS
BEGIN TRANSACTION
EXEC usp_WithdrawMoney @senderId, @amount
EXEC usp_DepositMoney @recieverId, @amount
COMMIT

EXEC usp_TransferMoney 1, 2, 100

SELECT *
	FROM Accounts
	WHERE Id = 1 OR Id = 2