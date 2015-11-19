using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseballLeague.BLL;
using BaseballLeague.DataLayer;
using BaseballLeague.Models;

namespace BaseballLeague.UI.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CreatePlayer();

            //RemovePlayer(15);

            // Console.ReadLine();

            //var repo = new BaseballRepository();

            //var players = repo.GetAllPlayersOnAllTeams();

            //foreach (var player in players)
            //{
            //    Console.WriteLine(player.PlayerName);
            //}


            //Console.ReadLine();


        }

        //public static void RemovePlayer(int number)
        //{
        //    BaseballRepository repo = new BaseballRepository();

        //    repo.RemovePlayer(number);

        //    Console.WriteLine("Player number {0} is deleted", number);
        //}



        //public static void CreatePlayer()
        //{
        //    var repo = new BaseballRepository();

        //    Player p = new Player();
        //    p.Name = "Simon";
        //    p.JerseyNumber = 10;
        //    p.Position.PositionID = 8;
        //    p.Team.TeamID = 1;
        //    p.BattingAverage = 0.35m;
        //    p.YearsPlayed = 10;

        //    repo.CreatePlayer(p);

        //    Console.WriteLine("{0} is a great Player with batting average {1} ", p.Name, p.BattingAverage );
        //}




    }
}
