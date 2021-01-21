--Problem 7.Find Towns Not Starting With

SELECT * FROM Towns
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name]