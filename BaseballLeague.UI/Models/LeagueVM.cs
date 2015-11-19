using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseballLeague.Models;

namespace BaseballLeague.UI.Models
{
    public class LeagueVM
    {
        //public int LeagueID { get; set; }
        //public string LeagueName { get; set; }
        //public List<Team> Teams { get; set; }
        public List<SelectListItem> LeaguesList { get; set; }

        public League League { get; set; } 

        public LeagueVM()
        {
            LeaguesList = new List<SelectListItem>();
            League = new League();
        }
    }
}