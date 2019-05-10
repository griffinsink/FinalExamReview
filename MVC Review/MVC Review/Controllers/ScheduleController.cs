using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Review.Models;

namespace MVC_Review.Controllers
{
    public class ScheduleController : Controller
    {
        private DB_128040_practiceEntities db = new DB_128040_practiceEntities();

        // GET: Schedule
        public ActionResult Index(int year = 2019)
        {
            var date = db.FootballSchedules.Where(x => x.Season == year);
            return View(date);
        }

    }
}
