using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lastTime.Models;

namespace lastTime.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            About a = new About();
            {
                a.HeadCoach = "Lincoln Riley";
                a.BowlRecord = "29-22-1 (.567)";
                a.NationalTitles = "7 (1950, 1955, 1956, 1974, 1975, 1985, 2000)";
            }



            return View(a);
        }

    }
}