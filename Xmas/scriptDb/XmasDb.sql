USE [master]
GO
/****** Object:  Database [XMasDb]    Script Date: 20-12-18 11:50:52 ******/
CREATE DATABASE [XMasDb]
GO
USE [XMasDb]
GO
/****** Object:  Table [dbo].[Gift]    Script Date: 20-12-18 11:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gift](
	[IdGift] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Picture] [nvarchar](50) NOT NULL,
	[IdGuest] [int] NOT NULL,
 CONSTRAINT [PK_Gift] PRIMARY KEY CLUSTERED 
(
	[IdGift] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Guest]    Script Date: 20-12-18 11:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[IdGuest] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Email] [nvarchar](350) NULL,
	[IsOrganizer] [bit] NULL,
	[Picture] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED 
(
	[IdGuest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Peanut]    Script Date: 20-12-18 11:50:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Peanut](
	[IdGiver] [int] NOT NULL,
	[IdRecipient] [int] NOT NULL,
	[DrawDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Peanut] PRIMARY KEY CLUSTERED 
(
	[IdGiver] ASC,
	[IdRecipient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Gift] ON 

GO
INSERT [dbo].[Gift] ([IdGift], [Title], [Picture], [IdGuest]) VALUES (1, N'Cloche De Noël', N'images/a2.png', 1)
GO
INSERT [dbo].[Gift] ([IdGift], [Title], [Picture], [IdGuest]) VALUES (2, N'Sac Rouge', N'images/a3.png', 2)
GO
INSERT [dbo].[Gift] ([IdGift], [Title], [Picture], [IdGuest]) VALUES (3, N'Set de bougies', N'images/a4.png', 3)
GO
SET IDENTITY_INSERT [dbo].[Gift] OFF
GO
SET IDENTITY_INSERT [dbo].[Guest] ON 

GO
INSERT [dbo].[Guest] ([IdGuest], [FirstName], [LastName], [BirthDate], [Email], [IsOrganizer], [Picture]) VALUES (1, N'Mike', N'Person', CAST(0xA40A0B00 AS Date), N'michael.person@cognitic.be', 0, N'photos/Mike.jpg')
GO
INSERT [dbo].[Guest] ([IdGuest], [FirstName], [LastName], [BirthDate], [Email], [IsOrganizer], [Picture]) VALUES (2, N'Elisa', N'Ingals', CAST(0x76250B00 AS Date), N'elisa@yahoo.fr', 0, N'photos/Elisa.jpg')
GO
INSERT [dbo].[Guest] ([IdGuest], [FirstName], [LastName], [BirthDate], [Email], [IsOrganizer], [Picture]) VALUES (3, N'Olivia', N'NewToneJones', CAST(0xE3040B00 AS Date), N'o.Jhon@gmail.com', 0, N'photos/Olivia.jpg')
GO
INSERT [dbo].[Guest] ([IdGuest], [FirstName], [LastName], [BirthDate], [Email], [IsOrganizer], [Picture]) VALUES (4, N'Justine', N'PtiteGoutte', CAST(0x891D0B00 AS Date), N'J.Pti@goutte.be', 1, N'images/t3.jpg')
GO
INSERT [dbo].[Guest] ([IdGuest], [FirstName], [LastName], [BirthDate], [Email], [IsOrganizer], [Picture]) VALUES (5, N'Eddy', N'Mercx', CAST(0x25F10A00 AS Date), N'Ed@mercx.com', 1, N'images/t2.png')
GO
INSERT [dbo].[Guest] ([IdGuest], [FirstName], [LastName], [BirthDate], [Email], [IsOrganizer], [Picture]) VALUES (6, N'Sylvie', N'Vartane', CAST(0xCE1D0B00 AS Date), N'Sylv@outlook.com', 1, N'images/t1.jpg')
GO
INSERT [dbo].[Guest] ([IdGuest], [FirstName], [LastName], [BirthDate], [Email], [IsOrganizer], [Picture]) VALUES (7, N'Irena', N'Klain', CAST(0xD01E0B00 AS Date), N'I.rena@gmail.com', 1, N'images/t5.png')
GO
SET IDENTITY_INSERT [dbo].[Guest] OFF
GO
ALTER TABLE [dbo].[Guest] ADD  CONSTRAINT [DF_Guest_IsOrganizer]  DEFAULT ((0)) FOR [IsOrganizer]
GO
ALTER TABLE [dbo].[Gift]  WITH CHECK ADD  CONSTRAINT [FK_Gift_Guest] FOREIGN KEY([IdGuest])
REFERENCES [dbo].[Guest] ([IdGuest])
GO
ALTER TABLE [dbo].[Gift] CHECK CONSTRAINT [FK_Gift_Guest]
GO
ALTER TABLE [dbo].[Peanut]  WITH CHECK ADD  CONSTRAINT [FK_Peanut_Guest] FOREIGN KEY([IdGiver])
REFERENCES [dbo].[Guest] ([IdGuest])
GO
ALTER TABLE [dbo].[Peanut] CHECK CONSTRAINT [FK_Peanut_Guest]
GO
ALTER TABLE [dbo].[Peanut]  WITH CHECK ADD  CONSTRAINT [FK_Peanut_Guest1] FOREIGN KEY([IdRecipient])
REFERENCES [dbo].[Guest] ([IdGuest])
GO
ALTER TABLE [dbo].[Peanut] CHECK CONSTRAINT [FK_Peanut_Guest1]
GO
USE [master]
GO
ALTER DATABASE [XMasDb] SET  READ_WRITE 
GO
