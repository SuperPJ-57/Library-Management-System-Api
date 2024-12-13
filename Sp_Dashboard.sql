alter proc Sp_Dashboard
@flag char(2),
@Username varchar(255) = null
as 
begin
begin try
	begin tran;
		if @flag = 'S'
			begin
				--public int TotalBorrowedBooks { get; set; }
				--public int TotalReturnedBooks { get; set; }
				--public int TotalUserBase { get; set; }
				--public int TotalBooks { get; set; }
				--public int AvailableBooks { get; set; }
				Declare @tbb int;
				Declare @trb int;
				Declare @tub int;
				Declare @tb int;
				Declare @ab int;
				Declare @userid int;
				Declare @email varchar(255);
				Declare @role varchar(11);


				update Transactions set status = 'Overdue' 
				where
				status = 'Active' and DueDate<GETDATE();


				select @tbb = count(*)   from transactions where status in ('Active','Overdue');

				select @trb = count(*) from transactions where 
				status = 'Completed';

				select @tub =  count(*) from students 
				select @tub = @tub + count(*) from users;
				--select @tub;

				select @tb = count(barcode) from bookcopies 
				where IsDeleted = 0;

				select @ab = count(barcode) from bookcopies
				where isavailable = 1;

				select @userid = UserId from Users where Username= @Username;

				select @email = Email from Users where Username= @Username;

				select @role = Role from Users where Username= @Username;

				select @tbb as TotalBorrowedBooks,
				@trb as TotalReturnedBooks,
				@tub as TotalUserBase,
				@tb as TotalBooks,
				@ab as AvailableBooks,
				@userid as UserId,
				@email as Email,
				@role as Role;
				
				

			end
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

exec sp_Dashboard @flag='S', @Username='admin';