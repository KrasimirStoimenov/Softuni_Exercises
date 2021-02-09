--7. Students to Go

SELECT CONCAT(FirstName,' ',LastName) AS [Full Name]
	FROM Students s
	LEFT JOIN StudentsExams se ON se.StudentId = s.Id
WHERE se.ExamId IS NULL
ORDER BY [Full Name]