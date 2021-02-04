--8.Select spaceships with pilots younger than 30 years

SELECT s.[Name], s.Manufacturer
	FROM Spaceships s
	JOIN Journeys j ON s.Id = j.SpaceshipId
	JOIN TravelCards tc ON tc.JourneyId = j.Id
	JOIN Colonists c ON tc.ColonistId = c.Id
WHERE tc.JobDuringJourney = 'Pilot' AND c.BirthDate > '01/01/1989'
ORDER BY s.[Name]