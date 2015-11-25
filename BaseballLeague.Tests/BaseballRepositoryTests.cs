using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using BaseballLeague.DataLayer;
using BaseballLeague.DataLayer.Config;
using BaseballLeague.Models;
using Dapper;
using NUnit.Framework;

namespace BaseballLeague.Tests
{
    [TestFixture]
    public class BaseballRepositoryTests
    {
        private BaseballRepository _repo { get; set; }
        private JavaScriptSerializer _jss { get; set; }

        [SetUp]
        public void SetUp()
        {
            _repo = new BaseballRepository();
            _jss = new JavaScriptSerializer();
        }

        [Test]
        public void GetAllLeagues()
        {
            List<League> leagues = _repo.GetAllLeagues();

            Assert.AreEqual(1, leagues.FirstOrDefault(m=> m.LeagueID == 1).LeagueID);
        }

        [Test]
        public void GetAllTeams()
        {
            List<Team> teams = _repo.GetAllTeams();

            Assert.AreEqual("Bulls", teams.FirstOrDefault(m => m.TeamName == "Bulls").TeamName);
        }

        [Test]
        public void GetAllPlayersOnAllTeams()
        {
            List<Player> players = _repo.GetAllPlayersOnAllTeams();

            Assert.AreEqual(1, players.FirstOrDefault(m => m.PlayerID == 1).PlayerID);
        }


        [Test]
        public void GetPlayersByTeamName()
        {
            List<Player> players = _repo.GetPlayersByTeamName(1);

            var playersList = _repo.GetAllPlayersOnAllTeams();

            var expectedPlayers = playersList.Where(p => p.Team.TeamID == 1);

            var actual = _jss.Serialize(players);

            var expected = _jss.Serialize(expectedPlayers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPlayerByID()
        {
            Player player = _repo.GetPlayerByID(7);

            Assert.AreEqual("Sleepy", player.PlayerName);
        }


        [Test]
        public void CreatePlayer()
        {
            Player player = new Player();

            player.PlayerName = "Raiden";
            player.JerseyNumber = 55;
            player.Position.PositionID = 7;
            player.BattingAverage = 0.29m;
            player.YearsPlayed = 20;
            player.Team.TeamID = 2;

            var result = _repo.CreatePlayer(player);

            Assert.AreEqual("Raiden", result.PlayerName);


        }


        [Test]
        public void RemovePlayer()
        {
            var result = _repo.RemovePlayer(14);

            Assert.AreEqual(null, result.PlayerName);
        }


        [Test]
        public void TradePlayer()
        {
            var result = _repo.TradePlayer(5, 3);

            Assert.AreEqual(3, result.Team.TeamID);
        }

        [Test]
        public void AddTeam()
        {
            var team = new Team();
            team.TeamName = "Cloud Riders";
            team.Manager = "Genos";
            team.League.LeagueID = 2;

            var result = _repo.AddTeam(team);

            var expectedTeam = _repo.GetTeamByID(
                result.TeamID);

            var actual = _jss.Serialize(result);

            var expected = _jss.Serialize(expectedTeam);

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void GetTeamByID()
        {
            var result = _repo.GetTeamByID(5);

            List<Team> teamsReturned = new List<Team>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                teamsReturned = cn.Query<Team>("select * from teams").ToList();
            }

            var expected = teamsReturned.FirstOrDefault(t => t.TeamID == 5);

            Assert.AreEqual(expected.TeamName, result.TeamName);
        }


        [Test]
        public void GetAllPositions()
        {
            List<Position> positions = _repo.GetAllPositions();

            Assert.AreEqual("Catcher", positions.FirstOrDefault(m=> m.PositionName == "Catcher").PositionName);
        }




    }
}
