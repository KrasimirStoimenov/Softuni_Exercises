--6. Students Teachers

SELECT  s.FirstName,
		s.LastName,
		COUNT(st.TeacherId) AS TeachersCount
	FROM StudentsTeachers st
	JOIN Students s ON st.StudentId = s.Id
GROUP BY s.FirstName,s.LastName
