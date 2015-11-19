USE [BaseballLeague]
GO

/****** Object:  StoredProcedure [dbo].[GetALLPlayersOnAllTeams]    Script Date: 11/18/2015 11:26:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetALLPlayersOnAllTeams]	
AS 
select p.PlayerID, p.PlayerName, p.TeamID, t.TeamName, t.Manager,
l.LeagueID, l.LeagueName, p.PositionID, ps.PositionName, p.JerseyNumber,
p.BattingAverage, p.YearsPlayed
                                   from Players p 
                                   inner join Positions ps 
                                   on p.PositionID = ps.PositionID 
                                   inner join Teams t
                                   on p.TeamID = t.TeamID 
                                   inner join Leagues l 
                                   on l.LeagueID = t.LeagueID 




GO

