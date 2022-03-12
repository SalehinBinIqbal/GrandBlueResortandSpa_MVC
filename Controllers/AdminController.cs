using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrandBlueResortandSpa.Models;

namespace GrandBlueResortandSpa.Controllers
{
    public class AdminController : Controller
    {
        GrandBlueEntities grandBlue = new GrandBlueEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Members()
        {
            return View();
        }

        public ActionResult UpdateRooms()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}