USE [BaseballLeague]
GO

/****** Object:  StoredProcedure [dbo].[GetLeagueByID]    Script Date: 2016/1/27 下午 10:50:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[GetLeagueByID]
@LeagueID int
as

begin

select *
	from Leagues
	where LeagueID = @LeagueID

end

GO

