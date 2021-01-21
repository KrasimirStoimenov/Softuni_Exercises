--Problem 3.Find First Names of All Employees

SELECT FirstName FROM Employees
WHERE (DepartmentID = 3 OR DepartmentID = 10) AND HireDate BETWEEN '1995' AND '2006'