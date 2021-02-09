--8. Top Students

SELECT TOP(10) s.FirstName,s.LastName,FORMAT(AVG(se.Grade),'0.00')  AS Grade
	FROM Students s
	JOIN StudentsExams se ON se.StudentId = s.Id
GROUP BY s.FirstName,s.LastName
ORDER BY Grade DESC,FirstName,LastName