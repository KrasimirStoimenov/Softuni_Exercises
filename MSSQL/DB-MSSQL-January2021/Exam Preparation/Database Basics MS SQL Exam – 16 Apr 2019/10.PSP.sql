--10.	PSP

SELECT	pl.[Name],
		pl.Seats,
		COUNT(t.Id) AS [Passenger Count]
	FROM Planes pl
	LEFT JOIN Flights f ON f.PlaneId = pl.Id
	LEFT JOIN Tickets t ON t.FlightId = f.Id
	LEFT JOIN Passengers p ON t.PassengerId = p.Id
GROUP BY pl.[Name],pl.Seats
ORDER BY [Passenger Count] DESC, pl.[Name], pl.Seats
