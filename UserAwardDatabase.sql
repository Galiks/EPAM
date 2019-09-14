USE [master]
GO
/****** Object:  Database [Olympics]    Script Date: 13.09.2019 21:57:19  ******/
CREATE DATABASE [Olympics]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Olympics', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS01\MSSQL\DATA\Olympics.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Olympics_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS01\MSSQL\DATA\Olympics_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
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
/****** Object:  Table [dbo].[Award]    Script Date: 13.09.2019 21:57:20  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[id_award] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](250) NULL,
	[AwardImage] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[id_award] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 13.09.2019 21:57:20  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Birthday] [date] NOT NULL,
	[Age] [int] NOT NULL,
	[UserPhoto] [varbinary](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Award]    Script Date: 13.09.2019 21:57:20  ******/
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
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 13.09.2019 21:57:20  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAward] --8
	@TITLE varchar(50),
	@DESCRIPTION varchar(300)
AS
BEGIN
	INSERT INTO [dbo].[Award]
           ([Title]
           ,[Description])
     VALUES
           (@TITLE,
		   @DESCRIPTION)

	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 13.09.2019 21:57:20  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[AddUser] --1
	@Name varchar(50),
	@Birthday date,
	@Age int
AS
BEGIN
	INSERT INTO [dbo].[User]
           ([Name]
           ,[Birthday]
           ,[Age])
     VALUES
           (@Name, @Birthday, @Age)

	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteAward]    Script Date: 13.09.2019 21:57:20  ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 13.09.2019 21:57:20  ******/
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
/****** Object:  StoredProcedure [dbo].[GetAwardByID]    Script Date: 13.09.2019 21:57:20  ******/
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
  FROM [Olympics].[dbo].[Award]
  WHERE id_award = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[GetAwardByLetter]    Script Date: 13.09.2019 21:57:20  ******/
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
  FROM [Olympics].[dbo].[Award]
  WHERE [Title] LIKE @LETTER + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[GetAwardByTitle]    Script Date: 13.09.2019 21:57:20  ******/
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
	@TITLE varchar(50)
AS
BEGIN
	SELECT [id_award]
      ,[Title]
      ,[Description]
  FROM [Olympics].[dbo].[Award]
  WHERE [Title] LIKE @TITLE
END

GO
/****** Object:  StoredProcedure [dbo].[GetAwardByWord]    Script Date: 13.09.2019 21:57:20  ******/
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
	@WORD varchar(200)
AS
BEGIN
	SELECT TOP (1000) [id_award]
      ,[Title]
      ,[Description]
	FROM [Olympics].[dbo].[Award]
	WHERE [Title] LIKE (@WORD+'%'+@WORD)
END

GO
/****** Object:  StoredProcedure [dbo].[GetAwardFromUser_Award]    Script Date: 13.09.2019 21:57:20  ******/
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
/****** Object:  StoredProcedure [dbo].[GetAwards]    Script Date: 13.09.2019 21:57:20  ******/
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
  FROM [Olympics].[dbo].[Award]
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserByID]    Script Date: 13.09.2019 21:57:20  ******/
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
  FROM [Olympics].[dbo].[User]
  WHERE [id_user] = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserByLetter]    Script Date: 13.09.2019 21:57:20  ******/
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
  FROM [Olympics].[dbo].[User]
  WHERE [Name] LIKE @LETTER + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserByName]    Script Date: 13.09.2019 21:57:20  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserByName] --4
	@NAME varchar(200)
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Birthday]
      ,[Age]
  FROM [Olympics].[dbo].[User]
  WHERE [Name] LIKE @NAME
  Order By Age Desc
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserByWord]    Script Date: 13.09.2019 21:57:20  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserByWord]--6
	@WORD varchar(200)
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Birthday]
      ,[Age]
  FROM [Olympics].[dbo].[User]
  WHERE [Name] LIKE (@WORD+'%'+@WORD)
END

GO
/****** Object:  StoredProcedure [dbo].[Rewarding]    Script Date: 13.09.2019 21:57:20  ******/
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
	@ID_award int
AS
BEGIN
		INSERT INTO [dbo].[User_Award]
           ([id_user]
           ,[id_award])
     VALUES
           (@ID_user
           ,@ID_award)

	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateAward]    Script Date: 13.09.2019 21:57:20  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAward] --10
	@ID int,
	@TITLE varchar(50),
	@DESCRIPTION varchar(300) = 'Îïèñàíèå îòñóòñòâóåò'
AS
BEGIN
	UPDATE Olympics.dbo.Award
	SET Title = @TITLE,
	[Description] = @DESCRIPTION
	WHERE id_award = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 13.09.2019 21:57:20  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser]--7
	@ID int,
	@NAME varchar(100),
	@BIRTHDAY date,
	@AGE int
AS
BEGIN
	UPDATE Olympics.dbo.[User]
	SET 
	[Name] = @NAME,
	Birthday = @BIRTHDAY,
	Age = @AGE
	WHERE id_user = @ID
END

GO
USE [master]
GO
ALTER DATABASE [Olympics] SET  READ_WRITE 
GO
