--10.Select Second Oldest Important Colonist

SELECT * FROM (
				SELECT  JobDuringJourney, 
						CONCAT(c.FirstName,' ',c.LastName) AS [Full Name],
						DENSE_RANK() OVER (PARTITION BY JobDuringJourney ORDER BY BirthDate) AS [Rank]
				FROM Colonists c
				JOIN TravelCards tc ON tc.ColonistId = c.Id
			  ) AS Ranked
WHERE [Rank] = 2