using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseballLeague.BLL;
using BaseballLeague.Models;
using BaseballLeague.UI.Models;

namespace BaseballLeague.UI.Controllers
{
    public class TeamController : Controller
    {
       //Lara created --- goes to list of Teams page
        public ActionResult Index()
        {
            var ops = new BaseballOperations();
            AddPlayerViewModel teams = new AddPlayerViewModel();

            var response = ops.GetAllTeams();

            return View("Index",response.Teams);
        }

        //******************************************************************

        public ActionResult AddTeam()
        {
            BaseballOperations ops = new BaseballOperations();

            TeamVM tvm = new TeamVM();

            var response = ops.GetAllLeagues();
            tvm.CreateLeagueList(response.Leagues);
            
            return View(tvm);
        }

        //[HttpPost]
        //public ActionResult AddTeam
    }
}