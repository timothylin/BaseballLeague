using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using BaseballLeague.BLL;
using BaseballLeague.Models;
using BaseballLeague.UI.Models;

namespace BaseballLeague.UI.Controllers
{
    public class PlayerController : Controller
    {
        public object BaseballOperat { get; private set; }

        //Lara added -- goes to list of players page
        public ActionResult Index(int teamID)
        {

            TeamPlayersVM vm = new TeamPlayersVM();
            BaseballOperations ops = new BaseballOperations();
            AddPlayerViewModel teams = new AddPlayerViewModel();

            var response = ops.GetPlayersByTeamName(teamID);
            vm.TeamName = ops.GetTeamByID(teamID).Team.TeamName;
            vm.Players = response.Players;

            return View(vm);
        }


        // GET: Player
        public ActionResult AddPlayer()
        {
            BaseballOperations ops = new BaseballOperations();

            AddPlayerViewModel addP = new AddPlayerViewModel();

            var teamResponse = ops.GetAllTeams();
            var positionResponse = ops.GetAllPositions();

            addP.CreatePositionList(positionResponse.Positions);
            addP.CreateTeamList(teamResponse.Teams);

            return View(addP);
        }



        [HttpPost]
        public ActionResult AddPlayer(AddPlayerViewModel addP)
        {
            var ops = new BaseballOperations();

            var teamResponse = ops.GetAllTeams();
            var positionResponse = ops.GetAllPositions();

            addP.CreateTeamList(teamResponse.Teams);
            addP.CreatePositionList(positionResponse.Positions);

            if (ModelState.IsValid)
            {
                ops.CreatePlayer(addP.player);

                return View("PlayerDetails", addP.player);
            }
            else
            {
                return View(addP);
            }
        }


        //public ActionResult DeletePlayer(int playerid)
        //{
        //    var ops = new BaseballOperations();
        //    var player = ops.GetPlayerByID(playerid);

        //    return View("Remove", player.)
        //}


        public ActionResult DeletePlayer(int playerid)
        {
            var ops = new BaseballOperations();

            var playerResponse = ops.GetPlayerByID(playerid);

            return View("DeletePlayer", playerResponse.Player);
        }


        [HttpPost]
        public ActionResult ConfirmDeletePlayer(int playerid)
        {
            var ops = new BaseballOperations();

            ops.RemovePlayerByID(playerid);
            var playerResponse = ops.GetPlayerByID(playerid);

            return View("ConfirmDeletePlayer", playerResponse.Player);
        }



    }
}