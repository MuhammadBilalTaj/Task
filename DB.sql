USE [master]
GO
/****** Object:  Database [Now]    Script Date: 12/8/2021 7:59:29 PM ******/
CREATE DATABASE [Now]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Now', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Now.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Now_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Now_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Now] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Now].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Now] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Now] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Now] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Now] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Now] SET ARITHABORT OFF 
GO
ALTER DATABASE [Now] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Now] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Now] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Now] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Now] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Now] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Now] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Now] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Now] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Now] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Now] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Now] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Now] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Now] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Now] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Now] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Now] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Now] SET RECOVERY FULL 
GO
ALTER DATABASE [Now] SET  MULTI_USER 
GO
ALTER DATABASE [Now] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Now] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Now] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Now] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Now] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Now', N'ON'
GO
USE [Now]
GO
/****** Object:  Table [dbo].[Task_User]    Script Date: 12/8/2021 7:59:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Task_User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[UserName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[MobileNumber] [varchar](50) NULL,
	[Role] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Task_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_GetUserByID]    Script Date: 12/8/2021 7:59:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetUserByID]
@ID INT
AS

BEGIN
SELECT * FROM dbo.Task_User WHERE Id=@ID
END

GO
/****** Object:  StoredProcedure [dbo].[SP_InsertUser]    Script Date: 12/8/2021 7:59:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertUser]
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@UserName VARCHAR(50),
@Email VARCHAR(50),
@MobileNumber VARCHAR(50),
@IsActive bit
AS
BEGIN
INSERT INTO dbo.Task_User
        ( FirstName ,
          LastName ,
          UserName ,
          Email ,         
          MobileNumber ,          
          IsActive
        )
VALUES  ( @FirstName , 
          @LastName , 
          @UserName , 
          @Email ,          
          @MobileNumber ,           
          @IsActive  
        )
end
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateUser]    Script Date: 12/8/2021 7:59:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateUser]
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@UserName VARCHAR(50),
@Email VARCHAR(50),
@MobileNumber VARCHAR(50),
@IsActive BIT,
@ID INT
AS
BEGIN
UPDATE dbo.Task_User SET
         FirstName=@FirstName ,
          LastName=@LastName ,
          --UserName=@UserName ,
          Email=@Email ,         
          MobileNumber=@MobileNumber ,          
          IsActive=@IsActive

		  WHERE Id=@ID
        






end
GO
USE [master]
GO
ALTER DATABASE [Now] SET  READ_WRITE 
GO
