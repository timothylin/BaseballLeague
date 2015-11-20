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
    public class HomeController : Controller
    {
        //Response response = new Response();
        // GET: Home
        public ActionResult Index()
        {
            var ops = new BaseballOperations();
            var response = ops.GetAllLeagues();
            
            //var leagueVM = new LeagueVM();

            //leagueVM.CreateLeagueList(response.Leagues);

            return View("Index", response.Leagues);
        }
    }
}