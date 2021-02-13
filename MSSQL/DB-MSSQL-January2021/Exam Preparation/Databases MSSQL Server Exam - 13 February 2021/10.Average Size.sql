--10.	Average Size

SELECT u.Username,AVG(f.Size) AS Size
	FROM Commits c 
	JOIN Users u ON c.ContributorId = u.Id
	JOIN Files f ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY AVG(f.Size) DESC,u.Username