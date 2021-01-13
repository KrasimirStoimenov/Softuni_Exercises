----- Problem 15.Hotel Database
CREATE DATABASE Hotel

USE Hotel

--Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Title VARCHAR(30),
	Notes VARCHAR(MAX)
)

INSERT INTO Employees
VALUES
		('Test1','Testov1',NULL,NULL),
		('Test2','Testov2',NULL,NULL),
		('Test3','Testov3',NULL,NULL)

--Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	EmergencyName VARCHAR(30) NOT NULL,
	EmergencyNumber CHAR(10) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers
VALUES
		(111,'TestCustomer1','TestCustomer2','8888888888','EmergencyName1','8888888889',NULL),
		(112,'TestCustomer3','TestCustomer4','8888888810','EmergencyName1','8888888811',NULL),
		(113,'TestCustomer5','TestCustomer6','8888881515','EmergencyName1','8888881820',NULL)


--RoomStatus (RoomStatus, Notes)
CREATE TABLE RoomStatus
(
	RoomStatus BIT,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomStatus
VALUES 
		(0,'SomeNote'),
		(1,'Notes'),
		(1,NULL)

--RoomTypes (RoomType, Notes)
CREATE TABLE RoomTypes
(
	RoomType VARCHAR(10),
	Notes VARCHAR(MAX)
)

INSERT INTO RoomTypes
VALUES
		('Double Bed',NULL),
		('Single Bed',NULL),
		('Double Bed','Note')

--BedTypes (BedType, Notes)
CREATE TABLE BedTypes
(
	BedType VARCHAR(20),
	Notes VARCHAR(MAX)
)

INSERT INTO BedTypes
VALUES
		('Something',NULL),
		('Other','Note'),
		('Something',NULL)

--Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(10),
	BedType VARCHAR(20),
	Rate DECIMAL (4,2),
	RoomStatus VARCHAR(20),
	Notes VARCHAR(MAX)
)

INSERT INTO Rooms
VALUES
		(101,'RoomType1','Double Bed',9.58,'Free',NULL),
		(102,'RoomType2','Single Bed',7,'Available','SomeNotes'),
		(103,'RoomType3','Single Bed',8.88,'Taken','Taken')

--Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATETIME,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME,
	LastDateOccupied DATETIME,
	TotalDays TINYINT NOT NULL,
	AmountCharged DECIMAL (15,2) NOT NULL,
	TaxRate INT,
	TaxAmount INT NOT NULL,
	PaymentTotal DECIMAL (15,2) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Payments
VALUES
		(1,'2020-12-01',155,NULL,NULL,15,17.88,NULL,11.28,29.88,'Note'),
		(1,'2018-10-05',167,NULL,NULL,10,48.26,NULL,12,66.89,'Something'),
		(1,'2019-01-01',158,NULL,NULL,16,647.15,NULL,8.88,1088.88,'Note')

--Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
CREATE TABLE Occupancies
(
		Id INT PRIMARY KEY IDENTITY,
		EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
		DateOccupied DATETIME,
		AccountNumber INT NOT NULL,
		RoomNumber INT NOT NULL,
		RateApplied INT,
		PhoneCharge DECIMAL (10,2),
		Notes VARCHAR(MAX)
)

INSERT INTO Occupancies
VALUES
		(1,'2020-05-18',168,120,NULL,15.66,NULL),
		(3,'2016-06-29',125,110,NULL,78.23,NULL),
		(2,'2021-01-01',188,136,NULL,115.62,NULL)