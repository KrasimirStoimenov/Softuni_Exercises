--7.*Massive Shopping

DECLARE @userId INT = (SELECT Id FROM Users WHERE Username = 'Stamat');
DECLARE @gameId INT = (SELECT Id FROM Games WHERE [Name] = 'Safflower');
DECLARE @userMoney DECIMAL(18,2) = (SELECT Cash FROM UsersGames WHERE UserId = @userId AND GameId = @gameId);
DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)
DECLARE @itemsPrice DECIMAL(18,2);

BEGIN TRANSACTION
	SET @itemsPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12)

	IF(@userMoney - @itemsPrice < 0)
		ROLLBACK

	INSERT INTO UserGameItems
		SELECT Id, @UserGameID FROM Items
		WHERE Id IN (SELECT Id FROM Items WHERE MinLevel BETWEEN 11 AND 12)

	UPDATE UsersGames
	SET Cash -=@itemsPrice
	WHERE UserId = @userId AND GameId = @gameId

COMMIT

	SET @userMoney = (SELECT Cash FROM UsersGames);

BEGIN TRANSACTION
	SET @itemsPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)

	IF(@userMoney - @itemsPrice < 0)
		ROLLBACK

	INSERT INTO UserGameItems
		SELECT Id, @UserGameID FROM Items
		WHERE Id IN (SELECT Id FROM Items WHERE MinLevel BETWEEN 11 AND 12)

	UPDATE UsersGames
	SET Cash -=@itemsPrice
	WHERE UserId = @userId AND GameId = @gameId

COMMIT

SELECT Name AS [Item Name]
FROM Items
WHERE Id IN (SELECT ItemId FROM UserGameItems WHERE UserGameId = @userGameID)
ORDER BY [Item Name]