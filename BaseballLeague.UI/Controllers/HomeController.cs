using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseballLeague.BLL;

namespace BaseballLeague.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var ops = new BaseballOperations();
            var leagues = ops.GetAllLeagues();

            return View(leagues);
        }
    }
}