USE Minions

CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture IMAGE,
	LastLoginTime DATE,
	IsDeleted BIT
)

INSERT INTO Users(Username,[Password],LastLoginTime,IsDeleted)
	VALUES 
		('TEST','PASSWORD',GETDATE(),0),
		('TEST1','something',GETDATE(),0),
		('TEST2','SOMEPASS',GETDATE(),1),
		('TEST3','123456',GETDATE(),0),
		('TEST4','Pass',GETDATE(),1);