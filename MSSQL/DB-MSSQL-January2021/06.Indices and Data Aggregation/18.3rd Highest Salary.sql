--18. *3rd Highest Salary

SELECT DISTINCT DepartmentID,Salary AS ThirdHighestSalary 
FROM(
		SELECT FirstName,DepartmentID,Salary,DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
		FROM Employees
	) AS Ranked
WHERE [Rank] = 3