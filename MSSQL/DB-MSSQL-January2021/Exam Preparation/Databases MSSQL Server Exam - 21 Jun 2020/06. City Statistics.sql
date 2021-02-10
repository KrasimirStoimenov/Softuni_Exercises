--6. City Statistics

SELECT c.[Name],COUNT(h.Id) AS Hotels
	FROM Hotels h
	JOIN Cities c ON h.CityId = c.Id
GROUP BY c.[Name]
ORDER BY Hotels DESC,c.[Name]
