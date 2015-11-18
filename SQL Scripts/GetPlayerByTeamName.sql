USE [BaseballLeague]
GO

/****** Object:  StoredProcedure [dbo].[GetPlayersByTeamName]    Script Date: 11/18/2015 2:09:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPlayersByTeamName]
	(
	  @TeamName varchar(20) 
	)AS

	select p.PlayerName, t.TeamName
	from Players p	
	inner join Teams t
	on t.TeamName = @TeamName 
GO

