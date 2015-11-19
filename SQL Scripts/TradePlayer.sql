USE [BaseballLeague]
GO

/****** Object:  StoredProcedure [dbo].[TradePlayer]    Script Date: 11/18/2015 11:27:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[TradePlayer] (
@TeamID int,
@PlayerID int
)
as

begin

update Players
	set TeamID = @TeamID
where PlayerID = @PlayerID

end


GO

