using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lastTime.Models;

namespace lastTime.Controllers
{
    public class SchedulesController : Controller
    {
        private DB_128040_practiceEntities db = new DB_128040_practiceEntities();

        // GET: Schedules
        public ActionResult Index(int year=2019)
        {
            var date = db.FootballSchedules.Where(x => x.Season == year);
            return View(date);
        }

    }
}
