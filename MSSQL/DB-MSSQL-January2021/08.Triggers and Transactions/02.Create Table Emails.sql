--2.Create Table Emails

CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY, 
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id), 
	[Subject] VARCHAR(500), 
	Body VARCHAR(500)
)

CREATE TRIGGER tr_EmailNotification
ON Logs AFTER INSERT
AS
	INSERT INTO NotificationEmails(Recipient,[Subject],Body)
	SELECT i.AccountId,
	CONCAT('Balance change for account: ',i.AccountId),
	CONCAT('On ', GETDATE(),' ', 'your balance was changed from ', i.OldSum,' ', 'to ', i.NewSum)
		FROM inserted AS i
		