--Problem 6
--6.1
CREATE TRIGGER tr_RestrictItems ON UserGameItems INSTEAD OF INSERT
AS
DECLARE @ItemId INT = (SELECT ItemId FROM inserted)
DECLARE @userGameId INT = (SELECT UserGameId FROM inserted)

DECLARE @itemLevel INT = (SELECT MinLevel FROM Items WHERE Id = @ItemId)
DECLARE @userGameLevel INT = (SELECT [Level] FROM UsersGames WHERE Id = @userGameId)

IF(@userGameLevel >= @itemLevel)
BEGIN
	INSERT INTO UserGameItems (ItemId, UserGameId) VALUES (@ItemId, @userGameId)
END

--6.2
UPDATE UsersGames
SET Cash = Cash + 50000
WHERE GameId = (SELECT Id FROM Games WHERE [Name] = 'Bali') AND UserId IN (SELECT Id FROM Users WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos'))

SELECT *
	FROM Users AS u
	JOIN UsersGames AS ug ON ug.UserId = u.Id
	JOIN Games AS g ON g.Id = ug.GameId
	WHERE g.[Name] = 'Bali' AND u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')

--6.3
DECLARE @itemIdd INT = 251

WHILE(@itemIdd <= 299)
BEGIN
	EXEC usp_BuyItem 22, @itemIdd, 212
	EXEC usp_BuyItem 37, @itemIdd, 212
	EXEC usp_BuyItem 52, @itemIdd, 212
	EXEC usp_BuyItem 61, @itemIdd, 212

	SET @itemIdd = @itemIdd + 1
END

SELECT *
	FROM UsersGames
	WHERE GameId = 212

DECLARE @counter INT = 501

WHILE(@counter <= 539)
BEGIN
	EXEC usp_BuyItem 22, @itemIdd, 212
	EXEC usp_BuyItem 37, @itemIdd, 212
	EXEC usp_BuyItem 52, @itemIdd, 212
	EXEC usp_BuyItem 61, @itemIdd, 212

	SET @counter = @counter + 1
END

GO
CREATE PROCEDURE usp_BuyItem @userId INT, @itemId INT, @gameId INT
AS
BEGIN TRANSACTION
DECLARE @user INT = (SELECT Id FROM Users WHERE Id = @userId)
DECLARE @item INT = (SELECT Id FROM Items WHERE Id = @itemId)

IF(@user IS NULL OR @item IS NULL)
BEGIN
	ROLLBACK
	RAISERROR('Invalid user of item id', 16, 1)
	RETURN
END

DECLARE @userCash DECIMAL(15, 2) = (SELECT Cash FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)
DECLARE @itemPrice Decimal(15, 2) = (SELECT Price FROM Items WHERE Id = @itemId)

IF(@userCash - @itemPrice < 0)
BEGIN
	ROLLBACK
	RAISERROR('Not enough money!', 16, 2)
	RETURN
END

UPDATE UsersGames
SET Cash = Cash - @itemPrice
WHERE UserId = @userId AND GameId = @gameId

DECLARE @userGameId DECIMAL(15, 2) = (SELECT Id FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)

INSERT INTO UserGameItems (ItemId, UserGameId) VALUES (@itemId, @userGameId)
COMMIT

--6.4
SELECT u.Username, g.[Name], i.[Name]
	FROM Users AS u
	JOIN UsersGames AS ug ON ug.UserId = u.Id
	JOIN Games AS g ON g.Id = ug.GameId
	JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	JOIN Items AS i ON i.Id = ugi.ItemId
	WHERE g.[Name] = 'Bali'
	ORDER BY u.Username, i.[Name]