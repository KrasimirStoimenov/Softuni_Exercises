--3. Longest Magic Wand Per Deposit Groups

SELECT DepositGroup,MagicWandSize AS LongestMagicWand 
FROM(
		SELECT DepositGroup,MagicWandSize,RANK() OVER (PARTITION BY DepositGroup ORDER BY MagicWandSize DESC) AS [Rank]
		FROM WizzardDeposits
		GROUP BY DepositGroup,MagicWandSize
	)AS Ranked
WHERE [Rank] = 1