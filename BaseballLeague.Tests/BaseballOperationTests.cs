﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using BaseballLeague.BLL;
using BaseballLeague.DataLayer.Config;
using BaseballLeague.Models;
using Dapper;
using NUnit.Framework;

namespace BaseballLeague.Tests
{
    [TestFixture]
    public class BaseballOperationTests
    {
        private BaseballOperations _ops { get; set; }
        private Response _response { get; set; }
        private JavaScriptSerializer _jss { get; set; }

        [SetUp]
        public void SetUp()
        {
            _ops = new BaseballOperations();
            _response = new Response();
            _jss = new JavaScriptSerializer();
        }

        [Test]
        public void GetAllTeamsTest()
        {
            List<Team> teamsExpected = new List<Team>();

            _response = _ops.GetAllTeams();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                teamsExpected = cn.Query<Team>("select * from Teams t " +
                                           "inner join Leagues l " +
                                           "on t.LeagueID = l.LeagueID").ToList();
            }

            var expected = _jss.Serialize(teamsExpected);
            var actual = _jss.Serialize(_response.Teams);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllLeaguesTest()
        {
            List<League> leaguesExpected = new List<League>();

            _response = _ops.GetAllLeagues();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                leaguesExpected = cn.Query<League>("select * from Leagues").ToList();
            }

            var expected = _jss.Serialize(leaguesExpected);
            var actual = _jss.Serialize(_response.Leagues);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void GetPlayersByTeamNameTest(int teamID)
        {
            //List<Player> playersExpected = new List<Player>();

            _response = _ops.GetPlayersByTeamName(teamID);

            var playersExpected = _ops.GetAllPlayerOnAllTeams().Players.Where(p => p.Team.TeamID == teamID);

            var expected = _jss.Serialize(playersExpected);
            var actual = _jss.Serialize(_response.Players);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreatePlayerTest()
        {
            Player player = new Player();

            player.PlayerName = "Raiden";
            player.JerseyNumber = 55;
            player.Position.PositionID = 7;
            player.BattingAverage = 0.29m;
            player.YearsPlayed = 20;
            player.Team.TeamID = 2;


            Assert.AreEqual(true, _ops.CreatePlayer(player).Success);
        }

        [Test]
        public void RemovePlayerByIDTest()
        {
            int playerID = 0;

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                playerID = (int)cn.ExecuteScalar("select count(*) from Players");
            }

            Assert.AreEqual(true, _ops.RemovePlayerByID(playerID).Success);
        }

        [Test]
        public void GetAllPlayersOnAllTeamsTest()
        {
            int count = 0;

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                count = (int)cn.ExecuteScalar("select count(*) from players");
            }

            Assert.AreEqual(count, _ops.GetAllPlayerOnAllTeams().Players.Count());
        }

        [TestCase(1, 5)]
        [TestCase(2, 3)]
        [TestCase(3, 1)]
        public void TradePlayerTests(int playerID, int newTeamID)
        {
            _response = _ops.TradePlayer(playerID, newTeamID);

            Assert.AreEqual(true, _response.Success);
        }

        [Test]
        public void AddTeamTest()
        {
            var team = new Team();
            team.TeamName = "CloudRiders";
            team.Manager = "Genos";
            team.League.LeagueID = 2;

            var response = _ops.AddTeam(team);

            Assert.AreEqual(true, response.Success);
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        public void GetTeamByIDTests(int teamID)
        {
            var response = _ops.GetTeamByID(teamID);

            Assert.AreEqual(teamID, response.Team.TeamID);
        }

        [Test]
        public void GetAllPositionsTest()
        {
            var response = _ops.GetAllPositions();
            List<Position> sqlOutput = new List<Position>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                sqlOutput = cn.Query<Position>("select * from Positions").ToList();
            }

            var actual = _jss.Serialize(response.Positions);
            var expected = _jss.Serialize(sqlOutput);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetTeamsByLeagueIDTests(int leagueID)
        {
            var response = _ops.GetTeamsByLeagueID(leagueID);

            Assert.AreEqual(true, response.Success);

        }



    }
}
