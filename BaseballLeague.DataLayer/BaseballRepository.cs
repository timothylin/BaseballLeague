using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseballLeague.Models;

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
    }
}
