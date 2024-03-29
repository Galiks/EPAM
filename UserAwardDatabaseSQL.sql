USE master 
GO 

IF EXISTS(SELECT * FROM sys.databases WHERE name='Olympics') 
BEGIN 
DROP DATABASE Olympics
END 
GO 

CREATE DATABASE Olympics
GO 

USE Olympics
GO

CREATE TABLE [User] (
	id_user int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_User] primary key,
	[Name] nvarchar(50) NOT NULL,
	Birthday date NOT NULL,
	Age int NOT NULL,
	UserPhoto varbinary(MAX)
)
GO

CREATE TABLE [Account] (
	id_account int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Account] primary key,
	[Email] nvarchar(250) unique NOT NULL,
	[Password] nvarchar(500) NOT NULL,
	[Role] nvarchar(150) NOT NULL,
	[CreatedAt] datetime NOT NULL,
	[LoggedInto] datetime NOT NULL,
	[PasswordLifetime] datetime NOT NULL,
	[IsBlocked] bit NOT NULL,
	id_user int unique NOT NULL,
)
GO

CREATE TABLE Award (
	id_award int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Award] primary key,
	Title nvarchar(50) NOT NULL,
	[Description] nvarchar(250),
	AwardImage varbinary(MAX)
)
GO

CREATE TABLE User_Award (
	id int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_User_Award] primary key,
	id_user int NOT NULL,
	id_award int NOT NULL
)
GO

ALTER TABLE [Account] ADD CONSTRAINT [FK_Account_TO_User]
FOREIGN KEY ([id_user]) references [User]([id_user])
on delete cascade
on update cascade
GO

ALTER TABLE [User_Award] ADD CONSTRAINT [FK_User_Award_TO_User]
FOREIGN KEY ([id_user]) references [User]([id_user])
on delete cascade
on update cascade
GO

ALTER TABLE [User_Award] ADD CONSTRAINT [FK_User_Award_TO_Award]
FOREIGN KEY ([id_award]) references [Award]([id_award])
on delete cascade
on update cascade
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE AddUser --1
	@Name nvarchar(50),
	@Birthday date,
	@Age int,
	@UserPhoto varbinary(MAX),
	@Id int OUTPUT
AS
BEGIN
	INSERT INTO [dbo].[User]
           ([Name]
           ,[Birthday]
           ,[Age]
		   ,[UserPhoto])
     VALUES
           (@Name,
		    @Birthday, 
			@Age,
			@UserPhoto)

	SET @Id = @@IDENTITY
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE DeleteUser --2
	@ID int
AS
BEGIN
	DELETE FROM [dbo].[User]
      WHERE [id_user] = @ID

	SELECT SCOPE_IDENTITY()
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetUserByID --3
	@ID int
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Birthday]
      ,[Age]
	  ,[UserPhoto]
  FROM [Olympics].[dbo].[User]
  WHERE [id_user] = @ID
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetUserByName --4
	@NAME nvarchar(200)
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Birthday]
      ,[Age]
	  ,[UserPhoto]
  FROM [Olympics].[dbo].[User]
  WHERE [Name] LIKE @NAME
  Order By Age Desc
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetUserByLetter --5
	@LETTER char
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Birthday]
      ,[Age]
	  ,[UserPhoto]
  FROM [Olympics].[dbo].[User]
  WHERE [Name] LIKE @LETTER + '%'
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetUserByWord--6
	@WORD nvarchar(200)
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Birthday]
      ,[Age]
	  ,[UserPhoto]
  FROM [Olympics].[dbo].[User]
  WHERE [Name] LIKE (@WORD+'%'+@WORD)
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE UpdateUser--7
	@ID int,
	@NAME nvarchar(100),
	@BIRTHDAY date,
	@AGE int,
	@UserPhoto varbinary(MAX),
	@Id_update int OUTPUT
AS
BEGIN
	UPDATE Olympics.dbo.[User]
	SET 
	[Name] = @NAME,
	Birthday = @BIRTHDAY,
	Age = @AGE,
	UserPhoto = @UserPhoto,
	@Id_update = @ID
	WHERE id_user = @ID

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE AddAward --8
	@TITLE nvarchar(50),
	@DESCRIPTION nvarchar(300) ='Empty Description',
	@AwardImage varbinary(MAX) = null,
	@Id int OUTPUT
AS
BEGIN
	INSERT INTO [dbo].[Award]
           ([Title]
           ,[Description]
		   ,[AwardImage])
     VALUES
           (@TITLE,
		   @DESCRIPTION,
		   @AwardImage)

	SET @Id = @@IDENTITY
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwards] --9
AS
BEGIN
	SELECT [id_award]
      ,[Title]
      ,[Description]
	  ,[AwardImage]
  FROM [Olympics].[dbo].[Award]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE UpdateAward --10
	@ID int,
	@TITLE nvarchar(50),
	@DESCRIPTION nvarchar(300) = 'Empty Description',
	@AwardImage varbinary(MAX) = null,
	@Id_update int OUTPUT
AS
BEGIN
	UPDATE Olympics.dbo.Award
	SET Title = @TITLE,
	[Description] = @DESCRIPTION,
	AwardImage = @AwardImage,
	@Id_update = @ID
	WHERE id_award = @ID
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetAwardByID --11
	@ID int
