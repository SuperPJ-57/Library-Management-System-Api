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

            -- Insert the BookCopy
            INSERT INTO BookCopies (BarCode, BookId)
            VALUES (@BarCode, @BookID);

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
            IF @BarCode IS NOT NULL
            BEGIN
                SELECT BarCode,BookId
				FROM BookCopies 
                WHERE BarCode = @BarCode and IsDeleted = 0;
            END
            ELSE
            BEGIN
                SELECT BarCode,BookId
				FROM BookCopies 
                WHERE  IsDeleted = 0;
            END

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
