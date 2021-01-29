--7. Deposits Filter

SELECT * 
FROM(
		SELECT DepositGroup,SUM(DepositAmount) AS TotalSum
		FROM WizzardDeposits
		GROUP BY DepositGroup,MagicWandCreator
		HAVING MagicWandCreator = 'Ollivander family'
	) AS TotalSumFound
WHERE TotalSum<150000
ORDER BY TotalSum DESC