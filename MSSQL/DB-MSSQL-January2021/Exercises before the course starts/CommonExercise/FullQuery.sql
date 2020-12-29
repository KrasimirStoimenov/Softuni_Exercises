CREATE DATABASE restaurants;

CREATE DATABASE computers;

USE computers;

USE restaurants;

DROP DATABASE computers;

USE master;

DROP DATABASE restaurants;

CREATE DATABASE pets;

USE pets;

CREATE TABLE dogs(
	[name] VARCHAR(20),
	age INT
);

CREATE TABLE cats(
	[name] VARCHAR(20),
	age INT,
	color VARCHAR(10)
);

INSERT INTO dogs([name],age)
	VALUES('Bella',4);

INSERT INTO cats([name],age,color)
	VALUES('Cindy',5,'Brown');

INSERT INTO dogs([name],age)
	VALUES('Tom',6),('Woofy',5);

SELECT * FROM dogs;

SELECT * FROM cats;

--DROP TABLES
DROP TABLE cats;

DROP TABLE dogs;

--Make changes to our table
ALTER TABLE dogs
	ADD Color VARCHAR(20);

INSERT INTO dogs([Name],age,color)
	VALUES('Shaun',3,'Grey');

ALTER TABLE dogs
	DROP COLUMN Color;

DROP DATABASE pets;
