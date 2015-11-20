USE [BaseballLeague]
GO

/****** Object:  StoredProcedure [dbo].[InsertTeams]    Script Date: 11/19/2015 3:18:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Alter PROCEDURE [dbo].[InsertTeams] (
@TeamName varchar (50),
@Manager varchar(50),
@LeagueID int,
@TeamID int Output
) as
begin

insert into Teams(TeamName, Manager, LeagueID)
values (@TeamName, @Manager, @LeagueID)

set @TeamID = SCOPE_IDENTITY();

End
GO

