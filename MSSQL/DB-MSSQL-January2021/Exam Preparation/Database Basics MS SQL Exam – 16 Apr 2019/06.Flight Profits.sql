--6.	Flight Profits

SELECT f.Id,SUM(Price) AS Price
	FROM Flights f
	JOIN Tickets t ON t.FlightId = f.Id
GROUP BY f.Id
ORDER BY Price DESC,f.Id