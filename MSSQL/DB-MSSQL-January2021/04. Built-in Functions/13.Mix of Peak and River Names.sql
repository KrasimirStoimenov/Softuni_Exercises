--Problem 13.Mix of Peak and River Names

SELECT p.PeakName,r.RiverName,LOWER(CONCAT(p.PeakName,RIGHT(r.RiverName,LEN(r.RiverName)-1))) AS Mix
FROM Peaks p
JOIN Rivers r ON RIGHT(p.PeakName,1)=LEFT(r.RiverName,1)
ORDER BY Mix
