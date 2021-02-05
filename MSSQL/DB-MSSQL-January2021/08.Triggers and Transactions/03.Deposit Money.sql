--3.Deposit Money

CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS

	IF(@MoneyAmount < 0)
		THROW 50002, 'MoneyAmount should be positive number',1;

	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @AccountId

GO
 
EXEC usp_DepositMoney 2,10