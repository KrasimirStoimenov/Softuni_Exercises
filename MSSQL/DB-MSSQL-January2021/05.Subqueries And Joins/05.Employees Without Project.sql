--5.Employees Without Project

SELECT TOP(3) e.EmployeeID,e.FirstName 
FROM Employees AS e
LEFT OUTER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
LEFT OUTER JOIN Projects AS p ON ep.ProjectID=p.ProjectID
WHERE p.ProjectID IS NULL
ORDER BY e.EmployeeID