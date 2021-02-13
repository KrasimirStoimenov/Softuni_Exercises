--8.	Single Files

SELECT pf.Id,pf.[Name],CONCAT(pf.Size,'KB') AS Size
	FROM Files pf
	LEFT JOIN Files f ON pf.Id = f.ParentId
WHERE f.Id IS NULL
ORDER BY pf.Id,pf.[Name],Size