AS
BEGIN
	SELECT [id_award]
      ,[Title]
      ,[Description]
	  ,[AwardImage]
  FROM [Olympics].[dbo].[Award]
  WHERE id_award = @ID
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE DeleteAward --12
	@ID int
AS
BEGIN
	DELETE FROM [dbo].[Award]
      WHERE id_award = @ID

	SELECT SCOPE_IDENTITY()
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetAwardByLetter --13 
	@LETTER char(1)
AS
BEGIN
	SELECT [id_award]
      ,[Title]
      ,[Description]
	  ,AwardImage
  FROM [Olympics].[dbo].[Award]
  WHERE [Title] LIKE @LETTER + '%'
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Pasha>
-- Create date: <09.07.2018 15:20>
-- Description:	<>
-- =============================================
CREATE PROCEDURE GetAwardByWord --14
	@WORD nvarchar(200)
AS
BEGIN
	SELECT [id_award]
      ,[Title]
      ,[Description]
	  ,[AwardImage]
	FROM [Olympics].[dbo].[Award]
	WHERE [Title] LIKE (@WORD+'%'+@WORD)
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetAwardByTitle --15
	@TITLE nvarchar(50)
AS
BEGIN
	SELECT [id_award]
      ,[Title]
      ,[Description]
	  ,[AwardImage]
  FROM [Olympics].[dbo].[Award]
  WHERE [Title] LIKE @TITLE
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Rewarding] --16
	@ID_user int,
	@ID_award int,
	@ID_rewarding int OUTPUT
AS
BEGIN
		INSERT INTO [dbo].[User_Award]
           ([id_user]
           ,[id_award])
     VALUES
           (@ID_user
           ,@ID_award)

	SET @ID_rewarding = @@IDENTITY
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAwardFromUser_Award] --17 
	@ID_USER int
AS
BEGIN
	SELECT UA.id_award,
	A.Title
	FROM User_Award as UA
	JOIN Award AS A ON UA.id_award = A.id_award
	WHERE id_user = @ID_USER
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE DeleteAwardFromUser
	-- Add the parameters for the stored procedure here
	@UserId int,
	@AwardId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete From User_Award
	WHERE id_user = @UserId AND id_award = @AwardId
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE DeleteAwardFromAllUsers
	-- Add the parameters for the stored procedure here
	@AwardId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete From User_Award
	Where id_award = @AwardId
END
GO

CREATE PROCEDURE GetCurrentDate
AS
BEGIN
 SELECT GETDATE()
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddAccount]
	@Email nvarchar(250),
	@Password nvarchar(500),
	@Role nvarchar(150),
	@Id_user int,
	@CreatedAt datetime,
	@LoggedInto datetime,
	@PasswordLifetime datetime,
	@IsBlocked bit,
	@Id_account int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Account(
		[Email],
		[Password],
		[Role],
		[CreatedAt],
		[LoggedInto],
		[PasswordLifetime],
		[IsBlocked],
		[id_user]
	)
	VALUES(
		@Email,
		@Password,
		@Role,
		@CreatedAt,
		@LoggedInto,
		@PasswordLifetime,
		@IsBlocked,
		@Id_user
	)

	SET @Id_account = @@IDENTITY
END

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE UpdateAccount
	@Email nvarchar(250),
	@Password nvarchar(500),
	@Role nvarchar(150),
	@IsBlocked bit,
	@Id_user int
AS
BEGIN
	UPDATE Olympics.dbo.Account
	SET Email = @Email,
	[Password] = @Password,
	[Role] = @Role,
	IsBlocked = @IsBlocked
	WHERE id_user = @Id_user
END
GO

CREATE PROCEDURE UpdateLoggedIntoAccount
	@Id_user int,
	@LoggedInto datetime
AS
BEGIN
	Update dbo.Account
	SET LoggedInto = @LoggedInto
	WHERE id_user = id_account
END
GO

CREATE PROCEDURE UpdatePasswordLifetimeAccount
	@Id_user int,
	@PasswordLifetime datetime
AS
BEGIN
	Update Account
	SET PasswordLifetime = @PasswordLifetime
	WHERE id_user = @Id_user
END
GO

CREATE PROCEDURE DeleteAccount
	@Id_user int
AS
BEGIN
	DELETE FROM Account
	WHERE id_user = @Id_user
END
GO

CREATE PROCEDURE GetAccountByEmail
	@Email nvarchar(250)
AS
BEGIN
	SELECT id_account,
		id_user,
		Email,
		[Password],
		[Role],
		[CreatedAt],
		[LoggedInto],
		[PasswordLifetime],
		id_user,
		[IsBlocked]
	FROM Account
	WHERE Email = @Email
END
GO

CREATE PROCEDURE GetAccountByIdUser
	@Id_user int
AS
BEGIN
	SELECT id_account,
		id_user,
		Email,
		[Password],
		[Role],
		[CreatedAt],
		[LoggedInto],
		[PasswordLifetime],
		id_user,
		[IsBlocked]
	FROM Account
	WHERE id_user = @Id_user
END