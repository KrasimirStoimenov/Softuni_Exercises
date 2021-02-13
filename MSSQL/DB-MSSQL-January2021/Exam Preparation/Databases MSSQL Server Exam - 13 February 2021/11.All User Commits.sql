--11.	All User Commits

CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
		DECLARE @commitsCount INT =(
										SELECT COUNT(*) FROM Users u
										JOIN Commits c ON c.ContributorId = u.Id
										WHERE u.Username = @username
									)
	RETURN @commitsCount;
END

