----- Problem 13.Movies Database
CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors
(	Id INT PRIMARY KEY IDENTITY,
	DirectorName VARCHAR(50) NOT NULL,
	Notes VARCHAR(100)
)

INSERT INTO Directors (DirectorName,Notes)
VALUES 
		('Director1','Some Notes'),
		('Director2',NULL),
		('Director3','note'),
		('Director4','something'),
		('Director5',NULL)
		

CREATE TABLE Genres
(	Id INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(50) NOT NULL,
	Notes VARCHAR (100)
)

INSERT INTO Genres (GenreName,Notes)
VALUES 
		('Genre1','Some Notes'),
		('Genre2',NULL),
		('Genre3',NULL),
		('Genre4','something'),
		('Genre5',NULL)

CREATE TABLE Categories
(	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	Notes VARCHAR(100)
)

INSERT INTO Categories (CategoryName,Notes)
VALUES 
		('Category1','Some Notes'),
		('Category2',NULL),
		('Category3','notes'),
		('Category4','This Category'),
		('Category5',NULL)

CREATE TABLE Movies
(	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear INT,
	[Length] DECIMAL (15,2) NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating DECIMAL (4,2),
	Notes VARCHAR (100)
)

INSERT INTO Movies (Title,DirectorId,CopyrightYear,[Length],GenreId,CategoryId,Rating,Notes)
VALUES 
		('FirstTitle',	5,	2020,	2.35,	3,	1,	7.65,NULL),
		('SecondTitle',	2,	NULL,	3.15,	2,	3,	7.65,'NOTE'),
		('ThirdTitle',	1,	2021,	1.15,	1,	2,	4.85,'Some Bad Movie'),
		('FourthTitle',	4,	2016,	2.00,	5,	5,	9.90,NULL),
		('FifthTitle',	3,	2019,	3.33,	4,	4,	7.00,'Something Written In The Sky')