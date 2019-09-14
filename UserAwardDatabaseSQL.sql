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
	[Name] varchar(50) NOT NULL,
	Birthday date NOT NULL,
	Age int NOT NULL,
	[Email] varchar(250) unique NOT NULL,
	[Password] varchar(500) NOT NULL,
	UserPhoto varbinary(MAX)
)
GO
CREATE TABLE Award (
	id_award int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Award] primary key,
	Title varchar(50) NOT NULL,
	[Description] varchar(250),
	AwardImage varbinary(MAX)
)
GO

CREATE TABLE User_Award (
	id int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_User_Award] primary key,
	id_user int NOT NULL,
	id_award int NOT NULL
)
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
	@Name varchar(50),
	@Birthday date,
	@Age int,
	@Email varchar(250),
	@Password varchar(500),
	@UserPhoto varbinary(MAX)
AS
BEGIN
	INSERT INTO [dbo].[User]
           ([Name]
           ,[Birthday]
           ,[Age]
		   ,[Email]
		   ,[Password]
		   ,[UserPhoto])
     VALUES
           (@Name,
		    @Birthday, 
			@Age, 
			@Email,
			@Password,
			@UserPhoto)

	SELECT SCOPE_IDENTITY()
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
	  ,[Email]
	  ,[Password]
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
	@NAME varchar(200)
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Birthday]
      ,[Age]
	  ,[Email]
	  ,[Password]
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
	  ,[Email]
	  ,[Password]
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
	@WORD varchar(200)
AS
BEGIN
	SELECT [id_user]
      ,[Name]
      ,[Birthday]
      ,[Age]
	  ,[Email]
	  ,[Password]
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
	@NAME varchar(100),
	@BIRTHDAY date,
	@AGE int,
	@Email varchar(250),
	@Password varchar(500),
	@UserPhoto varbinary(MAX)
AS
BEGIN
	UPDATE Olympics.dbo.[User]
	SET 
	[Name] = @NAME,
	Birthday = @BIRTHDAY,
	Age = @AGE,
	Email = @Email,
	[Password] = @Password,
	UserPhoto = @UserPhoto
	WHERE id_user = @ID
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE AddAward --8
	@TITLE varchar(50),
	@DESCRIPTION varchar(300),
	@AwardImage varbinary(MAX)
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

	SELECT SCOPE_IDENTITY()
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
	@TITLE varchar(50),
	@DESCRIPTION varchar(300) = 'Empty Description',
	@AwardImage varbinary(MAX)
AS
BEGIN
	UPDATE Olympics.dbo.Award
	SET Title = @TITLE,
	[Description] = @DESCRIPTION,
	AwardImage = @AwardImage
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
	@WORD varchar(200)
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
	@TITLE varchar(50)
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
