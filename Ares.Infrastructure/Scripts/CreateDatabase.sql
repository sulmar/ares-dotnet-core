USE [master]
GO

/****** Object:  Database [AresDb]    Script Date: 23.07.2020 12:07:18 ******/
CREATE DATABASE [AresDb]

GO


USE [AresDb]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 23.07.2020 12:08:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[HashedPassword] [nvarchar](50) NULL,
	[Email] [nvarchar](250) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[IsLocked] [bit] NOT NULL,
	[HomeAddressId] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [AresDb]
GO

/****** Object:  Table [dbo].[Addresses]    Script Date: 23.07.2020 12:08:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](50) NULL,
	[Street] [nvarchar](50) NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


  create procedure [dbo].[uspUserAuthorize](
              @UserId nvarchar(50),
			  @HashedPassword nvarchar(50)
             )
             as 
             begin
				select top(1) * from dbo.Users where UserId = @UserId and HashedPassword = @HashedPassword
             end

GO
