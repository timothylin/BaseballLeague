using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using BaseballLeague.DataLayer.Config;
using BaseballLeague.Models;
using Dapper;

namespace BaseballLeague.DataLayer

{
    public class BaseballRepository
    {

        public static List<League> Leagues { get; set; }
        public static List<Team> Teams { get; set; }
        public static List<Position> Positions { get; set; }
        public static List<Player> Players { get; set; }

        public BaseballRepository()
        {
            Leagues = new List<League>();
            Teams = new List<Team>();
            Positions = new List<Position>();
            Players = new List<Player>();
        }

        public List<Player> GetAllPlayersOnAllTeams()
        {
            Players = new List<Player>();
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetAllPlayersOnAllTeams";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Players.Add(PopulatePlayerFromDataReader(dr));
                    }
                }
            }

            return Players;
        }

        //gets a list of Players By The Team name 
        public List<Player> GetPlayersByTeamName(int teamID)
        {
            Players = new List<Player>();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetPlayersByTeamName";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@TeamID", teamID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Players.Add(PopulatePlayerFromDataReader(dr));
                    }
                }
            }

            return Players;
        }


        //for testing creating a method to check if player table is updated and then setup methods for response on bll 

        public Player GetPlayerByID(int playerID)
        {
            var player = new Player();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select p.PlayerID, p.PlayerName, p.TeamID, t.TeamName, t.Manager, " +
                                  "l.LeagueID, l.LeagueName, p.PositionID, ps.PositionName, p.JerseyNumber, " +
                                  "p.BattingAverage, p.YearsPlayed " +
                                  "from Players p " +
                                  "inner join Positions ps " +
                                  "on p.PositionID = ps.PositionID " +
                                  "inner join Teams t " +
                                  "on p.TeamID = t.TeamID " +
                                  "inner join Leagues l " +
                                  "on t.LeagueID = l.LeagueID " +
                                  "where p.PlayerID = @playerID";

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@playerID", playerID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        player = PopulatePlayerFromDataReader(dr);
                    }
                }
            }

            return player;
        }



        public Player CreatePlayer(Player player)
        {

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();

                p.Add("@PlayerName", player.PlayerName);
                p.Add("@JerseyNumber", player.JerseyNumber);
                p.Add("@PositionID", player.Position.PositionID);
                p.Add("@BattingAverage", player.BattingAverage);
                p.Add("@YearsPlayed", player.YearsPlayed);
                p.Add("@TeamID", player.Team.TeamID);

                p.Add("PlayerID", DbType.Int32, direction: ParameterDirection.Output);
                cn.Execute("InsertPlayer", p, commandType: CommandType.StoredProcedure);

                var playerID = p.Get<int>("PlayerID");


                return GetPlayerByID(playerID);

            }

        }



        public Player RemovePlayer(int playerID)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "delete Players " +
                                "where PlayerID = @playerID";

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@playerID", playerID);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }

            return GetPlayerByID(playerID);
        }



        public Player TradePlayer(Player player, int newTeamID)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@TeamID", newTeamID);
                p.Add("@PlayerID", player.PlayerID);

                cn.Execute("TradePlayer", p, commandType: CommandType.StoredProcedure);
            }

            return GetPlayerByID(player.PlayerID);
        }

        public Team AddTeam(Team team)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var pnsm = new DynamicParameters();
                pnsm.Add("@TeamName", team.TeamName);
                pnsm.Add("@Manager", team.Manager);
                pnsm.Add("@LeagueID", team.League.LeagueID)
                    ;
                pnsm.Add("@TeamID", DbType.Int32, direction: ParameterDirection.Output);
                //TODO: Need to make stored procedure, going over them with randall today.
                cn.Execute("InsertTeams", pnsm, commandType: CommandType.StoredProcedure);

                var teamID = pnsm.Get<int>("TeamID");

                foreach (var player in team.Players)
                {
                    var pma = new DynamicParameters();

                    pma.Add("@TeamID", teamID);
                    pma.Add("@PlayerID", player.PlayerID);
                    //TODO: need to make stored procedure, going over them with Randall today.
                    cn.Execute("InsertTeamPlayers", pma, commandType: CommandType.StoredProcedure);
                }

                return GetTeamByID(teamID);
            }
        }

        public Team GetTeamByID(int teamID)
        {
            Team team = new Team();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "select t.TeamID, t.TeamName, t.Manager, t.LeagueID, " +
                                  "p.PlayerID, p.PlayerName, p.JerseyNumber, p.PositionID, p.BattingAverage, p.YearsPlayed, p.TeamID " +
                                  "l.LeagueName, " +
                                  "pos.PositionID, pos.PositionName " +
                                  "from Teams t " +
                                  "join Players p " +
                                  "on t.TeamID = p.TeamID " +
                                  "join Leagues l " +
                                  "on t.LeagueID = l.LeagueID " +
                                  "join Positions pos " +
                                  "on pos.PositionID = p.PositionID " +
                                  "where t.TeamID = @TeamID ";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@TeamID", teamID);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        team = PopulateTeamInfoFromDataReader(dr);
                    }
                }
            }

            return team;
        }

        public List<Position> GetAllPositions()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                Positions = cn.Query<Position>("Select * from Positions").ToList();
            }

            return Positions;
        }

        private Player PopulatePlayerFromDataReader(SqlDataReader dr)
        {
            var player = new Player();

            player.PlayerID = (int)dr["PlayerID"];
            player.PlayerName = dr["PlayerName"].ToString();
            player.Team.TeamID = (int)dr["TeamID"];
            player.Team.TeamName = dr["TeamName"].ToString();
            player.Team.Manager = dr["Manager"].ToString();
            player.Team.League.LeagueID = (int)dr["LeagueID"];
            player.Team.League.LeagueName = dr["LeagueName"].ToString();
            player.Position.PositionID = (int)dr["PositionID"];
            player.Position.PositionName = dr["PositionName"].ToString();
            player.JerseyNumber = (int)dr["JerseyNumber"];
            player.BattingAverage = (decimal)dr["BattingAverage"];
            player.YearsPlayed = (int)dr["YearsPlayed"];

            return player;
        }

        private Team PopulateTeamInfoFromDataReader(SqlDataReader dr)
        {
            var team = new Team();

            team.TeamID = (int)dr["TeamID"];
            team.TeamName = dr["TeamName"].ToString();
            team.Manager = dr["Manager"].ToString();
            team.League.LeagueID = (int)dr["LeagueID"];

            return team;
        }
    }
}

