--9.Select all planets and their journey count

SELECT p.[Name],COUNT(*) AS JourneyCount 
	FROM Planets p 
	JOIN Spaceports sp ON sp.PlanetId = p.Id
	JOIN Journeys j ON j.DestinationSpaceportId = sp.Id
GROUP BY p.[Name]
ORDER BY JourneyCount DESC,p.[Name]