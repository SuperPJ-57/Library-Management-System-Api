--alter procedure Sp_Authors
--@flag char(2),
--@AuthorID int,
--@Name varchar(255),
--@Bio Text
--as
--begin
--	begin try
--		begin tran;
--		if @flag = 'I'
--			begin
--				insert into Authors(AuthorId,Name,Bio) values(@AuthorId,@Name,@Bio);
--				commit tran;
--				return;
--			end
		
--		else if @flag = 'U'
--			begin
--				Update Authors set Name = @Name,Bio= @Bio			
--				where AuthorId = @AuthorId;
--				commit tran;
--				return;
--			end

--		else if @flag = 'D'
--			begin
--				Delete from Authors 
--				where AuthorId = @AuthorId;
--				commit tran;
--				return;
--			end

--		else if @flag = 'S'
--			begin
--				 IF @AuthorID IS NOT NULL
--					BEGIN
--						SELECT * 
--						FROM Authors 
--						WHERE AuthorID = @AuthorID;
--					END
--				ELSE
--					BEGIN
--						SELECT * 
--						FROM Authors;
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


ALTER PROCEDURE Sp_Authors
@flag CHAR(2),
@AuthorID INT = null,
@Name VARCHAR(255) = null,
@Bio TEXT = null
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;

        -- Insert Operation
        IF @flag = 'I'
        BEGIN
			if @AuthorID is not null
			begin
				INSERT INTO Authors (AuthorId, Name, Bio) 
				VALUES (@AuthorID, @Name, @Bio);

					SELECT * 
			FROM Authors 
			WHERE AuthorId = @AuthorID;
			end
			else
			begin
				INSERT INTO Authors ( Name, Bio) 
				VALUES ( @Name, @Bio);

				--return the row
					SELECT * 
			FROM Authors 
			WHERE AuthorId = SCOPE_IDENTITY();
			end
            

            COMMIT TRAN;
            RETURN;
        END

        -- Update Operation
        ELSE IF @flag = 'U'
        BEGIN
            UPDATE Authors 
            SET Name = Coalesce(@Name,Name), Bio = Coalesce(@Bio,Bio)
            WHERE AuthorId = @AuthorID;

            -- Return the updated row
            SELECT * 
            FROM Authors 
            WHERE AuthorId = @AuthorID;

            COMMIT TRAN;
            RETURN;
        END

        -- Delete Operation
        ELSE IF @flag = 'D'
        BEGIN
			
            if exists (select 1 from authors where isdeleted = 0
			and AuthorID = @AuthorID)
			begin
			 update Authors set IsDeleted = 1 
            WHERE AuthorId = @AuthorID;

            -- Return the deleted student details
            SELECT 1 AS Success,@AuthorID as Id, 'Author deleted successfully.' AS Message;

			end
			else
			begin
			SELECT 0 AS Success,@AuthorID as Id, 'Author could not be found.' AS Message;
			end
           

            COMMIT TRAN;
            RETURN;
        END

        -- Select Operation
        ELSE IF @flag = 'S'
        BEGIN
            IF @AuthorID IS NOT NULL
            BEGIN
                SELECT * 
                FROM Authors 
                WHERE AuthorID = @AuthorID and IsDeleted = 0;
            END
            ELSE
            BEGIN
                SELECT * 
                FROM Authors where IsDeleted = 0;
            END

            COMMIT TRAN;
            RETURN;
        END

        -- Invalid flag
        ELSE
        BEGIN
            ROLLBACK TRAN;
            SELECT 1 AS msgId, 'Invalid operation flag.' AS Msg;
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

--exec Sp_Authors @flag = 'S', @AuthorID = 1;