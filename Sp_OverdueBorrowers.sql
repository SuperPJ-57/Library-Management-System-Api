alter proc Sp_OverdueBorrowers
as 
begin
begin try
	begin tran;
		--set login flag = true;
			declare @today DATE = Getdate();
			if not exists (select 1 as date where @today in (select date from 
			dailyfirstlogin))
			begin
				insert into dailyfirstlogin
				values(GETDATE(),1);

				update Transactions set status = 'Overdue' 
				where
				status = 'Active' and DueDate<GETDATE();
			end
		
		
		SELECT  Top 5 S.Name as BorrowerName,S.StudentId as BorrowerId,T.TransactionId as BorrowId, S.Email as BorrowerEmail, T.DueDate as DueDate, B.Title as BookTitle FROM Students S inner join Transactions T on S.StudentId = T.StudentId inner join Books B on T.BookId = B.BookId
where T.status = 'Overdue';



	commit tran;
	return
end try
begin catch
	--Rollback transaction in case of error
	IF @@TRANCOUNT > 0
		ROLLBACK TRAN;

		--Capture and display error details
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		RAISERROR(@ErrorMessage,@ErrorSeverity,@ErrorState);
end catch
end
go

exec sp_overdueborrowers;
