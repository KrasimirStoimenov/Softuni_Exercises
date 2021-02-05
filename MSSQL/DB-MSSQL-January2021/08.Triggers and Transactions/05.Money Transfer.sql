--5.Money Transfer

CREATE PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18,4)) 
AS
BEGIN TRANSACTION
	IF(@Amount >= (SELECT Balance FROM Accounts 
						WHERE ID = @SenderId))
		BEGIN
			ROLLBACK;
			THROW 50001, 'Unsufficient Money',1;
		END

	IF(@Amount < 0)
		BEGIN
			ROLLBACK;
			THROW 50002, 'MoneyAmount should be positive number',1;
		END

		EXEC [dbo].[usp_WithdrawMoney] @SenderId, @Amount
		EXEC [dbo].[usp_DepositMoney] @ReceiverId, @Amount
COMMIT

GO

EXEC usp_TransferMoney 2,1,200