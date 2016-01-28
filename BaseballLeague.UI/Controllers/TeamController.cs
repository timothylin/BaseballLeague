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

        [HttpPost]
        public ActionResult AddTeam(TeamVM vm)
        {
            var ops = new BaseballOperations();

            var response = ops.GetAllLeagues();
            vm.CreateLeagueList(response.Leagues);

            if (ModelState.IsValid)
            {
                var opsResponse = ops.AddTeam(vm.Team);
                opsResponse.Team.League = ops.GetLeagueByID(vm.Team.League.LeagueID).League;
                return View("TeamDetails", opsResponse.Team);
            }
            else
            {
                return View("AddTeam");
            }
        }
    }
}