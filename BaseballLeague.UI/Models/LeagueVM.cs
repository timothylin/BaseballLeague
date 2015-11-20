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

        public List<SelectListItem> TeamList { get; set; }
        public List<Team> Teams { get; set; }

        public Team team { get; set; }
        public string LeagueName { get; set; }

        public LeagueVM()
        {
            Teams = new List<Team>();
            TeamList = new List<SelectListItem>();
        }

        public void CreateTeamList(List<Team> listOfTeams)
        {
            foreach (var t in listOfTeams)
            {
                var newItem = new SelectListItem();
                newItem.Value = t.TeamID.ToString();
                newItem.Text = t.TeamName;

                TeamList.Add(newItem);

            }
        }
    }
}