----- Problem 7.Create Table People
CREATE TABLE People
(	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL (5,2),
	[Weight] DECIMAL (5,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name],Picture,Height,[Weight],Gender,Birthdate,Biography)
VALUES 
	('Test',NULL,1.85,92,'M','1999-05-05',NULL),	
	('Test1',NULL,1.50,68,'F','2000-09-11','Some text'),	
	('Test2',NULL,1.66,78,'M','2002-12-18','Text'),	
	('Test3',NULL,1.78,66,'M','1990-10-06',NULL),	
	('Test4',NULL,1.20,50,'F','1999-02-20','Some Interesting Text')	
