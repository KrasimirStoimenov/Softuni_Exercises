-----Problem 16.Create SoftUni Database
CREATE DATABASE SoftUni

USE SoftUni

--Towns (Id, Name)
CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

--Addresses (Id, AddressText, TownId)
CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(50),
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

--Departments (Id, Name)
CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

--Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(50),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATETIME NOT NULL,
	Salary DECIMAL(18,2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)