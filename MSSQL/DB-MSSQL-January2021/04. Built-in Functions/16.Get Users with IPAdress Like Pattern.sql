--Problem 16.Get Users with IPAdress Like Pattern

SELECT Username,IpAddress FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username