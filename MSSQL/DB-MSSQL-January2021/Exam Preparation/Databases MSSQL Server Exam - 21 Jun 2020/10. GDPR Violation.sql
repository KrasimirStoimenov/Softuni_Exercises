--10. GDPR Violation

SELECT		t.Id,
			CONCAT(a.FirstName,' ',IIF(a.MiddleName IS NULL,'',a.MiddleName + ' '),a.LastName) AS [Full Name],
			ca.[Name] AS [From],
			ch.[Name] AS [To],
		CASE 
			WHEN t.CancelDate IS NULL THEN CAST(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate) AS VARCHAR(MAX)) + ' days'
			ELSE 'Canceled'
		END AS Duration
	FROM AccountsTrips [at]
	JOIN Accounts a ON [at].AccountId = a.Id
	JOIN Cities ca ON a.CityId = ca.Id
	JOIN Trips t ON [at].TripId = t.Id
	JOIN Rooms r ON t.RoomId = r.Id
	JOIN Hotels h ON r.HotelId = h.Id
	JOIN Cities ch ON h.CityId = ch.Id
ORDER BY [Full Name],t.Id