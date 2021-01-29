--15. Employees Average Salaries

SELECT * INTO temp FROM Employees
WHERE Salary > 30000

DELETE FROM temp
WHERE ManagerID = 42

UPDATE temp
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) FROM temp
GROUP BY DepartmentID