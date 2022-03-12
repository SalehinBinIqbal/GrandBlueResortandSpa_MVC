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
        public ActionResult Index(BOOKING booking)
        {
            List<BOOKING> bookingList = grandBlue.BOOKINGs.ToList();
            return View(bookingList);
        }

        public ActionResult Members()
        {
            List<MEMBER> memberList = grandBlue.MEMBERs.ToList();
            return View(memberList);
        }
        [HttpPost]
        public ActionResult Members(MEMBER members)
        {
            grandBlue.MEMBERs.Remove(members);
            grandBlue.SaveChanges();
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