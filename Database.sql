USE [master]
GO
/****** Object:  Database [CalendarThematicPlan]    Script Date: 08.10.2019 01:44:30  ******/
CREATE DATABASE [CalendarThematicPlan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CalendarThematicPlan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS01\MSSQL\DATA\CalendarThematicPlan.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CalendarThematicPlan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS01\MSSQL\DATA\CalendarThematicPlan_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CalendarThematicPlan] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CalendarThematicPlan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CalendarThematicPlan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET ARITHABORT OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CalendarThematicPlan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CalendarThematicPlan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CalendarThematicPlan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CalendarThematicPlan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CalendarThematicPlan] SET  MULTI_USER 
GO
ALTER DATABASE [CalendarThematicPlan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CalendarThematicPlan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CalendarThematicPlan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CalendarThematicPlan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CalendarThematicPlan] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CalendarThematicPlan] SET QUERY_STORE = OFF
GO
USE [CalendarThematicPlan]
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
USE [CalendarThematicPlan]
GO
/****** Object:  Table [dbo].[Grade]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[Letter] [nvarchar](10) NOT NULL,
	[KidsInClass] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[ActualDate] [datetime] NOT NULL,
	[Room] [nvarchar](10) NOT NULL,
	[id_subject] [int] NOT NULL,
	[id_grade] [int] NOT NULL,
	[id_user] [int] NOT NULL,
	[LessonTopic] [nvarchar](30) NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK__Schedule__3213E83F7635F016] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Hours] [int] NOT NULL,
 CONSTRAINT [PK__Subject__3213E83F3696D44E] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[LastName] [nvarchar](250) NOT NULL,
	[Patronymic] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](500) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[Role] [nvarchar](100) NOT NULL,
	[Position] [nvarchar](100) NOT NULL,
	[UserPhoto] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Subject]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Subject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NOT NULL,
	[id_subject] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK__Schedule__id_gra__68487DD7] FOREIGN KEY([id_grade])
REFERENCES [dbo].[Grade] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK__Schedule__id_gra__68487DD7]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK__Schedule__id_sub__6754599E] FOREIGN KEY([id_subject])
REFERENCES [dbo].[Subject] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK__Schedule__id_sub__6754599E]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK__Schedule__id_use__693CA210] FOREIGN KEY([id_user])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK__Schedule__id_use__693CA210]
GO
ALTER TABLE [dbo].[User_Subject]  WITH CHECK ADD  CONSTRAINT [FK__User_Subj__id_su__6477ECF3] FOREIGN KEY([id_subject])
REFERENCES [dbo].[Subject] ([id])
GO
ALTER TABLE [dbo].[User_Subject] CHECK CONSTRAINT [FK__User_Subj__id_su__6477ECF3]
GO
ALTER TABLE [dbo].[User_Subject]  WITH CHECK ADD FOREIGN KEY([id_user])
REFERENCES [dbo].[User] ([id])
GO
/****** Object:  StoredProcedure [dbo].[AddGrade]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddGrade]
	@Number int,
	@Letter nvarchar(10),
	@KidsInClass int,
	@Id_output int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [Grade]
	(
		Number,
		Letter,
		KidsInClass
	)
	VALUES
	(
		@Number,
		@Letter,
		@KidsInClass
	)

	SET @Id_output = @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[AddSchedule]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddSchedule]
	-- Add the parameters for the stored procedure here
	@Date datetime,
	@ActualDate datetime,
	@Room nvarchar(10),
	@Id_subject int,
	@Id_grade int,
	@Id_user int,
	@LessonTopic nvarchar(30),
	@Comment nvarchar(MAX),
	@Id_output int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [Schedule]
	(
		[Date],
		ActualDate,
		Room,
		id_subject,
		id_grade,
		id_user,
		LessonTopic,
		Comment
	)
	VALUES
	(
		@Date,
		@ActualDate,
		@Room,
		@Id_subject,
		@Id_grade,
		@Id_user,
		@LessonTopic,
		@Comment
	)

	SET @Id_output = @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[AddSubject]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddSubject]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(250),
	@Hours int,
	@Id_output int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [Subject]
	(
		[Name],
		[Hours]
	)
	VALUES
	(
		@Name,
		@Hours
	)

	SET @Id_output = @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddUser]
	-- Add the parameters for the stored procedure here
	@FirstName nvarchar(250),
	@LastName nvarchar(250),
	@Patronymic nvarchar(250),
	@Email nvarchar(500),
	@Password nvarchar(250),
	@Role nvarchar(100),
	@Position nvarchar(100),
	@UserPhoto varbinary(MAX),
	@Id_output int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [User]
	(
		FirstName,
		LastName,
		Patronymic,
		Email,
		[Password],
		[Role],
		Position,
		UserPhoto
	)
	VALUES
	(	
		@FirstName,
		@LastName,
		@Patronymic,
		@Email,
		@Password,
		@Role,
		@Position,
		@UserPhoto
	)

	SET @Id_output = @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[AddUserSubject]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddUserSubject]
	-- Add the parameters for the stored procedure here
	@Id_user int,
	@Id_subject int,
	@Id_output int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO User_Subject
	(
		id_user,
		id_subject
	)
	VALUES
	(
		@Id_user,
		@Id_subject
	)

	SET @Id_output = @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteGrade]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteGrade]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [Grade]
	WHERE id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteSchedule]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteSchedule]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [Schedule]
	WHERE id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteSubject]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteSubject]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [Subject]
	WHERE id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUser]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [User]
	WHERE id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteUserSubject]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUserSubject]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [User_Subject]
	WHERE id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[GetGradeById]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetGradeById]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Number,
		Letter,
		KidsInClass
	FROM Grade
	WHERE id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[GetGrades]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetGrades]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id,
		Number,
		Letter,
		KidsInClass
	FROM Grade
END

GO
/****** Object:  StoredProcedure [dbo].[GetReadableScheduleById]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetReadableScheduleById]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT	sch.id as 'Id',
		sch.[Date] as 'Date',
		sch.ActualDate as 'Actual date',
		sch.Room as 'Room',
		g.Number as 'Grade number',
		g.Letter as 'Grade letter',
		s.[Name] as 'Subject name',
		u.LastName as 'Teacher last name',
		u.FirstName as 'Teacher first name',
		u.Patronymic as 'Teacher patronymic',
		sch.LessonTopic as 'Lesson Topic',
		sch.Comment as 'Comment'
FROM Schedule as sch
JOIN Grade as g ON g.id = sch.id_grade
JOIN [Subject] as s ON s.id = sch.id_subject
JOIN [User] as u ON u.id = sch.id_user
WHERE sch.id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[GetReadableSchedules]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetReadableSchedules]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT	sch.id as 'Id',
		sch.[Date] as 'Date',
		sch.ActualDate as 'Actual date',
		sch.Room as 'Room',
		g.Number as 'Grade number',
		g.Letter as 'Grade letter',
		s.[Name] as 'Subject name',
		u.LastName as 'Teacher last name',
		u.FirstName as 'Teacher first name',
		u.Patronymic as 'Teacher patronymic',
		sch.LessonTopic as 'Lesson Topic',
		sch.Comment as 'Comment'
FROM Schedule as sch
JOIN Grade as g ON g.id = sch.id_grade
JOIN [Subject] as s ON s.id = sch.id_subject
JOIN [User] as u ON u.id = sch.id_user
END

GO
/****** Object:  StoredProcedure [dbo].[GetReadableSchedulesByParameters]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetReadableSchedulesByParameters]
	-- Add the parameters for the stored procedure here
	@UserFirstName nvarchar = '',
	@UserLastName nvarchar = '',
	@UserPatronymic nvarchar = '',
	@SubjectName nvarchar = '',
	@GradeNumber int = null,
	@GradeLetter nvarchar = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT sch.id as 'Id',
		sch.[Date] as 'Date',
		sch.ActualDate as 'Actual date',
		sch.Room as 'Room',
		g.Number as 'Grade number',
		g.Letter as 'Grade letter',
		s.[Name] as 'Subject name',
		u.LastName as 'Teacher last name',
		u.FirstName as 'Teacher first name',
		u.Patronymic as 'Teacher patronymic',
		sch.LessonTopic as 'Lesson Topic',
		sch.Comment as 'Comment'
FROM Schedule as sch
JOIN Grade as g ON g.id = sch.id_grade
JOIN [Subject] as s ON s.id = sch.id_subject
JOIN [User] as u ON u.id = sch.id_user
WHERE u.FirstName LIKE @UserFirstName + '%'
OR u.LastName LIKE @UserLastName + '%'
OR u.Patronymic LIKE @UserPatronymic + '%'
OR s.[Name] LIKE @SubjectName + '%'
OR (g.Number = @GradeNumber AND g.Letter = @GradeLetter)
END

GO
/****** Object:  StoredProcedure [dbo].[GetScheduleById]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetScheduleById] 
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Date]
      ,[ActualDate]
      ,[Room]
      ,[id_subject]
      ,[id_grade]
      ,[id_user]
      ,[LessonTopic]
      ,[Comment]
	FROM Schedule
	WHERE id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[GetSchedules]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSchedules]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id,
		[Date]
      ,[ActualDate]
      ,[Room]
      ,[id_subject]
      ,[id_grade]
      ,[id_user]
      ,[LessonTopic]
      ,[Comment]
	FROM Schedule
END

GO
/****** Object:  StoredProcedure [dbo].[GetSubjectById]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSubjectById]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Name]
      ,[Hours]
	FROM [Subject]
	WHERE id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[GetSubjects]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSubjects]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id
		,[Name]
      ,[Hours]
	FROM [Subject]
END

GO
/****** Object:  StoredProcedure [dbo].[GetSubjectsByUser]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSubjectsByUser] 
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT s.id
		,[Name]
      ,[Hours]
	FROM [Subject] as s
	JOIN User_Subject as us ON us.id_subject = s.id
	WHERE us.id_user = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[GetSubjectsByWord]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSubjectsByWord]
	-- Add the parameters for the stored procedure here
	@Word nvarchar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id
		,[Name]
      ,[Hours]
	FROM [Subject]
	WHERE [Name] LIKE @Word + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserByEmail]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserByEmail]
	-- Add the parameters for the stored procedure here
	@Email nvarchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id,
		FirstName,
	LastName,
	Patronymic,
	Email,
	[Password],
	[Role],
	Position,
	UserPhoto
	FROM [User]
	WHERE Email = @Email
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserById]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT FirstName,
	LastName,
	Patronymic,
	Email,
	[Password],
	[Role],
	Position,
	UserPhoto
	FROM [User]
	WHERE id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUsers]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id,
		FirstName,
	LastName,
	Patronymic,
	Email,
	[Password],
	[Role],
	Position,
	UserPhoto
	FROM [User]
END

GO
/****** Object:  StoredProcedure [dbo].[GetUsersBySubject]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUsersBySubject]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT u.id,
		FirstName,
	LastName,
	Patronymic,
	Email,
	[Password],
	[Role],
	Position,
	UserPhoto
	FROM [User] as u
	JOIN User_Subject as us ON u.id = us.id_user
	WHERE us.id_subject = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[GetUsersByWord]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUsersByWord]
	-- Add the parameters for the stored procedure here
	@Word nvarchar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id,
		FirstName,
	LastName,
	Patronymic,
	Email,
	[Password],
	[Role],
	Position,
	UserPhoto
	FROM [User]
	WHERE FirstName LIKE @Word + '%' 
	OR LastName LIKE @Word + '%'
	OR Patronymic LIKE @Word + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserSubjectById]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserSubjectById]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id_user,
	id_subject
	FROM User_Subject
	WHERE id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserSubjects]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserSubjects]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id,
		id_user,
	id_subject
	FROM [User_Subject]
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateGrade]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateGrade]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Number int,
	@Letter nvarchar(10),
	@KidsInClass int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Grade
	SET Number = @Number,
	Letter = @Letter,
	KidsInClass = @KidsInClass
	WHERE id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateSchedule]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateSchedule]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Date datetime,
	@ActualDate datetime,
	@Room nvarchar(10),
	@Id_subject int,
	@Id_grade int,
	@Id_user int,
	@LessonTopic nvarchar(30),
	@Comment nvarchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Schedule
	SET [Date] = @Date,
	ActualDate = @ActualDate,
	Room = @Room,
	id_subject = @Id_subject,
	id_grade = @Id_grade,
	id_user = @Id_user,
	LessonTopic = @LessonTopic,
	Comment = @Comment
	WHERE id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateSubject]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateSubject]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Name nvarchar(250),
	@Hours int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [Subject]
	SET [Name] = @Name,
	[Hours] = @Hours 
	WHERE id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateUser]
	-- Add the parameters for the stored procedure here
	@Id int,
	@FirstName nvarchar(250),
	@LastName nvarchar(250),
	@Patronymic nvarchar(250),
	@Email nvarchar(500),
	@Password nvarchar(250),
	@Role nvarchar(100),
	@Position nvarchar(100),
	@UserPhoto varbinary(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [User]
	SET FirstName = @FirstName,
	LastName = @LastName,
	Patronymic = @Patronymic,
	Email = @Email,
	[Password] = @Password,
	[Role] = @Role,
	Position = @Position,
	UserPhoto = @UserPhoto
	WHERE id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateUserSubject]    Script Date: 08.10.2019 01:44:30  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateUserSubject]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Id_user int,
	@Id_subject int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [User_Subject]
	SET id_user = @Id_user,
	id_subject = @Id_subject
	WHERE id = @Id
END

GO
USE [master]
GO
ALTER DATABASE [CalendarThematicPlan] SET  READ_WRITE 
GO
