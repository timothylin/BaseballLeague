USE [BaseballLeague]
GO

/****** Object:  StoredProcedure [dbo].[GetALLTeams]    Script Date: 11/19/2015 2:47:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetALLTeams]	
AS 
select *
from Leagues as l
inner join Teams as t
on l.LeagueID = t.LeagueID



GO

