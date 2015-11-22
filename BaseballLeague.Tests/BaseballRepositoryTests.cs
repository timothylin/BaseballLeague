using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseballLeague.DataLayer;
using BaseballLeague.Models;
using NUnit.Framework;

namespace BaseballLeague.Tests
{
    [TestFixture]
    public class BaseballRepositoryTests
    {
        private BaseballRepository _repo { get; set; }

        [SetUp]
        public void SetUp()
        {
            _repo = new BaseballRepository();
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

            Assert.AreEqual("Smith", players.FirstOrDefault(m => m.PlayerName == "Smith").PlayerName);
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
            team.TeamName = "CloudRiders";
            team.Manager = "Genos";
            team.League.LeagueID = 2;

            var result = _repo.AddTeam(team);

            Assert.AreEqual(20, result.TeamID);
        }


        [Test]
        public void GetTeamByID()
        {
            var result = _repo.GetTeamByID(20);

            Assert.AreEqual("CloudRiders", result.TeamName);
        }


        [Test]
        public void GetAllPositions()
        {
            List<Position> positions = _repo.GetAllPositions();

            Assert.AreEqual("Catcher", positions.FirstOrDefault(m=> m.PositionName == "Catcher").PositionName);
        }




    }
}
