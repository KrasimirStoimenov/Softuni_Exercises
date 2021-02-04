--12.Change Journey Purpose

CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
BEGIN
	IF(@JourneyId > (SELECT COUNT(*) FROM Journeys))
		THROW 50001, 'The journey does not exist!', 1

	ELSE IF (@NewPurpose = (SELECT Purpose FROM Journeys
							WHERE Id = @JourneyId))
		THROW 50002,'You cannot change the purpose!',1

	UPDATE Journeys
	SET Purpose = @NewPurpose
	WHERE Id = @JourneyId
END

GO

EXEC usp_ChangeJourneyPurpose 4, 'Technical'	
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'

