using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Models
{
    public class League
    {
        public int LeagueID { get; set; }
        public string LeagueName { get; set; }
        public List<Team> Teams { get; set; }

        public League()
        {
            Teams = new List<Team>();
        }
    }
}
