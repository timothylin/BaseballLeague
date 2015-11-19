USE [BaseballLeague]
GO

/****** Object:  StoredProcedure [dbo].[InsertPlayer]    Script Date: 11/19/2015 9:01:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE Procedure [dbo].[InsertPlayer](
@PlayerName varchar(50),
@JerseyNumber int,
@PositionID int,
@BattingAverage decimal (18, 5),
@YearsPlayed int,
@TeamID int,
@PlayerID int Output
) as
begin

insert into Players(PlayerName, JerseyNumber, PositionID, BattingAverage, YearsPlayed, TeamID )
values (@PlayerName, @JerseyNumber, @PositionID, @BattingAverage, @YearsPlayed, @TeamID)

set @PlayerID = SCOPE_IDENTITY();

End
GO

