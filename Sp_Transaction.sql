--alter procedure Sp_Transactions
--@flag char(2),
--@TransactionID int,
--@StudentId int,
--@UserId int,
--@BookId int,
--@TransactionType varchar(10),
--@Date date

--as
--begin
--	begin try
--		begin tran;
--		if @flag = 'I'
--			begin
--				insert into transactions(StudentId,UserId,BookId,TransactionType,Date) values(@StudentId,@UserId,@BookId,@TransactionType,
--					@Date);
--				commit tran;
--				return;
--			end
		
--		else if @flag = 'U'
--			begin
--				Update transactions set StudentId = @StudentId,UserId= @UserId,
--				BookId =@BookId ,
--				TransactionType = @TransactionType, Date = @Date
--				where TransactionId = @TransactionId;
--				commit tran;
--				return;
--			end
--		else if @flag = 'D'
--			begin
--				Delete from transactions 
--				where TransactionId = @TransactionId;
--				commit tran;
--				return;
--			end

--		else if @flag = 'S'
--			begin
--				 IF @TransactionID IS NOT NULL
--					BEGIN
--						SELECT * 
--						FROM Transactions 
--						WHERE TransactionID = @TransactionID;
--					END
--				ELSE
--					BEGIN
--						SELECT * 
--						FROM Transactions;
--					END

--				COMMIT TRAN;
--				RETURN;
--			end

--		ELSE
--		BEGIN
--			--IF no valid flag is provided
--			ROLLBACK TRAN;
--			SELECT 1 AS msgId, 'Invalid operation flag.' AS Msg;
--			RETURN;
--		END
--	end try

--	begin catch
--		--Rollback transaction in case of error
--	IF @@TRANCOUNT > 0
--		ROLLBACK TRAN;

--		--Capture and display error details
--		DECLARE @ErrorMessage NVARCHAR(4000);
--		DECLARE @ErrorSeverity INT;
--		DECLARE @ErrorState INT;

--		SELECT
--			@ErrorMessage = ERROR_MESSAGE(),
--			@ErrorSeverity = ERROR_SEVERITY(),
--			@ErrorState = ERROR_STATE();

--		RAISERROR(@ErrorMessage,@ErrorSeverity,@ErrorState);
--	end catch
--end;
--go


--ALTER PROCEDURE Sp_Transactions
--@flag CHAR(2),
--@TransactionID INT=null,
--@StudentId INT = null,
--@UserId INT = null,
--@BookId INT = null,
--@BarCode int = null,
--@TransactionType VARCHAR(10) = null,
--@Date DATE = null
--AS
--BEGIN
--    BEGIN TRY
--        BEGIN TRAN;

--        -- Insert Operation
--        IF @flag = 'I'
--BEGIN
--    IF @TransactionID IS NULL
--    BEGIN
--        -- Check TransactionType
--        IF @TransactionType = 'Borrow'
--        BEGIN
--            -- Check if the book copy is available or deleted
--            IF EXISTS (
--                SELECT 1 
--                FROM BookCopies 
--                WHERE BarCode = @BarCode AND (IsAvailable = 0 OR IsDeleted = 1)
--            )
--            BEGIN
--                -- Throw an error if the book copy is not available or deleted
--                THROW 50000, 'The book copy is either not available or has been deleted.', 1;
--            END

--            -- Mark the book copy as not available
--            UPDATE BookCopies
--            SET IsAvailable = 0
--            WHERE BarCode = @BarCode;
--        END
--        ELSE IF @TransactionType = 'Return'
--        BEGIN
--            -- Check if the book copy is deleted or already available
--            IF EXISTS (
--                SELECT 1 
--                FROM BookCopies 
--                WHERE BarCode = @BarCode AND (IsDeleted = 1 OR IsAvailable = 1)
--            )
--            BEGIN
--                -- Throw an error if the book copy is deleted or already available
--                THROW 50001, 'The book copy cannot be returned because it is either already available or deleted.', 1;
--            END

--            -- Mark the book copy as available
--            UPDATE BookCopies
--            SET IsAvailable = 1
--            WHERE BarCode = @BarCode;
--        END


--        -- Insert the transaction record
--        INSERT INTO Transactions (TransactionId, StudentId, UserId, BookId, BarCode, TransactionType, Date) 
--        VALUES (@TransactionID, @StudentId, @UserId, @BookId, @BarCode, @TransactionType, @Date);

--        -- Return the inserted transaction
--        SELECT * 
--        FROM Transactions 
--        WHERE TransactionId = @TransactionID;
--    END
--END


--        -- Update Operation
--        ELSE IF @flag = 'U'
--        BEGIN
--            UPDATE Transactions 
--            SET StudentId = @StudentId, 
--                UserId = @UserId, 
--                BookId = @BookId, 
--                TransactionType = @TransactionType, 
--                Date = @Date
--            WHERE TransactionId = @TransactionId;

--            -- Return the updated transaction
--            SELECT * 
--            FROM Transactions 
--            WHERE TransactionID = @TransactionID;

--            COMMIT TRAN;
--            RETURN;
--        END

--        -- Delete Operation
--        ELSE IF @flag = 'D'
--        BEGIN
--            -- Capture the transaction details before deletion
--            DECLARE @DeletedTransaction TABLE (TransactionID INT, StudentID INT, UserID INT, BookID INT, TransactionType VARCHAR(10), Date DATE);
--            INSERT INTO @DeletedTransaction
--            SELECT * 
--            FROM Transactions 
--            WHERE TransactionID = @TransactionID;

