--13.*Scalar Function: Cash in User Games Odd Rows

CREATE FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(50))
RETURNS TABLE
AS
RETURN SELECT(
				SELECT SUM(Cash) AS SumCash
				FROM (
					   SELECT g.[Name],ug.Cash,ROW_NUMBER() OVER (PARTITION BY g.[Name] ORDER BY ug.Cash DESC) AS RowNumber
					   FROM UsersGames ug
					   JOIN Games g ON g.Id = ug.GameId
					   WHERE g.[Name] = @gameName
					 ) AS RowNumbers
				WHERE RowNumber % 2 <> 0
			 ) AS SumCash