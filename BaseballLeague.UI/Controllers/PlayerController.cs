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




    }
}