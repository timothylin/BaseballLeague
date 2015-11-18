using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Models
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public League League { get; set; }
        public List<League> Leagues { get; set; }
        public Team Team { get; set; } 
        public List<Team> Teams { get; set; }
        public Position Position { get; set; }
        public List<Position> Positions { get; set; }
        public Player Player { get; set; }
        public List<Player> Players { get; set; }

        public Response()
        {
            League = new League();
            Leagues = new List<League>();
            Team = new Team();
            Teams = new List<Team>();
            Position = new Position();
            Positions = new List<Position>();
            Player = new Player();
            Players = new List<Player>();
        }  
    }
}
