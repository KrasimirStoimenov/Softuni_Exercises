--9. Romantic Getaways

SELECT a.Id,a.Email,c.[Name],COUNT(*) AS Trips 
	FROM AccountsTrips [at]
	JOIN Accounts a ON [at].AccountId = a.Id
	JOIN Trips t ON [at].TripId = t.Id
	JOIN Rooms r ON t.RoomId = r.Id
	JOIN Hotels h ON r.HotelId = h.Id
	JOIN Cities c ON h.CityId = c.Id
WHERE a.CityId = h.CityId
GROUP BY a.Id,a.Email,c.[Name]
ORDER BY Trips DESC,a.Id
