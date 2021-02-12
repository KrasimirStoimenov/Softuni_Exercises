--11.	Vacation

CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT) 
RETURNS VARCHAR(MAX)
AS
BEGIN 
	DECLARE @flightId INT = (SELECT Id FROM Flights WHERE Origin = @origin AND Destination = @destination);
	DECLARE @totalPrice DECIMAL(18,2);
	DECLARE @output VARCHAR(MAX);

	IF(@peopleCount <=0)
		RETURN 'Invalid people count!'

	ELSE IF(@flightId IS NULL)
		RETURN 'Invalid flight!'

	SET @totalPrice = (SELECT Price FROM Tickets WHERE FlightId = @flightId) * @peopleCount
	SET @output = CONCAT('Total price ', @totalPrice)

	RETURN @output
END

GO 

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)

SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)