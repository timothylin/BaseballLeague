using System;
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

        //[TestCase(1)]
        //public void GetPlayerByIDTest()
    }
}
