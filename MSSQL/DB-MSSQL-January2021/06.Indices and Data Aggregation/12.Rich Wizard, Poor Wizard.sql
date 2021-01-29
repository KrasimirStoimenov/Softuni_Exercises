--12. * Rich Wizard, Poor Wizard

SELECT SUM([Difference])
FROM (
		SELECT wd.DepositAmount-wd2.DepositAmount AS [Difference]
		FROM WizzardDeposits wd
		JOIN WizzardDeposits wd2 ON wd.Id+1 = wd2.Id
	) AS FindingDifference

