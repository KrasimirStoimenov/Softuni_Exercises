--4. * Smallest Deposit Group Per Magic Wand Size

SELECT TOP(2) DepositGroup
FROM(
	  SELECT DepositGroup,AVG(MagicWandSize) AS WandSize 
	  FROM WizzardDeposits
	  GROUP BY DepositGroup
	) AS AveragedWandSize
ORDER BY WandSize