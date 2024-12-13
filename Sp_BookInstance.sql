ALTER PROCEDURE Sp_BookInstance
@flag CHAR(2),
@BookID INT = null,
@BarCode INT = null,
@IsAvailable BIT = null
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;

        -- Insert Operation
        IF @flag = 'I'
        BEGIN
            -- Check if BookId exists in Books table
            IF NOT EXISTS (SELECT 1 FROM Books WHERE BookId = @BookID)
            BEGIN
                THROW 50000, 'The provided BookId does not exist in the Books table.', 1;
            END
			if Exists (select 1 from BookCopies where barcode=@BarCode and IsDeleted = 1 and BookId = @BookID)
			begin
				update BookCopies set IsDeleted = 0 ,
				IsAvailable = 1 where barcode = @barcode;
				update books set quantity = quantity + 1 where
				bookid = @BookID;
			end
			else
			begin
				-- Insert the BookCopy
				INSERT INTO BookCopies (BarCode, BookId)
				VALUES (@BarCode, @BookID);
			end
            

            COMMIT TRAN;
            RETURN;
        END

        -- Update Operation
        ELSE IF @flag = 'U'
        BEGIN
            -- Check if the BookId exists in Books table
            IF NOT EXISTS (SELECT 1 FROM Books WHERE BookId = @BookID)
            BEGIN
                THROW 50000, 'The provided BookId does not exist in the Books table.', 1;
            END

            -- Saving the value of previous BookId in @prevBookId
            DECLARE @prevBookId INT;
            SELECT @prevBookId = BookId FROM BookCopies WHERE BarCode = @BarCode;

            -- Update BookCopy with new BookId
            UPDATE BookCopies 
            SET BookId = @BookID
            WHERE BarCode = @BarCode;

            -- Adjust the Quantity in Books table
            UPDATE Books 
            SET Quantity = Quantity - 1 
            WHERE BookId = @prevBookId;

            UPDATE Books 
            SET Quantity = Quantity + 1 
            WHERE BookId = @BookID;

            -- Return the updated BookCopy
            SELECT * 
            FROM BookCopies 
            WHERE BarCode = @BarCode;

            COMMIT TRAN;
            RETURN;
        END

        -- Delete Operation
        ELSE IF @flag = 'D'
        BEGIN
            -- Ensure the BookCopy exists before deletion
            IF NOT EXISTS (SELECT 1 FROM BookCopies WHERE BarCode = @BarCode)
            BEGIN
                THROW 50001, 'The BookCopy with the provided BarCode does not exist.', 1;
            END

            -- Delete the BookCopy
            DELETE FROM BookCopies 
            WHERE BarCode = @BarCode;

            -- Return success message
            SELECT 1 AS Success, @BarCode AS Id, 'Book deleted successfully.' AS Message;

            COMMIT TRAN;
            RETURN;
        END

        -- Select Operation
        ELSE IF @flag = 'S'
        BEGIN
			With BookCopiesDetail as
			(
				select Title,BC.BookId as BookId,BC.BarCode as BarCode from
				Books B join BookCopies BC
				on B.BookId = BC.BookId where IsDeleted = 0
				
			)
			SELECT Title,BookId,BarCode
			FROM BookCopiesDetail 
            WHERE @BarCode is Null or BarCode= @BarCode
			order by BookId;
            
            

			
			

            COMMIT TRAN;
            RETURN;
        END

        -- Invalid flag
        ELSE
        BEGIN
            ROLLBACK TRAN;
            SELECT 1 AS MsgId, 'Invalid operation flag.' AS Msg;
            RETURN;
        END

    END TRY

    BEGIN CATCH
        -- Rollback transaction in case of error
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN;

        -- Capture and display error details
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO

