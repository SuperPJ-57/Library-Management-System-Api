alter procedure Sp_Users
@flag char(2),
@UserID int = null,
@Username varchar(100) = null,
@Password varchar(255) = null,
@Email varchar(255) = null,
@Role nvarchar(10) = null

as
begin
	begin try
		begin tran;
		if @flag = 'I'
			begin
				if @UserID is not null
				begin
					insert into Users(UserId,Username,Password,Email,Role)		values(@UserID,@Username,@Password,@Email,@Role);
				end
				else
				begin
					insert into Users(Username,Password,Email,Role)		values(@Username,@Password,@Email,@Role);
				end
				commit tran;
				return;
			end
		
		else if @flag = 'U'
			begin
				Update Users set Username = @Username,Password= @Password,
				Email = @Email, Role = @Role
				where UserId = @UserId;
				commit tran;
				return;
			end
		else if @flag = 'D'
			begin
				Delete from Users 
				where UserId = @UserId;
				commit tran;
				return;
			end

		else if @flag = 'S'
			begin
				 IF @UserID IS NOT NULL
					BEGIN
						SELECT * 
						FROM Users 
						WHERE UserID = @UserID;
					END
				ELSE
					BEGIN
						SELECT * 
						FROM Users;
					END

				COMMIT TRAN;
				RETURN;
			end
		
		else if @flag = 'A' --Authentication
			begin
				Select *from Users where Username = @Username;
				commit tran;
				return;
			end

		ELSE
		BEGIN
			--IF no valid flag is provided
			ROLLBACK TRAN;
			SELECT 1 AS msgId, 'Invalid operation flag.' AS Msg;
			RETURN;
		END
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
end;
go


select *from books;