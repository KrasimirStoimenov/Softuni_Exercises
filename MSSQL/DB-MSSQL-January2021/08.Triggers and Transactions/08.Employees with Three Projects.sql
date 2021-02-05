--8.Employees with Three Projects

CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT) 
AS
BEGIN TRANSACTION
	IF((SELECT COUNT(*) FROM EmployeesProjects
		WHERE EmployeeID = @emloyeeId) >= 3)
			BEGIN
				ROLLBACK;
				THROW 50001,'The employee has too many projects!',1
			END

	INSERT INTO EmployeesProjects
	VALUES(@emloyeeId,@projectID)
COMMIT
GO

EXEC usp_AssignProject 2,1