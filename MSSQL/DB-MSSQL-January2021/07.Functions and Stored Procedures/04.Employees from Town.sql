--4.Employees from Town

CREATE PROCEDURE usp_GetEmployeesFromTown (@townName VARCHAR(50))
AS 
BEGIN
		SELECT e.FirstName,e.LastName 
		FROM Employees e
		JOIN Addresses a ON e.AddressID = a.AddressID
		JOIN Towns t ON a.TownID = t.TownID
		WHERE t.[Name] = @townName
END
---------------------------------------------------
EXEC dbo.usp_GetEmployeesFromTown 'Sofia'