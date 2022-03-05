using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrandBlueResortandSpa.Models;

namespace GrandBlueResortandSpa.Controllers
{
    public class ReservationController : Controller
    {
        GrandBlueEntities gb = new GrandBlueEntities();
        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Book()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Book(BOOKING booking)
        {
            gb.BOOKINGs.Add(booking);
            gb.SaveChanges();
            return RedirectToAction("Home/Index");
            //return View();
        }
    }
}