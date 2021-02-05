--4.Withdraw Money

CREATE PROCEDURE usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
	IF(@MoneyAmount >= (SELECT Balance FROM Accounts 
						WHERE ID = @AccountId))
		THROW 50001, 'Unsufficient Money',1;

	IF(@MoneyAmount < 0)
		THROW 50002, 'MoneyAmount should be positive number',1;

	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId
GO