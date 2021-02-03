--6.Select all pilots

SELECT	c.Id AS id,
		CONCAT(FirstName,' ',LastName) AS [full_name] 
FROM Colonists c
JOIN TravelCards tc ON tc.ColonistId = c.Id
WHERE JobDuringJourney = 'Pilot'
ORDER BY c.Id