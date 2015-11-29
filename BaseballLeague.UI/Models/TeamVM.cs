using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseballLeague.Models;

namespace BaseballLeague.UI.Models
{
   
    public class TeamPlayersVM
    {
        public string TeamName { get; set; }
        public List<Player> Players { get; set; }

    }
    public class TeamVM
    {

        public List<SelectListItem> LeagueList { get; set; }
        public Team Team { get; set; }

        public TeamVM()
        {
            LeagueList = new List<SelectListItem>();
        }

        public void CreateLeagueList(List<League> listOfLeagues)
        {
            foreach (var l in listOfLeagues)
            {
                var newItem = new SelectListItem();
                newItem.Value = l.LeagueID.ToString();
                newItem.Text = l.LeagueName;

                LeagueList.Add(newItem);

            }
        }
    }
}