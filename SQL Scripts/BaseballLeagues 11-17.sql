USE [master]
GO
/****** Object:  Database [BaseballLeague]    Script Date: 11/17/2015 10:11:20 PM ******/
CREATE DATABASE [BaseballLeague]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BaseballLeague', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\BaseballLeague.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BaseballLeague_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\BaseballLeague_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BaseballLeague] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BaseballLeague].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BaseballLeague] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BaseballLeague] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BaseballLeague] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BaseballLeague] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BaseballLeague] SET ARITHABORT OFF 
GO
ALTER DATABASE [BaseballLeague] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BaseballLeague] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BaseballLeague] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BaseballLeague] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BaseballLeague] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BaseballLeague] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BaseballLeague] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BaseballLeague] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BaseballLeague] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BaseballLeague] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BaseballLeague] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BaseballLeague] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BaseballLeague] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BaseballLeague] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BaseballLeague] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BaseballLeague] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BaseballLeague] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BaseballLeague] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BaseballLeague] SET  MULTI_USER 
GO
ALTER DATABASE [BaseballLeague] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BaseballLeague] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BaseballLeague] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BaseballLeague] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BaseballLeague] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BaseballLeague]
GO
/****** Object:  Table [dbo].[Leagues]    Script Date: 11/17/2015 10:11:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Leagues](
	[LeagueID] [int] IDENTITY(1,1) NOT NULL,
	[LeagueName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_League] PRIMARY KEY CLUSTERED 
(
	[LeagueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Players]    Script Date: 11/17/2015 10:11:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Players](
	[PlayerID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerName] [varchar](50) NOT NULL,
	[JerseyNumber] [int] NOT NULL,
	[PositionID] [int] NOT NULL,
	[BattingAverage] [decimal](18, 5) NOT NULL,
	[YearsPlayed] [int] NOT NULL,
	[TeamID] [int] NOT NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[PlayerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 11/17/2015 10:11:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Positions](
	[PositionID] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 11/17/2015 10:11:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamID] [int] IDENTITY(1,1) NOT NULL,
	[TeamName] [varchar](50) NOT NULL,
	[Manager] [varchar](50) NOT NULL,
	[LeagueID] [int] NOT NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[TeamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Leagues] ON 

INSERT [dbo].[Leagues] ([LeagueID], [LeagueName]) VALUES (1, N'Timothy Kim League')
INSERT [dbo].[Leagues] ([LeagueID], [LeagueName]) VALUES (2, N'Diamond League')
INSERT [dbo].[Leagues] ([LeagueID], [LeagueName]) VALUES (3, N'Ohio League')
INSERT [dbo].[Leagues] ([LeagueID], [LeagueName]) VALUES (4, N'National League')
SET IDENTITY_INSERT [dbo].[Leagues] OFF
SET IDENTITY_INSERT [dbo].[Players] ON 

INSERT [dbo].[Players] ([PlayerID], [PlayerName], [JerseyNumber], [PositionID], [BattingAverage], [YearsPlayed], [TeamID]) VALUES (1, N'Guat', 23, 1, CAST(0.32000 AS Decimal(18, 5)), 1, 2)
INSERT [dbo].[Players] ([PlayerID], [PlayerName], [JerseyNumber], [PositionID], [BattingAverage], [YearsPlayed], [TeamID]) VALUES (2, N'Smith', 2, 2, CAST(0.36000 AS Decimal(18, 5)), 4, 1)
INSERT [dbo].[Players] ([PlayerID], [PlayerName], [JerseyNumber], [PositionID], [BattingAverage], [YearsPlayed], [TeamID]) VALUES (3, N'Cutter', 43, 3, CAST(0.40000 AS Decimal(18, 5)), 3, 2)
INSERT [dbo].[Players] ([PlayerID], [PlayerName], [JerseyNumber], [PositionID], [BattingAverage], [YearsPlayed], [TeamID]) VALUES (4, N'Dugger', 5, 4, CAST(0.25000 AS Decimal(18, 5)), 6, 3)
INSERT [dbo].[Players] ([PlayerID], [PlayerName], [JerseyNumber], [PositionID], [BattingAverage], [YearsPlayed], [TeamID]) VALUES (5, N'Happy', 69, 5, CAST(0.45000 AS Decimal(18, 5)), 7, 3)
INSERT [dbo].[Players] ([PlayerID], [PlayerName], [JerseyNumber], [PositionID], [BattingAverage], [YearsPlayed], [TeamID]) VALUES (6, N'Gunner', 34, 7, CAST(0.38000 AS Decimal(18, 5)), 4, 3)
INSERT [dbo].[Players] ([PlayerID], [PlayerName], [JerseyNumber], [PositionID], [BattingAverage], [YearsPlayed], [TeamID]) VALUES (7, N'Sleepy', 25, 6, CAST(0.32000 AS Decimal(18, 5)), 2, 1)
INSERT [dbo].[Players] ([PlayerID], [PlayerName], [JerseyNumber], [PositionID], [BattingAverage], [YearsPlayed], [TeamID]) VALUES (8, N'Grumpy', 6, 8, CAST(0.42000 AS Decimal(18, 5)), 2, 1)
INSERT [dbo].[Players] ([PlayerID], [PlayerName], [JerseyNumber], [PositionID], [BattingAverage], [YearsPlayed], [TeamID]) VALUES (9, N'Slappy', 9, 9, CAST(0.40000 AS Decimal(18, 5)), 4, 2)
INSERT [dbo].[Players] ([PlayerID], [PlayerName], [JerseyNumber], [PositionID], [BattingAverage], [YearsPlayed], [TeamID]) VALUES (10, N'Funny', 7, 10, CAST(0.32000 AS Decimal(18, 5)), 5, 2)
SET IDENTITY_INSERT [dbo].[Players] OFF
SET IDENTITY_INSERT [dbo].[Positions] ON 

INSERT [dbo].[Positions] ([PositionID], [PositionName]) VALUES (1, N'Catcher')
INSERT [dbo].[Positions] ([PositionID], [PositionName]) VALUES (2, N'Pitcher')
INSERT [dbo].[Positions] ([PositionID], [PositionName]) VALUES (3, N'Short Stop')
INSERT [dbo].[Positions] ([PositionID], [PositionName]) VALUES (4, N'Center Field')
INSERT [dbo].[Positions] ([PositionID], [PositionName]) VALUES (5, N'First Base')
INSERT [dbo].[Positions] ([PositionID], [PositionName]) VALUES (6, N'Second Base')
INSERT [dbo].[Positions] ([PositionID], [PositionName]) VALUES (7, N'Third Base')
INSERT [dbo].[Positions] ([PositionID], [PositionName]) VALUES (8, N'Left Field')
INSERT [dbo].[Positions] ([PositionID], [PositionName]) VALUES (9, N'Right Field')
INSERT [dbo].[Positions] ([PositionID], [PositionName]) VALUES (10, N'Des Hitter')
SET IDENTITY_INSERT [dbo].[Positions] OFF
SET IDENTITY_INSERT [dbo].[Teams] ON 

INSERT [dbo].[Teams] ([TeamID], [TeamName], [Manager], [LeagueID]) VALUES (1, N'Bulls', N'Sammy', 1)
INSERT [dbo].[Teams] ([TeamID], [TeamName], [Manager], [LeagueID]) VALUES (2, N'Tigers', N'Sully', 2)
INSERT [dbo].[Teams] ([TeamID], [TeamName], [Manager], [LeagueID]) VALUES (3, N'Mets', N'Mike', 3)
INSERT [dbo].[Teams] ([TeamID], [TeamName], [Manager], [LeagueID]) VALUES (4, N'Red Sox', N'Canner', 4)
INSERT [dbo].[Teams] ([TeamID], [TeamName], [Manager], [LeagueID]) VALUES (5, N'Yankees', N'Gunner', 1)
INSERT [dbo].[Teams] ([TeamID], [TeamName], [Manager], [LeagueID]) VALUES (6, N'Braves', N'Sandy', 2)
INSERT [dbo].[Teams] ([TeamID], [TeamName], [Manager], [LeagueID]) VALUES (7, N'Blue Jays', N'Harper', 3)
INSERT [dbo].[Teams] ([TeamID], [TeamName], [Manager], [LeagueID]) VALUES (8, N'Cardinals', N'Finky', 4)
INSERT [dbo].[Teams] ([TeamID], [TeamName], [Manager], [LeagueID]) VALUES (9, N'Dodgers', N'Slippy', 1)
INSERT [dbo].[Teams] ([TeamID], [TeamName], [Manager], [LeagueID]) VALUES (10, N'Browns', N'Stinky', 2)
INSERT [dbo].[Teams] ([TeamID], [TeamName], [Manager], [LeagueID]) VALUES (11, N'Da Bears', N'Fully', 3)
INSERT [dbo].[Teams] ([TeamID], [TeamName], [Manager], [LeagueID]) VALUES (12, N'Who Dat', N'Wha', 4)
SET IDENTITY_INSERT [dbo].[Teams] OFF
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Positions] FOREIGN KEY([PositionID])
REFERENCES [dbo].[Positions] ([PositionID])
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_Players_Positions]
GO
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Teams] FOREIGN KEY([TeamID])
REFERENCES [dbo].[Teams] ([TeamID])
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_Players_Teams]
GO
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Leagues] FOREIGN KEY([LeagueID])
REFERENCES [dbo].[Leagues] ([LeagueID])
GO
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_Teams_Leagues]
GO
USE [master]
GO
ALTER DATABASE [BaseballLeague] SET  READ_WRITE 
GO
