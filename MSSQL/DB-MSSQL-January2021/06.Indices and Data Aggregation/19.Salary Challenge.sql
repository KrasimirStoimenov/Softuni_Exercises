--19. **Salary Challenge

SELECT TOP(10) FirstName,LastName,AverageSalary.DepartmentID
FROM Employees e,
	(	SELECT DepartmentID,AVG(Salary) AS Average
		FROM Employees 
		GROUP BY DepartmentID
	) AS AverageSalary
WHERE Salary>Average AND e.DepartmentID = AverageSalary.DepartmentID
ORDER BY DepartmentID
