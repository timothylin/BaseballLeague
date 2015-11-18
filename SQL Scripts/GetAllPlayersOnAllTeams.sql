USE [BaseballLeague]
GO

/****** Object:  StoredProcedure [dbo].[GetALLPlayersOnAllTeams]    Script Date: 11/18/2015 3:57:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetALLPlayersOnAllTeams]	
AS 
select p.PlayerID, p.PlayerName, p.JerseyNumber, p.BattingAverage,
                                   p.YearsPlayed, ps.PositionName, t.TeamName,t.Manager,l.LeagueName
                                   from Players p 
                                   inner join Positions ps 
                                   on p.PositionID = ps.PositionID 
                                   inner join Teams t
                                   on p.TeamID = t.TeamID 
                                   inner join Leagues l 
                                   on l.LeagueID = t.LeagueID 



GO

