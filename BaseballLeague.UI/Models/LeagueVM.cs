using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseballLeague.Models;

namespace BaseballLeague.UI.Models
{
    public class LeagueVM
    {
        public int LeagueID { get; set; }
        public string LeagueName { get; set; }
        public List<Team> Teams { get; set; }

        public LeagueVM()
        {
            Teams = new List<Team>();
        }
    }
}