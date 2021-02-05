--9.Delete Employees

CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY, 
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL, 
	MiddleName VARCHAR(50), 
	JobTitle VARCHAR(50), 
	DepartmentId INT FOREIGN KEY REFERENCES Departments(DepartmentID), 
	Salary DECIMAL(18,2)
) 

CREATE TRIGGER tr_DeleteEmployee
ON Employees AFTER DELETE
AS
	INSERT INTO Deleted_Employees (FirstName,LastName,MiddleName,JobTitle,DepartmentID,Salary)
	SELECT d.FirstName,d.LastName,d.MiddleName,d.JobTitle,d.DepartmentID,d.Salary FROM deleted AS d
