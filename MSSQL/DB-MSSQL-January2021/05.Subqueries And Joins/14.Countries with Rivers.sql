--14. Countries with Rivers

SELECT TOP(5) c.CountryName,r.RiverName 
FROM Countries AS c
LEFT OUTER JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT OUTER JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE ContinentCode = 'AF'
ORDER BY CountryName