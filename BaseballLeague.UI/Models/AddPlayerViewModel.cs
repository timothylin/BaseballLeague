using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseballLeague.Models;

namespace BaseballLeague.UI.Models
{
    public class AddPlayerViewModel
    {
        public List<SelectListItem> TeamList { get; set; }  
        public List<SelectListItem> PositionList { get; set; } 

        public Player player { get; set; }

        public AddPlayerViewModel ()
        {
            TeamList = new List<SelectListItem>();
            PositionList = new List<SelectListItem>();

        }

        public void CreateTeamList(List<Team> listofTeams)
        {
            foreach (var t in listofTeams)
            {
                var newItem = new SelectListItem();
                newItem.Value = t.TeamID.ToString();
                newItem.Text = t.TeamName;

                TeamList.Add(newItem);
            }
        }


        public void CreatePositionList(List<Position> listofPositions)
        {
            foreach (var p in listofPositions)
            {
                var newItem = new SelectListItem();
                newItem.Value = p.PositionID.ToString();
                newItem.Text = p.PositionName;

                PositionList.Add(newItem);
            }
        }


    }
}