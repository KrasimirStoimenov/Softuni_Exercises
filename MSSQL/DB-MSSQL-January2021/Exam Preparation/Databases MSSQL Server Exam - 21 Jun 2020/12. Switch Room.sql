--12. Switch Room

CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @TargetRoomHotelId INT= (SELECT h.Id FROM Hotels h JOIN Rooms r ON r.HotelId = h.Id WHERE r.Id = @TargetRoomId);
	DECLARE @BedsInTheTargetRoom INT =(SELECT Beds FROM Rooms WHERE Id = @TargetRoomId);
	DECLARE @PeopleForTheTrip INT = (SELECT COUNT(*) AS [Count] FROM AccountsTrips WHERE TripId = @TripId);
	DECLARE @TripHotelId INT = (SELECT h.Id FROM Trips t
									JOIN Rooms r ON t.RoomId = r.Id
									JOIN Hotels h ON r.HotelId = h.Id
								WHERE t.Id = @TripId);

		IF(@TargetRoomHotelId != @TripHotelId)
			THROW 50001,'Target room is in another hotel!',1

		IF(@PeopleInTheTrip > @BedsInTheTargetRoom)
			THROW 50002,'Not enough beds in target room!',1

		UPDATE Trips
		SET RoomId = @TargetRoomId
		WHERE Id = @TripId
GO

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10

EXEC usp_SwitchRoom 10, 7

EXEC usp_SwitchRoom 10, 8
