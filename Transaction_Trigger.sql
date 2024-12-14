create trigger InsteadOfTransactionDelete
on Transactions 
instead of Delete
as
begin
	begin try
		begin tran
			select  'cannot delete transactions' as msg;

		commit tran
		return
	end try

	begin catch
		ROLLBACK TRANSACTION; -- Rollback the transaction in case of an error

        -- Optionally, log the error or rethrow it
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	end catch


end

