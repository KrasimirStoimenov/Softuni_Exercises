CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName VARCHAR(50) NOT NULL,
	Notes VARCHAR(500)
)

INSERT INTO Directors(DirectorName,Notes)
	VALUES 
		('TEST','SomeNotes'),
		('TEST1','Note'),
		('TEST2',NULL),
		('TEST3','NoNote'),
		('TEST4','AnotherSomeUsefullNote')


CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(50) NOT NULL,
	Notes VARCHAR(500)
)

INSERT INTO Genres(GenreName,Notes)
	VALUES 
		('GenreTest',NULL),
		('GenreTest1','Note'),
		('GenreTest2',NULL),
		('GenreTest3','NoNote'),
		('GenreTest4',NULL)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	Notes VARCHAR(500)
)

INSERT INTO Categories(CategoryName,Notes)
	VALUES 
		('GeneralCategory',NULL),
		('Action','Note'),
		('Romance','RomanceMovies'),
		('Fantasy','SomeFantasyMovies'),
		('ScaryMovies','ScaryMovies')


CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear DATE NOT NULL,
	[Length] TIME,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating DECIMAL(18,2),
	Notes VARCHAR(500)
)

INSERT INTO Movies(Title,DirectorId,CopyrightYear,GenreId,CategoryId,Rating)
	VALUES
		('Movie',1,('1990-06-15'),1,3,6.78),
		('Movie1',2,('2000-05-05'),3,4,7),
		('Movie2',2,('2010-12-18'),5,2,9),
		('Movie3',4,('2018-07-29'),5,1,9.8),
		('Movie4',5,('2020-09-27'),2,5,4.3)