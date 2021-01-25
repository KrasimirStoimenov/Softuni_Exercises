--12. Highest Peaks in Bulgaria

SELECT mc.CountryCode,m.MountainRange,p.PeakName,p.Elevation
FROM Peaks AS p
JOIN Mountains AS m ON p.MountainId = m.Id
JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
WHERE p.Elevation>2835 AND mc.CountryCode = 'BG'
ORDER BY p.Elevation DESC