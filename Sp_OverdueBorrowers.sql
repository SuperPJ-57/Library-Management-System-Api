create proc Sp_OverdueBorrowers
as 
begin
begin try
	begin tran;
		

		SELECT  S.Name as BorrowerName, S.Email as BorrowerEmail, T.Date as BorrowedDate, B.Title as BookTitle FROM Students S inner join Transactions T on S.StudentId = T.StudentId inner join Books B on T.BookId = B.BookId
where T.status = 0 and DATEADD(week, 2, Date) < GETDATE();



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

