using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public League League { get; set; }
        public string Manager { get; set; }
        public string TeamName { get; set; }
        public List<Player> Players { get; set; }

        public Team()
        {
            League = new League();
            Players = new List<Player>();
        }
    }
}
