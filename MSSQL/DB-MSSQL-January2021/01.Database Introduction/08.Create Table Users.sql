----- Problem 8.Create Table Users
CREATE TABLE Users
(	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME2,
	IsDeleted BIT
)

INSERT INTO Users (Username,[Password])
VALUES  ('FirstTest' , 'FirstTestPassword'),
		('SecondTest', 'SomePassword'),
		('ThirdTest', 'pAsSwOrD'),
		('FourthTest', 'something'),
		('FifthTest', 'pass123')