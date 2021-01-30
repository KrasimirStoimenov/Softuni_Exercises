--1.Employees with Salary Above 35000

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
BEGIN
	SELECT FirstName,LastName 
	FROM Employees
	WHERE Salary > 35000
END
--------------------------------------------
EXECUTE dbo.usp_GetEmployeesSalaryAbove35000