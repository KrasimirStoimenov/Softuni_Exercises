--Problem 2.One-To-Many Relationship

CREATE TABLE Manufacturers
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	EstablishedOn DATE NOT NULL
)

INSERT INTO Manufacturers
VALUES 
		('BMW','07/03/1916'),
		('Tesla','01/01/2003'),
		('Lada','01/05/1966')


CREATE TABLE Models
(
	Id INT PRIMARY KEY IDENTITY (101,1),
	[Name] VARCHAR(30) NOT NULL,
	ManufacturerId INT FOREIGN KEY REFERENCES Manufacturers(Id)
)

INSERT INTO Models
VALUES
		('X1',1),
		('i6',1),
		('Model S',2),
		('Model X',2),
		('Model 3',2),
		('Nova',3)
