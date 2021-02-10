--7. Longest and Shortest Trips

SELECT a.Id,
	   CONCAT(a.FirstName,' ',a.LastName) AS [Full Name],
	   MAX(DATEDIFF(DAY,ArrivalDate,ReturnDate)) AS LongestTrip,
	   MIN(DATEDIFF(DAY,ArrivalDate,ReturnDate)) AS ShortestTrip
	FROM AccountsTrips [at]
	JOIN Accounts a ON [at].AccountId = a.Id
	JOIN Trips t ON [at].TripId = t.Id
WHERE a.MiddleName IS NULL AND CancelDate IS NULL
GROUP BY a.Id,a.FirstName,a.LastName
ORDER BY LongestTrip DESC,ShortestTrip