--11.Get Colonists Count

CREATE FUNCTION udf_GetColonistsCount(@planetName VARCHAR (30))
RETURNS INT
AS
BEGIN
		RETURN (SELECT COUNT(tc.ColonistId) AS [Count] 
						FROM Planets p 
						JOIN Spaceports sp ON sp.PlanetId = p.Id
						JOIN Journeys j ON j.DestinationSpaceportId = sp.Id
						JOIN TravelCards tc ON tc.JourneyId = j.Id	
						JOIN Colonists c ON tc.ColonistId = c.Id
						WHERE p.[Name] = @planetName)		
END

GO

SELECT dbo.udf_GetColonistsCount('Otroyphus')