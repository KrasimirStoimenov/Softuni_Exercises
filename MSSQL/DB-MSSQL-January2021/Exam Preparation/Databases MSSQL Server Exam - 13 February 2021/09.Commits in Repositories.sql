--9.	Commits in Repositories

SELECT TOP(5) r.Id,r.Name,COUNT(*) AS Commits
	FROM RepositoriesContributors rc
	JOIN Repositories r ON rc.RepositoryId = r.Id
	JOIN Commits c ON c.RepositoryId = r.Id
GROUP BY r.Id,r.[Name]
ORDER BY Commits DESC ,r.Id,r.[Name]