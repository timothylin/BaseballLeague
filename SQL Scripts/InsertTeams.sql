USE [BaseballLeague]
GO

SET ANSI_NULLS ON

GO

ALTER PROCEDURE [dbo].[InsertTeams] (
@TeamID int,
@TeamName varchar (50),
@Manager varchar(50),
@LeagueID int output
) as
begin

insert into Teams(TeamID, TeamName, Manager, LeagueID)
values (@TeamID, @Name, @Manager, @LeagueID)

set @TeamID = SCOPE_IDENTITY();

End