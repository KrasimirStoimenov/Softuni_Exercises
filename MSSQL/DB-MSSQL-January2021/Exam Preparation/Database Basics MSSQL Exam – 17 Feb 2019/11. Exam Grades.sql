--11. Exam Grades

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3,2))
RETURNS VARCHAR(MAX)
AS
BEGIN
	IF(@studentId NOT IN (SELECT Id FROM Students))
			RETURN 'The student with provided id does not exist in the school!';
	ELSE IF(@grade>6.00)
			RETURN 'Grade cannot be above 6.00!';

		
			DECLARE @studentFirstName NVARCHAR(30) = (SELECT FirstName FROM Students WHERE Id = @studentId)
			DECLARE @maxAllowableGrade DECIMAL(3,2) = @grade + 0.50;
			DECLARE @gradesCount INT =(SELECT COUNT(*) FROM Students s 
											JOIN StudentsExams se ON se.StudentId = s.Id
											WHERE Id =@studentId AND (se.Grade BETWEEN @grade AND @maxAllowableGrade))
		RETURN CONCAT('You have to update ',@gradesCount ,' grades for the student ' , @studentFirstName);
		
END

GO

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)

GO
				
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)

GO

SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)

