--10. Average Grade per Subject

SELECT s.[Name], AVG(ss.Grade) AS AverageGrade
	FROM StudentsSubjects ss
	JOIN Subjects s ON ss.SubjectId = s.Id
GROUP BY s.Id, s.[Name]
ORDER BY s.Id