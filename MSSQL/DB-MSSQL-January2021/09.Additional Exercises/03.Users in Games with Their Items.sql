--Problem 3.Users in Games with Their Items

SELECT  u.Username,
		g.[Name] AS Game,
		COUNT(*) AS Items,
		SUM(i.Price) AS Price
	FROM Games AS g
	JOIN UsersGames AS ug 
		ON ug.GameId = g.Id
	JOIN Users AS u
		ON ug.UserId = u.Id
	JOIN UserGameItems AS ugi
		ON ugi.UserGameId = ug.Id
	JOIN Items AS i
		ON ugi.ItemId = i.Id
GROUP BY u.Username,g.[Name]
HAVING COUNT(*) >= 10
ORDER BY Items DESC,Price DESC,Username