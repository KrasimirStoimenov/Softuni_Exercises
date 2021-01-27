--15. *Continents and Currencies


SELECT ContinentCode,CurrencyCode,[Count] AS CurrencyUsage
	FROM(
			SELECT 
				ContinentCode,
				CurrencyCode,
				COUNT(CurrencyCode) AS [Count],
				DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS [Rank]
			FROM Countries
			GROUP BY ContinentCode,CurrencyCode
		) 
		 AS [ContinentsCurrencyCount]	
WHERE [Rank] = 1 AND [Count] >1
ORDER BY ContinentCode
