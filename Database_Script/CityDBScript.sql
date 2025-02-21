USE [ltpe5.TCAA]
GO
/****** Object:  Table [dbo].[Core_8_0_Cities]    Script Date: 22-04-2024 10:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Core_8_0_Cities](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](50) NOT NULL,
	[CityDescription] [nvarchar](200) NOT NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_Core_8_0_Cities] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Core_8_0_CityLanguages]    Script Date: 22-04-2024 10:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Core_8_0_CityLanguages](
	[CityId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
 CONSTRAINT [PK_Core_8_0_CityLanguages] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC,
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Core_8_0_Countries]    Script Date: 22-04-2024 10:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Core_8_0_Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Core_8_0_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Core_8_0_Languages]    Script Date: 22-04-2024 10:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Core_8_0_Languages](
	[LanguageId] [int] IDENTITY(1,1) NOT NULL,
	[LanguageName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Core_8_0_Languages] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Core_8_0_PointsOfInterest]    Script Date: 22-04-2024 10:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Core_8_0_PointsOfInterest](
	[PointOfInterestId] [int] IDENTITY(1,1) NOT NULL,
	[PointOfInterestName] [nvarchar](50) NOT NULL,
	[PointOfInterestDescription] [nvarchar](200) NOT NULL,
	[CityId] [int] NOT NULL,
 CONSTRAINT [PK_Core_8_0_PointsOfInterest] PRIMARY KEY CLUSTERED 
(
	[PointOfInterestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Core_8_0_Cities] ON 

INSERT [dbo].[Core_8_0_Cities] ([CityId], [CityName], [CityDescription], [CountryID]) VALUES (1, N'Gudumholm', N'Østhimmerlands Perle', 1)
INSERT [dbo].[Core_8_0_Cities] ([CityId], [CityName], [CityDescription], [CountryID]) VALUES (2, N'London', N'Byen ved Themsen', 2)
INSERT [dbo].[Core_8_0_Cities] ([CityId], [CityName], [CityDescription], [CountryID]) VALUES (3, N'Hamburg', N'Byen ved Elben', 3)
INSERT [dbo].[Core_8_0_Cities] ([CityId], [CityName], [CityDescription], [CountryID]) VALUES (5, N'Aalborg', N'Dobbelt A', 1)
SET IDENTITY_INSERT [dbo].[Core_8_0_Cities] OFF
GO
INSERT [dbo].[Core_8_0_CityLanguages] ([CityId], [LanguageId]) VALUES (1, 1)
INSERT [dbo].[Core_8_0_CityLanguages] ([CityId], [LanguageId]) VALUES (5, 1)
INSERT [dbo].[Core_8_0_CityLanguages] ([CityId], [LanguageId]) VALUES (1, 2)
INSERT [dbo].[Core_8_0_CityLanguages] ([CityId], [LanguageId]) VALUES (2, 2)
INSERT [dbo].[Core_8_0_CityLanguages] ([CityId], [LanguageId]) VALUES (3, 2)
INSERT [dbo].[Core_8_0_CityLanguages] ([CityId], [LanguageId]) VALUES (2, 3)
INSERT [dbo].[Core_8_0_CityLanguages] ([CityId], [LanguageId]) VALUES (3, 3)
INSERT [dbo].[Core_8_0_CityLanguages] ([CityId], [LanguageId]) VALUES (5, 3)
GO
SET IDENTITY_INSERT [dbo].[Core_8_0_Countries] ON 

INSERT [dbo].[Core_8_0_Countries] ([CountryID], [CountryName]) VALUES (1, N'Danmark')
INSERT [dbo].[Core_8_0_Countries] ([CountryID], [CountryName]) VALUES (2, N'England')
INSERT [dbo].[Core_8_0_Countries] ([CountryID], [CountryName]) VALUES (3, N'Tyskland')
SET IDENTITY_INSERT [dbo].[Core_8_0_Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Core_8_0_Languages] ON 

INSERT [dbo].[Core_8_0_Languages] ([LanguageId], [LanguageName]) VALUES (1, N'Dansk')
INSERT [dbo].[Core_8_0_Languages] ([LanguageId], [LanguageName]) VALUES (2, N'Engelsk')
INSERT [dbo].[Core_8_0_Languages] ([LanguageId], [LanguageName]) VALUES (3, N'Tysk')
INSERT [dbo].[Core_8_0_Languages] ([LanguageId], [LanguageName]) VALUES (5, N'Fransk')
SET IDENTITY_INSERT [dbo].[Core_8_0_Languages] OFF
GO
SET IDENTITY_INSERT [dbo].[Core_8_0_PointsOfInterest] ON 

INSERT [dbo].[Core_8_0_PointsOfInterest] ([PointOfInterestId], [PointOfInterestName], [PointOfInterestDescription], [CityId]) VALUES (1, N'Gudumholm Stadion', N'Her har Lars Pedersen spillet mange store kampe !!!', 1)
INSERT [dbo].[Core_8_0_PointsOfInterest] ([PointOfInterestId], [PointOfInterestName], [PointOfInterestDescription], [CityId]) VALUES (2, N'Wembley', N'Har vandt England VM i 1966', 2)
INSERT [dbo].[Core_8_0_PointsOfInterest] ([PointOfInterestId], [PointOfInterestName], [PointOfInterestDescription], [CityId]) VALUES (3, N'Volkpark Stadion', N'Hjemmebane for HSV', 3)
INSERT [dbo].[Core_8_0_PointsOfInterest] ([PointOfInterestId], [PointOfInterestName], [PointOfInterestDescription], [CityId]) VALUES (4, N'Aalborg Tårnet ', N'Bygget i 1933', 5)
SET IDENTITY_INSERT [dbo].[Core_8_0_PointsOfInterest] OFF
GO
ALTER TABLE [dbo].[Core_8_0_Cities]  WITH CHECK ADD  CONSTRAINT [FK_Core_8_0_Cities_Core_8_0_Countries_CountryID] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Core_8_0_Countries] ([CountryID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Core_8_0_Cities] CHECK CONSTRAINT [FK_Core_8_0_Cities_Core_8_0_Countries_CountryID]
GO
ALTER TABLE [dbo].[Core_8_0_CityLanguages]  WITH CHECK ADD  CONSTRAINT [FK_Core_8_0_CityLanguages_Core_8_0_Cities_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Core_8_0_Cities] ([CityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Core_8_0_CityLanguages] CHECK CONSTRAINT [FK_Core_8_0_CityLanguages_Core_8_0_Cities_CityId]
GO
ALTER TABLE [dbo].[Core_8_0_CityLanguages]  WITH CHECK ADD  CONSTRAINT [FK_Core_8_0_CityLanguages_Core_8_0_Languages_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Core_8_0_Languages] ([LanguageId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Core_8_0_CityLanguages] CHECK CONSTRAINT [FK_Core_8_0_CityLanguages_Core_8_0_Languages_LanguageId]
GO
ALTER TABLE [dbo].[Core_8_0_PointsOfInterest]  WITH CHECK ADD  CONSTRAINT [FK_Core_8_0_PointsOfInterest_Core_8_0_Cities_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Core_8_0_Cities] ([CityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Core_8_0_PointsOfInterest] CHECK CONSTRAINT [FK_Core_8_0_PointsOfInterest_Core_8_0_Cities_CityId]
GO
