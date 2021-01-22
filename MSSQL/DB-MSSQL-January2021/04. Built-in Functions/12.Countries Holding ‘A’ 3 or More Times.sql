--Problem 12.Countries Holding ‘A’ 3 or More Times

SELECT CountryName,IsoCode FROM Countries
WHERE LEN(CountryName)-LEN(REPLACE(CountryName,'A','')) >=3
ORDER BY IsoCode