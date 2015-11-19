USE [BaseballLeague]
GO

/****** Object:  StoredProcedure [dbo].[InsertTeams]    Script Date: 11/19/2015 3:18:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[InsertTeams] (
@TeamID int,
@TeamName varchar (50),
@Manager varchar(50),
@LeagueID int output
) as
begin

insert into Teams(TeamID, TeamName, Manager, LeagueID)
values (@TeamID, @TeamName, @Manager, @LeagueID)

set @TeamID = SCOPE_IDENTITY();

End
GO

