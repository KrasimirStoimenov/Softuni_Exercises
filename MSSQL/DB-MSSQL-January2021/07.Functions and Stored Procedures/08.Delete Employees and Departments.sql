--8.* Delete Employees and Departments

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
BEGIN
	--Detach Employees FROM EmployeesProjects table
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
							SELECT EmployeeID FROM Employees
							WHERE DepartmentID = @departmentId
					    )
	-- Set managerId's from department to NULL
	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
							SELECT EmployeeID FROM Employees
							WHERE DepartmentID = @departmentId
					   )
	-- Alter ManagerId column in departments table to be NULLABLE
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL
	-- Set Null values to managers in selected department
	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (
							SELECT EmployeeID FROM Employees
							WHERE DepartmentID = @departmentId
					   )
	-- Delete employees from department
	DELETE FROM Employees
	WHERE DepartmentID = @departmentId
	-- Delete department
	DELETE FROM Departments
	WHERE DepartmentID = @departmentId
	--Count should be 0
	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId
END
-----------------------------------------------
EXEC dbo.usp_DeleteEmployeesFromDepartment 2