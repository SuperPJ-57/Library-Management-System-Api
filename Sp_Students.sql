--alter procedure Sp_Students
--@flag char(2),
--@StudentID int,
--@Name varchar(255),
--@Email varchar(255),
--@ContactNumber varchar(15),
--@Department varchar(100)

--as
--begin
--	begin try
--		begin tran;
--		if @flag = 'I'
--			begin
--				insert into students(StudentId,Name,Email,ContactNumber,Department) values(@StudentId,@Name,@Email,@ContactNumber,
--					@Department);
--				commit tran;
--				return;
--			end
		
--		else if @flag = 'U'
--			begin
--				Update students set Name = @Name,Email= @Email,
--				ContactNumber = @ContactNumber, Department = @Department
--				where StudentId = @StudentId;
--				commit tran;
--				return;
--			end
--		else if @flag = 'D'
--			begin
--				Delete from students 
--				where StudentId = @StudentID;
--				commit tran;
--				return;
--			end

--		else if @flag = 'S'
--			begin
--				 IF @StudentID IS NOT NULL
--					BEGIN
--						SELECT * 
--						FROM Students 
--						WHERE StudentID = @StudentID;
--					END
--				ELSE
--					BEGIN
--						SELECT * 
--						FROM Students;
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

ALTER PROCEDURE Sp_Students
@flag CHAR(2),
@StudentID INT = null,
@Name VARCHAR(255) = null,
@Email VARCHAR(255) = null,
@ContactNumber VARCHAR(15) = null,
@Department VARCHAR(100) = null
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;

        -- Insert Operation
        IF @flag = 'I'
        BEGIN
		if @StudentID is not null
			begin
				INSERT INTO Students (StudentId, Name, Email, ContactNumber, Department) 
				VALUES (@StudentID, @Name, @Email, @ContactNumber, @Department);

				-- Return the newly created student
				SELECT * 
				FROM Students 
				WHERE StudentID = @StudentID;
			end


		else
			begin
				INSERT INTO Students ( Name, Email, ContactNumber, Department) 
				VALUES ( @Name, @Email, @ContactNumber, @Department);

				SELECT * 
			FROM Students 
			WHERE StudentId = SCOPE_IDENTITY();
			end

            COMMIT TRAN;
            RETURN;
        END

        -- Update Operation
        ELSE IF @flag = 'U'
        BEGIN
            UPDATE Students 
            SET Name = @Name, 
                Email = @Email, 
                ContactNumber = @ContactNumber, 
                Department = @Department
            WHERE StudentID = @StudentID;

            -- Return the updated student
            SELECT * 
            FROM Students 
            WHERE StudentID = @StudentID;

            COMMIT TRAN;
            RETURN;
        END

        -- Delete Operation
        ELSE IF @flag = 'D'
        BEGIN
            -- Capture the student details before deletion if needed
            --DECLARE @DeletedStudent TABLE (StudentID INT, Name VARCHAR(255), Email VARCHAR(255), ContactNumber VARCHAR(15), Department VARCHAR(100));
            --INSERT INTO @DeletedStudent
            --SELECT * 
            --FROM Students 
            --WHERE StudentID = @StudentID;
			if exists (select 1 from students where isdeleted = 0
			and studentid = @StudentID)
			begin
			 update Students set IsDeleted = 1 
            WHERE StudentID = @StudentID;

            -- Return the deleted student details
            SELECT 1 AS Success,@StudentID as Id, 'Student deleted successfully.' AS Message;

			end
			else
			begin
			SELECT 0 AS Success,@StudentID as Id, 'Student could not be found.' AS Message;
			end
           

            COMMIT TRAN;
            RETURN;
        END

        -- Select Operation
        ELSE IF @flag = 'S'
        BEGIN
            IF @StudentID IS NOT NULL
            BEGIN
                SELECT StudentId,Name,Email,ContactNumber,Department 
                FROM Students 
                WHERE StudentID = @StudentID and IsDeleted = 0;
            END
            ELSE
            BEGIN
                SELECT StudentId,Name,Email,ContactNumber,Department
                FROM Students where IsDeleted = 0;
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



--exec Sp_Students @flag = 'S', @StudentID = 1;