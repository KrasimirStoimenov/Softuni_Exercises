--5. EEE-Mails

SELECT FirstName,
	   LastName,
	   FORMAT(BirthDate,'MM-dd-yyyy') AS BirthDate,
	   c.[Name] AS Hometown,
	   a.Email
	FROM Accounts a
	JOIN Cities c ON a.CityId = c.Id
WHERE Email LIKE 'e%'
ORDER BY Hometown