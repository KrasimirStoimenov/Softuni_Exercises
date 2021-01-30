--3.Town Names Starting With

CREATE PROCEDURE usp_GetTownsStartingWith (@startLetters VARCHAR(20))
AS
BEGIN
		SELECT [Name] 
		FROM Towns
		WHERE LEFT([Name],LEN(@startLetters)) = @startLetters
END
---------------------------------------------
EXEC dbo.usp_GetTownsStartingWith 'b'