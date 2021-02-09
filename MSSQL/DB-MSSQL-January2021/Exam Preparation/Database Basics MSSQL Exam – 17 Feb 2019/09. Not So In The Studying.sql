--9. Not So In The Studying

SELECT CONCAT(FirstName,' ',IIF(MiddleName IS NOT NULL,MiddleName + ' ',''),LastName) AS [Full Name]
	FROM Students s 
	LEFT JOIN StudentsSubjects ss ON ss.StudentId = s.Id
WHERE ss.SubjectId IS NULL
ORDER BY [Full Name]