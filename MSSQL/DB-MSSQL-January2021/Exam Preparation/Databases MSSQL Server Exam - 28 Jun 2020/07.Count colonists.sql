--7.Count colonists

SELECT COUNT(*) AS count
FROM Colonists c
JOIN TravelCards tc ON tc.ColonistId = c.Id
JOIN Journeys j ON j.Id = tc.JourneyId
GROUP BY j.Purpose
HAVING j.Purpose = 'Technical'