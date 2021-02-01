--10.People with Balance Higher Than

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@money DECIMAL(18,2))
AS
BEGIN
		SELECT ah.FirstName AS [First Name] ,
			   ah.LastName AS [Last Name]
		FROM AccountHolders ah
		JOIN Accounts a ON a.AccountHolderId = ah.Id
		GROUP BY ah.FirstName,ah.LastName,a.AccountHolderId
		HAVING SUM(a.Balance) > @money
		ORDER BY ah.FirstName,ah.LastName
END