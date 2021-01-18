--Problem 1.One-To-One Relationship
CREATE DATABASE TableRelationsExercise

USE TableRelationsExercise


CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY,
	PassportNumber VARCHAR(30) NOT NULL
)

INSERT INTO Passports
VALUES
		(101,'N34FG21B'),
		(102,'K65LO4R7'),
		(103,'ZE657QP2')

CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	Salary DECIMAL (18,2) NOT NULL,
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID)
)


INSERT INTO Persons
VALUES
		('Roberto',43300.00,102),
		('Tom',56100.00,103),
		('Yana',60200.00,101)
