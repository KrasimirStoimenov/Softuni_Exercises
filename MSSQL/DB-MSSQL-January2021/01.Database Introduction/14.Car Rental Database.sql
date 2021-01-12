----- Problem 14.Car Rental Database
CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories
(	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate DECIMAL (4,2),
	WeeklyRate DECIMAL (5,2),
	MonthlyRate DECIMAL (6,2) NOT NULL,
	WeekendRate DECIMAL (4,2)
)

INSERT INTO Categories(CategoryName,DailyRate,WeeklyRate,MonthlyRate,WeekendRate)
VALUES 
		('Category1',5,11.20,19.22,5.45),
		('Category2',2,15,19.52,6),
		('Category3',6.66,12,15,17)

CREATE TABLE Cars
(	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(20) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors INT,
	Picture VARBINARY(MAX),
	Condition VARCHAR(10) NOT NULL,
	Available BIT NOT NULL
)

INSERT INTO Cars(PlateNumber,Manufacturer,Model,CarYear,CategoryId,Doors,Picture,Condition,Available)
VALUES
		('XX1585215','BMW','330D',2008,1,3,NULL,'Used',1),
		('15QW168','AUDI','A4',2002,2,5,NULL,'Used',1),
		('VZX12356','BMW','750',2020,3,5,NULL,'New',1)

CREATE TABLE Employees
(	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Title VARCHAR(20),
	Notes VARCHAR(50)
)

INSERT INTO Employees(FirstName,LastName,Title,Notes)
VALUES 
		('Pravcho','Pravchev','Manager','Somting Usefull'),
		('Xamarin','Xamarinchov','Sales Manager',NULL),
		('Sara','Parker','The Boss','Doesnt need notes')

CREATE TABLE Customers
(	 Id INT PRIMARY KEY IDENTITY,
	 DriverLicenceNumber TINYINT NOT NULL,
	 FullName VARCHAR(30) NOT NULL,
	 [Address] VARCHAR(50),
	 City VARCHAR(30) NOT NULL,
	 ZIPCode INT,
	 Notes VARCHAR(50)
)

INSERT INTO Customers(DriverLicenceNumber,FullName,[Address],City,ZIPCode,Notes)
VALUES
		(1,'Conan The Barbarian','NY 152','New York',3578,NULL),
		(2,'Pesho Peshov',NULL,'London',NULL,NULL),
		(3,'Georgi Goshev','SA 122','Sofia',3705,NULL)


CREATE TABLE RentalOrders
(	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	TankLevel TINYINT ,
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT NOT NULL,
	StartDate DATETIME2,
	EndDate DATETIME2,
	RateApplied INT,
	TaxRate INT,
	OrderStatus VARCHAR(15),
	Notes VARCHAR(50)
)

INSERT INTO RentalOrders(EmployeeId,CustomerId,CarId,TankLevel,KilometrageStart,KilometrageEnd,
						TotalKilometrage,StartDate,EndDate,RateApplied,TaxRate,OrderStatus,Notes)
VALUES
		(1,2,3,60,NULL,NULL,125000,NULL,NULL,2,5,'Completed',NULL),
		(2,3,2,60,NULL,NULL,240000,NULL,NULL,2,5,'Ordered',NULL),
		(3,1,1,60,NULL,NULL,100000,NULL,NULL,2,5,'Completed',NULL)