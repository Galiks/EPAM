USE [master]
GO
/****** Object:  Database [Olympics]    Script Date: 23.09.2019 13:55:46  ******/
CREATE DATABASE [Olympics]

ALTER DATABASE [Olympics] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Olympics].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Olympics] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Olympics] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Olympics] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Olympics] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Olympics] SET ARITHABORT OFF 
GO
ALTER DATABASE [Olympics] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Olympics] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Olympics] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Olympics] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Olympics] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Olympics] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Olympics] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Olympics] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Olympics] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Olympics] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Olympics] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Olympics] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Olympics] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Olympics] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Olympics] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Olympics] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Olympics] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Olympics] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Olympics] SET  MULTI_USER 
GO
ALTER DATABASE [Olympics] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Olympics] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Olympics] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Olympics] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Olympics] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Olympics] SET QUERY_STORE = OFF
GO
USE [Olympics]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Olympics]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id_account] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](500) NOT NULL,
	[Role] [nvarchar](150) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[LoggedInto] [datetime] NOT NULL,
	[PasswordLifetime] [datetime] NOT NULL,
	[IsBlocked] [bit] NOT NULL,
	[id_user] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[id_account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Award]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[id_award] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[AwardImage] [varbinary](max) NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[id_award] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Birthday] [date] NOT NULL,
	[Age] [int] NOT NULL,
	[UserPhoto] [varbinary](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Award]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Award](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NOT NULL,
	[id_award] [int] NOT NULL,
 CONSTRAINT [PK_User_Award] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_TO_User] FOREIGN KEY([id_user])
REFERENCES [dbo].[User] ([id_user])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_TO_User]
GO
ALTER TABLE [dbo].[User_Award]  WITH CHECK ADD  CONSTRAINT [FK_User_Award_TO_Award] FOREIGN KEY([id_award])
REFERENCES [dbo].[Award] ([id_award])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User_Award] CHECK CONSTRAINT [FK_User_Award_TO_Award]
GO
ALTER TABLE [dbo].[User_Award]  WITH CHECK ADD  CONSTRAINT [FK_User_Award_TO_User] FOREIGN KEY([id_user])
REFERENCES [dbo].[User] ([id_user])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User_Award] CHECK CONSTRAINT [FK_User_Award_TO_User]
GO
/****** Object:  StoredProcedure [dbo].[AddAccount]    Script Date: 23.09.2019 13:55:46  ******/
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
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAward] --8
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
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[AddUser] --1
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
/****** Object:  StoredProcedure [dbo].[DeleteAccount]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteAccount]
	@Id_user int
AS
BEGIN
	DELETE FROM Account
	WHERE id_user = @Id_user
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteAward]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteAward] --12
	@ID int
AS
BEGIN
	DELETE FROM [dbo].[Award]
      WHERE id_award = @ID

	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteAwardFromAllUsers]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteAwardFromAllUsers]
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
/****** Object:  StoredProcedure [dbo].[DeleteAwardFromUser]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteAwardFromUser]
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
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser] --2
	@ID int
AS
BEGIN
	DELETE FROM [dbo].[User]
      WHERE [id_user] = @ID

	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[GetAccountByEmail]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAccountByEmail]
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
/****** Object:  StoredProcedure [dbo].[GetAccountByIdUser]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAccountByIdUser]
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

GO
/****** Object:  StoredProcedure [dbo].[GetAwardByID]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardByID] --11
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
/****** Object:  StoredProcedure [dbo].[GetAwardByLetter]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardByLetter] --13 
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
/****** Object:  StoredProcedure [dbo].[GetAwardByTitle]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAwardByTitle] --15
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
/****** Object:  StoredProcedure [dbo].[GetAwardByWord]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Pasha>
-- Create date: <09.07.2018 15:20>
-- Description:	<>
-- =============================================
CREATE PROCEDURE [dbo].[GetAwardByWord] --14
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
/****** Object:  StoredProcedure [dbo].[GetAwardFromUser_Award]    Script Date: 23.09.2019 13:55:46  ******/
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
/****** Object:  StoredProcedure [dbo].[GetAwards]    Script Date: 23.09.2019 13:55:46  ******/
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
/****** Object:  StoredProcedure [dbo].[GetCurrentDate]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCurrentDate]
AS
BEGIN
 SELECT GETDATE()
END

SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[GetUserByID]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserByID] --3
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
/****** Object:  StoredProcedure [dbo].[GetUserByLetter]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserByLetter] --5
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
/****** Object:  StoredProcedure [dbo].[GetUserByName]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserByName] --4
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
/****** Object:  StoredProcedure [dbo].[GetUserByWord]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserByWord]--6
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
/****** Object:  StoredProcedure [dbo].[Rewarding]    Script Date: 23.09.2019 13:55:46  ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateAccount]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateAccount]
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
/****** Object:  StoredProcedure [dbo].[UpdateAward]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAward] --10
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
/****** Object:  StoredProcedure [dbo].[UpdateLoggedIntoAccount]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateLoggedIntoAccount]
	@Id_user int,
	@LoggedInto datetime
AS
BEGIN
	Update dbo.Account
	SET LoggedInto = @LoggedInto
	WHERE id_user = id_account
END

GO
/****** Object:  StoredProcedure [dbo].[UpdatePasswordLifetimeAccount]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdatePasswordLifetimeAccount]
	@Id_user int,
	@PasswordLifetime datetime
AS
BEGIN
	Update Account
	SET PasswordLifetime = @PasswordLifetime
	WHERE id_user = @Id_user
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 23.09.2019 13:55:46  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser]--7
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
USE [master]
GO
ALTER DATABASE [Olympics] SET  READ_WRITE 
GO
