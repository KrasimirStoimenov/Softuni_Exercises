--18. Highest Peak Name and Elevation by Country

SELECT TOP(5)
	CountryName AS Country,
	ISNULL(PeakName,'(no highest peak)') AS [Highest Peak Name],
	ISNULL(Elevation,0) AS [Highest Peak Elevation],
	ISNULL(MountainRange,'(no mountain)') AS Mountain
FROM (
	  SELECT c.CountryName,p.PeakName,p.Elevation,m.MountainRange,DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY Elevation DESC) AS [Rank]
	  FROM Countries c
	  LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	  LEFT JOIN Mountains m ON m.Id = mc.MountainId
	  LEFT JOIN Peaks p ON p.MountainId = m.Id 
	 ) AS Ranked
WHERE [Rank] = 1
ORDER BY CountryName,[Highest Peak Name]