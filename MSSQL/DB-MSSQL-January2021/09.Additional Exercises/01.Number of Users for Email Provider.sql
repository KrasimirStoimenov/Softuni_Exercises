--Problem 1.Number of Users for Email Provider

SELECT e.[Email Provider],Count(*) AS [Number Of Users]
FROM(
			SELECT SUBSTRING(Email,(CHARINDEX('@',Email) + 1),LEN(Email)) AS [Email Provider]
			FROM Users
	) AS e

GROUP BY e.[Email Provider]
ORDER BY [Number Of Users] DESC,e.[Email Provider]