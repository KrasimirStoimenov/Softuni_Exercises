--01.Create Table Logs

CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
	OldSum DECIMAL (18,2),
	NewSum DECIMAL (18,2)
)

CREATE TRIGGER tr_TransferFundsWriteToLog
ON Accounts FOR UPDATE
AS
	INSERT INTO Logs(AccountId,OldSum,NewSum)
	SELECT i.Id,d.Balance,i.Balance 
		FROM inserted AS i
		JOIN deleted AS d ON i.Id = d.Id
		WHERE i.Balance <> d.Balance		