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
        public List<SelectListItem> LeaguesList { get; set; }

        public LeagueVM()
        {
            LeaguesList = new List<SelectListItem>();
        }
         
        public void CreateLeagueList(List<League> ListofLeagues)
        {
            foreach (var s in ListofLeagues)
            {

                var newItem = new SelectListItem();
                newItem.Text = s.LeagueName;
                newItem.Value = s.LeagueID.ToString();

                LeaguesList.Add(newItem);
            }
        }


    }
}