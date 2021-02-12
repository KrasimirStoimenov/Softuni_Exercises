--7.	Passenger Trips

SELECT CONCAT(FirstName,' ',LastName) AS [Full Name],
	   f.Origin,
	   f.Destination
	FROM Passengers p
	JOIN Tickets t ON  t.PassengerId = p.Id
	JOIN Flights f ON t.FlightId = f.Id
ORDER BY [Full Name],f.Origin,f.Destination