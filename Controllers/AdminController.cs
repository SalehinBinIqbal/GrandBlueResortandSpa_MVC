using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrandBlueResortandSpa.Controllers
{
    public class AdminController : Controller
    {
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
    }
}