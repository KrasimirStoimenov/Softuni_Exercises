--6.Employees by Salary Level

CREATE PROCEDURE usp_EmployeesBySalaryLevel (@salaryLevel VARCHAR(50))
AS
BEGIN
	SELECT FirstName,LastName 
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
END
-----------------------------------
EXEC dbo.usp_EmployeesBySalaryLevel 'High'