--            DELETE FROM Transactions 
--            WHERE TransactionID = @TransactionID;

--            -- Return the deleted transaction details
--            SELECT 1 AS Success,@TransactionID as Id, 'Transaction deleted successfully.' AS Message;

--            COMMIT TRAN;
--            RETURN;
--        END

--        -- Select Operation
--        ELSE IF @flag = 'S'
--        BEGIN
--            IF @TransactionID IS NOT NULL
--            BEGIN
--                SELECT * 
--                FROM Transactions 
--                WHERE TransactionID = @TransactionID;
--            END
--            ELSE
--            BEGIN
--                SELECT * 
--                FROM Transactions;
--            END

--            COMMIT TRAN;
--            RETURN;
--        END

--        -- Invalid flag
--        ELSE
--        BEGIN
--            ROLLBACK TRAN;
--            SELECT 1 AS MsgId, 'Invalid operation flag.' AS Msg;
--            RETURN;
--        END

--    END TRY

--    BEGIN CATCH
--        -- Rollback transaction in case of error
--        IF @@TRANCOUNT > 0
--            ROLLBACK TRAN;

--        -- Capture and display error details
--        DECLARE @ErrorMessage NVARCHAR(4000);
--        DECLARE @ErrorSeverity INT;
--        DECLARE @ErrorState INT;

--        SELECT
--            @ErrorMessage = ERROR_MESSAGE(),
--            @ErrorSeverity = ERROR_SEVERITY(),
--            @ErrorState = ERROR_STATE();

--        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
--    END CATCH
--END;
--GO

ALTER PROCEDURE Sp_Transactions
@flag CHAR(2),
@TransactionID INT = NULL,
@StudentId INT = NULL,
@UserId INT = NULL,
@BookId INT = NULL,
@BarCode INT = NULL,
@TransactionType VARCHAR(10) = NULL,
@Date DATE = NULL
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;

        -- Insert Operation
        IF @flag = 'I'
        BEGIN
            -- Handle Borrow Transaction
            IF @TransactionType = 'Borrow'
            BEGIN
                -- Check if the book copy is available or deleted
                IF EXISTS (
                    SELECT 1 
                    FROM BookCopies 
                    WHERE BarCode = @BarCode AND (IsAvailable = 0 OR IsDeleted = 1)
                )
                BEGIN
                    THROW 50000, 'The book copy is either not available or has been deleted.', 1;
                END;

                -- Mark the book copy as not available
                UPDATE BookCopies
                SET IsAvailable = 0
                WHERE BarCode = @BarCode;
            END
            -- Handle Return Transaction
            ELSE IF @TransactionType = 'Return'
            BEGIN
                -- Check if the book copy is deleted or already available
                IF EXISTS (
                    SELECT 1 
                    FROM BookCopies 
                    WHERE BarCode = @BarCode AND (IsDeleted = 1 OR IsAvailable = 1)
                )
                BEGIN
                    THROW 50001, 'The book copy cannot be returned because it is either already available or deleted.', 1;
					return;
                END;

                -- Mark the book copy as available
                UPDATE BookCopies
                SET IsAvailable = 1
                WHERE BarCode = @BarCode;
            END;

            -- Insert the transaction record (TransactionID auto-incremented)
            INSERT INTO Transactions (StudentId, UserId, BookId, BarCode, TransactionType, Date) 
            VALUES (@StudentId, @UserId, @BookId, @BarCode, @TransactionType, @Date);

            -- Return the inserted transaction
            SELECT * 
            FROM Transactions 
            WHERE TransactionId = SCOPE_IDENTITY();

            COMMIT TRAN;
            RETURN;
        END

        -- Update Operation
        ELSE IF @flag = 'U'
        BEGIN
            IF @TransactionID IS NULL
            BEGIN
                THROW 50002, 'TransactionID cannot be NULL for update operation.', 1;
            END;

            UPDATE Transactions 
            SET StudentId = @StudentId, 
                UserId = @UserId, 
                BookId = @BookId, 
                TransactionType = @TransactionType, 
                Date = @Date
            WHERE TransactionId = @TransactionID;

            -- Return the updated transaction
            SELECT * 
            FROM Transactions 
            WHERE TransactionID = @TransactionID;

            COMMIT TRAN;
            RETURN;
        END

        -- Delete Operation
        ELSE IF @flag = 'D'
        BEGIN
            --IF @TransactionID IS NULL
            --BEGIN
            --    THROW 50003, 'TransactionID cannot be NULL for delete operation.', 1;
            --END;

            --DELETE FROM Transactions 
            --WHERE TransactionID = @TransactionID;

            -- Return success message
            SELECT 0 AS Failure, @TransactionID AS Id, 'Transactions cannot be deleted.' AS Message;

            COMMIT TRAN;
            RETURN;
        END

        -- Select Operation
        ELSE IF @flag = 'S'
        BEGIN
            IF @TransactionID IS NOT NULL
            BEGIN
                SELECT * 
                FROM Transactions 
                WHERE TransactionID = @TransactionID;
            END
            ELSE
            BEGIN
                SELECT * 
                FROM Transactions;
            END;

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



 --exec Sp_Transactions @flag = 'I' , @StudentId =1, @UserId = 1,
 --@BookId = 2, @BarCode = 34234234, @TransactionType = 'Return',
 --@Date = '2023-4-2'
 --;