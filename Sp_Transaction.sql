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


ALTER PROCEDURE Sp_Transactions
@flag CHAR(2),
@TransactionID INT=null,
@StudentId INT = null,
@UserId INT = null,
@BookId INT = null,
@TransactionType VARCHAR(10) = null,
@Date DATE = null
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;

        -- Insert Operation
        IF @flag = 'I'
        BEGIN
			if @TransactionID is not null
			begin
				INSERT INTO Transactions (TransactionId,StudentId, UserId, BookId, TransactionType, Date) 
				VALUES (@TransactionID,@StudentId, @UserId, @BookId, @TransactionType, @Date);

				select *from Transactions where TransactionId = @TransactionID;

			end
            
			else
			begin
				INSERT INTO Transactions (StudentId, UserId, BookId, TransactionType, Date) 
				VALUES (@StudentId, @UserId, @BookId, @TransactionType, @Date);

				-- Return the newly created transaction
				SELECT * 
				FROM Transactions 
				WHERE TransactionID = SCOPE_IDENTITY();
			end



            

            COMMIT TRAN;
            RETURN;
        END

        -- Update Operation
        ELSE IF @flag = 'U'
        BEGIN
            UPDATE Transactions 
            SET StudentId = @StudentId, 
                UserId = @UserId, 
                BookId = @BookId, 
                TransactionType = @TransactionType, 
                Date = @Date
            WHERE TransactionId = @TransactionId;

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
            -- Capture the transaction details before deletion
            DECLARE @DeletedTransaction TABLE (TransactionID INT, StudentID INT, UserID INT, BookID INT, TransactionType VARCHAR(10), Date DATE);
            INSERT INTO @DeletedTransaction
            SELECT * 
            FROM Transactions 
            WHERE TransactionID = @TransactionID;

            DELETE FROM Transactions 
            WHERE TransactionID = @TransactionID;

            -- Return the deleted transaction details
            SELECT * 
            FROM @DeletedTransaction;

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


 exec Sp_Transactions @flag = 'S' , @TransactionID = 1;