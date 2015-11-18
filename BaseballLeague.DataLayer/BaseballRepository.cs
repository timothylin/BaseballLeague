using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
            List<Player> Players = new List<Player>();
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
        public List<Player> GetPlayersByTeamName(string teamName)
        {
            List<Player> Players = new List<Player>();
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetPlayersByTeamName";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@TeamName", teamName);

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

        private Player PopulatePlayerFromDataReader(SqlDataReader dr)
        {
            var player = new Player();

            player.PlayerID = (int)dr["PlayerID"];
            player.Name = dr["PlayerName"].ToString();
            player.Team.Name = dr["TeamName"].ToString();
            player.Team.Manager = dr["Manager"].ToString();
            player.Team.League.Name = dr["LeagueName"].ToString();
            player.JerseyNumber = (int)dr["JerseyNumber"];
            player.BattingAverage = (decimal)dr["BattingAverage"];
            player.YearsPlayed = (int)dr["StudioName"];

            return player;
        }
    }
}
