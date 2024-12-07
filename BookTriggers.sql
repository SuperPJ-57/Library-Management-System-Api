create TRIGGER DecrementBookQuantity
ON BookCopies
AFTER delete
AS
BEGIN
    -- Update the book's quantity after a new book_copy is deleted
    UPDATE books
    SET quantity = quantity - 1
    FROM books
    INNER JOIN INSERTED i ON books.BookId = i.BookId;
END;



create TRIGGER IncrementBookQuantity
ON BookCopies
AFTER INSERT
AS
BEGIN
    -- Update the book's quantity after a new book_copy is added
    UPDATE books
    SET quantity = quantity + 1
    FROM books
    INNER JOIN INSERTED i ON books.BookId = i.BookId;
END;


alter TRIGGER DeleteBookCopies
ON Books
Instead of DELETE
AS
BEGIN
	begin try
		begin
			begin tran
				--set book quantity to 0
				update Books set quantity = 0 where BookId 
				in (select BookId from deleted);
				-- Delete corresponding book copies from the BookCopies table
				update  BookCopies set IsDeleted = 1
				WHERE BookId IN (SELECT BookId FROM DELETED);
			commit tran
		end
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
    
END;




alter TRIGGER SoftDeleteBookCopies
ON BookCopies
INSTEAD OF DELETE
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION; -- Start the transaction

        -- Perform the soft delete operation
        UPDATE BookCopies
        SET IsDeleted = 1
        WHERE BarCode IN (SELECT BarCode FROM DELETED);

		update books 
		set quantity = quantity -1
		where bookid = (select BookId from DELETED);

        COMMIT TRANSACTION; -- Commit the transaction if everything succeeds
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION; -- Rollback the transaction in case of an error

        -- Optionally, log the error or rethrow it
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState); -- Re-raise the error
    END CATCH
END;
