USE [UserManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Users](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](200) NOT NULL
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Profile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] FOREIGN KEY REFERENCES Users(Id),
	[ProfileName] [varchar](100) NOT NULL,
	[ProfileDescription] [varchar](250) NOT NULL
	CONSTRAINT FK_UserId FOREIGN KEY (UserId)
    REFERENCES Users(Id)
	)
GO
