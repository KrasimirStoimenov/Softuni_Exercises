USE Minions

CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture IMAGE,
	Height DECIMAL(18,2),
	[Weight] DECIMAL(18,2),
	Gender CHAR(2) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(max)
)

INSERT INTO People([Name],Picture,Height,[Weight],Gender,Birthdate,Biography)
	VALUES
		('Test1',NULL,1.60,30,'m',('2000-07-11'),NULL),
		('Test2',NULL,1.85,27.5,'f',('1999-06-18'),'Something'),
		('Test3',NULL,1.75,47.5,'m',('1869-11-05'),NULL),
		('Test4',NULL,1.89,54.544,'f',('1990-02-24'),'TEST'),
		('Test5',NULL,NULL,NULL,'m',('1989-12-23'),NULL);

