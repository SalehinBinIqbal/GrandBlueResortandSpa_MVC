using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrandBlueResortandSpa.Models;

namespace GrandBlueResortandSpa.Controllers
{
    public class HomeController : Controller
    {
        GrandBlueEntities grandBlue = new GrandBlueEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WhyUs()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(CONTACT contact)
        {
            grandBlue.CONTACTs.Add(contact);
            grandBlue.SaveChanges();
            return RedirectToAction("Contact");
        }

        public ActionResult Rooms()
        {
            return View();
        }

        public ActionResult Dine()
        {
            return View();
        }

        public ActionResult Relax()
        {
            return View();
        }

        public ActionResult Enjoy()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View();
        }

        public ActionResult OceanSideVilla()
        {
            return View("Rooms/OceanSideVilla");
        }

        public ActionResult FamilyVilla()
        {
            return View("Rooms/FamilyVilla");
        }

        public ActionResult DeluxeSuite()
        {
            return View("Rooms/DeluxeSuite");
        }

        public ActionResult PremiumSuite()
        {
            return View("Rooms/PremiumSuite");
        }

        public ActionResult OceanSideRoom()
        {
            return View("Rooms/OceanSideRoom");
        }
    }
}