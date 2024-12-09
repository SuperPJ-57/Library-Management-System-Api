create proc Sp_Dashboard
@flag char(2)
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

				select @tbb = count(*)   from transactions where status =0;

				select @trb = count(*) from transactions where 
				status = 1;

				select @tub =  count(*) from students 
				select @tub = @tub + count(*) from users;
				--select @tub;

				select @tb = count(barcode) from bookcopies 
				where IsDeleted = 0;

				select @ab = count(barcode) from bookcopies
				where isavailable = 1;

				select @tbb as TotalBorrowedBooks,
				@trb as TotalReturnedBooks,
				@tub as TotalUserBase,
				@tb as TotalBooks,
				@ab as AvailableBooks;
				
				

			end
	commit tran;
	return
end try
begin catch

end catch
end
go

--exec sp_Dashboard @flag='S';