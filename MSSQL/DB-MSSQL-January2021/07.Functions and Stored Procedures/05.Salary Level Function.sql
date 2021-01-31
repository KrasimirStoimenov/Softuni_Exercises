--5.Salary Level Function

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(50)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(50);
	IF(@salary<30000)
		SET @salaryLevel = 'Low';
	ELSE IF (@salary <=50000)
		SET @salaryLevel = 'Average';
	ELSE
		SET @salaryLevel = 'High';
	RETURN @salaryLevel;
END
------------------------------------------------------------------
SELECT Salary,dbo.ufn_GetSalaryLevel(Salary)
FROM Employees