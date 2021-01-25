--13. Count Mountain Ranges

SELECT mc.CountryCode,COUNT(mc.CountryCode) AS  MountainRanges
FROM Mountains AS m
JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
GROUP BY CountryCode
HAVING mc.CountryCode IN('US','BG','RU')
