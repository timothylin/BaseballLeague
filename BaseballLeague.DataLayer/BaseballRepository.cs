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
        public void CreatePlayer(Player player)
        {

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var p = new DynamicParameters();

                p.Add("@PlayerName", player.Name);
                p.Add("@JerseyNumber", player.JerseyNumber);
                p.Add("@PositionID", player.Position.PositionID);
                p.Add("@BattingAverage", player.BattingAverage);
                p.Add("@YearsPlayed", player.YearsPlayed);
                p.Add("@TeamID", player.Team.TeamID);
               
                p.Add("PlayerID", DbType.Int32, direction:ParameterDirection.Output);
                cn.Execute("InsertPlayer", p, commandType: CommandType.StoredProcedure);

               // var playerID = p.Get<int>("PlayerID");

              cn.Open();
                cn.Close();

            }

        }



        public void RemovePlayer(int playerID)
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

        }



    }
}
