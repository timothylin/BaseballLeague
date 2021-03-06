USE [BaseballLeague]
GO
/****** Object:  StoredProcedure [dbo].[GetTeamByID]    Script Date: 11/19/2015 3:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Patrick
-- Create date: 11/19/2015
-- Description:	gets team by ID
-- =============================================
ALTER PROCEDURE [dbo].[GetTeamByID] 
	-- Add the parameters for the stored procedure here
	@TeamID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select t.TeamID, t.TeamName, t.Manager, t.LeagueID, 
                                  p.PlayerID, p.PlayerName, p.JerseyNumber, p.PositionID, p.BattingAverage, p.YearsPlayed, p.TeamID,
                                  l.LeagueName, 
                                  pos.PositionID, pos.PositionName 
                                  from Teams t 
                                  join Players p 
                                  on t.TeamID = p.TeamID 
                                  join Leagues l 
                                  on t.LeagueID = l.LeagueID 
                                  join Positions pos 
                                  on pos.PositionID = p.PositionID 
                                  where t.TeamID = @TeamID 
END
