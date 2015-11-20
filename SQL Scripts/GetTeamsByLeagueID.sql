USE [BaseballLeague]
GO

/****** Object:  StoredProcedure [dbo].[GetTeamsByLeagueID]    Script Date: 11/20/2015 4:19:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Patrick>
-- Create date: <11/20/2015>
-- Description:	<Gets Teams in a Specific League By LeagueID>
-- =============================================
CREATE PROCEDURE [dbo].[GetTeamsByLeagueID]
	-- Add the parameters for the stored procedure here
(	@LeagueID int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select l.LeagueID, l.LeagueName, t.TeamID, t.TeamName, t.Manager
		from Leagues l
		inner join teams t
		on t.LeagueID = l.LeagueID
		where l.LeagueID = @leagueID
END

GO

