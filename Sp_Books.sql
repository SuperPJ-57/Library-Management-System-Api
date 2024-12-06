--alter procedure Sp_Books
--@flag char(2),
--@BookID int,
--@Title varchar(255),
--@AuthorId int,
--@Genre varchar(100),
--@ISBN varchar(13),
--@Quantity int

--as
--begin
--	begin try
--		begin tran;
--		if @flag = 'I'
--			begin
--				insert into books(BookId,Title,AuthorId,Genre,ISBN,Quantity) values(@BookId,@Title,@AuthorId,@Genre,
--					@ISBN,@Quantity);
--				commit tran;
--				return;
--			end
		
--		else if @flag = 'U'
--			begin
--				Update books set Title = @Title,AuthorId= @AuthorId,
--				Genre = @Genre, ISBN = @ISBN, Quantity = @Quantity 
--				where BookId = @BookId;
--				commit tran;
--				return;
--			end
--		else if @flag = 'D'
--			begin
--				Delete from books 
--				where BookId = @BookId;
--				commit tran;
--				return;
--			end

--		else if @flag = 'S'
--			begin
--				 IF @BookID IS NOT NULL
--					BEGIN
--						SELECT * 
--						FROM Books 
--						WHERE BookID = @BookID;
--					END
--				ELSE
--					BEGIN
--						SELECT * 
--						FROM Books;
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

ALTER PROCEDURE Sp_Books
@flag CHAR(2),
@BookID INT = null,
@Title VARCHAR(255) = null,
@AuthorId INT = null,
@Genre VARCHAR(100) = null,
@ISBN VARCHAR(13) = null,
@Quantity INT = null
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;

        -- Insert Operation
        IF @flag = 'I'
        BEGIN
			if @BookID is not null
			begin
				INSERT INTO Books (BookId, Title, AuthorId,Genre,ISBN,Quantity) 
				VALUES (@BookID, @Title, @AuthorId,@Genre,@ISBN,@Quantity);

					SELECT * 
			FROM Books 
			WHERE BookId = @BookID;
			end

			else
			begin
				INSERT INTO Books ( Title, AuthorId,Genre,ISBN,Quantity) 
				VALUES ( @Title, @AuthorId,@Genre,@ISBN,@Quantity);

				--return the row
					SELECT * 
			FROM Books 
			WHERE BookId = SCOPE_IDENTITY();
			end
            

            COMMIT TRAN;
            RETURN;
        END

        -- Update Operation
        ELSE IF @flag = 'U'
        BEGIN
            UPDATE Books 
            SET Title = @Title, 
                AuthorId = @AuthorId, 
                Genre = @Genre, 
                ISBN = @ISBN, 
                Quantity = @Quantity
            WHERE BookId = @BookID;

            -- Return the updated book
            SELECT * 
            FROM Books 
            WHERE BookId = @BookID;

            COMMIT TRAN;
            RETURN;
        END

        -- Delete Operation
        ELSE IF @flag = 'D'
        BEGIN
            -- Capture the book details before deletion if needed
            DECLARE @DeletedBook TABLE (BookId INT, Title VARCHAR(255), AuthorId INT, Genre VARCHAR(100), ISBN VARCHAR(13), Quantity INT);
            INSERT INTO @DeletedBook
            SELECT * 
            FROM Books 
            WHERE BookId = @BookID;

            DELETE FROM Books 
            WHERE BookId = @BookID;

            -- Return the deleted book details
            SELECT * 
            FROM @DeletedBook;

            COMMIT TRAN;
            RETURN;
        END

        -- Select Operation
        ELSE IF @flag = 'S'
        BEGIN
            IF @BookID IS NOT NULL
            BEGIN
                SELECT * 
                FROM Books 
                WHERE BookID = @BookID;
            END
            ELSE
            BEGIN
                SELECT * 
                FROM Books;
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



exec Sp_Books @flag = 'S', @BookID = 1;