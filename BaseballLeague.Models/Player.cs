using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public Position Position { get; set; }
        public Team Team { get; set; }
        public int JerseyNumber { get; set; }
        public string PlayerName { get; set; }
        public decimal BattingAverage { get; set; }
        public int YearsPlayed { get; set; }

        public Player()
        {
            Position = new Position();
            Team = new Team();
        }
    }
}
