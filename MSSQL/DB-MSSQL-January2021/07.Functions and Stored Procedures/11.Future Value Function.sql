--11.Future Value Function

CREATE FUNCTION ufn_CalculateFutureValue (@initialSum DECIMAL(18,2), 
										  @interestRate FLOAT, 
										  @years int)
RETURNS DECIMAL (18,4)
AS
BEGIN
		DECLARE @futureValue DECIMAL (18,4);
		SET @futureValue = @initialSum * (POWER((1 + @interestRate), @years))

	RETURN @futureValue;
END