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
        public ActionResult Delete(string email)
        {
            //List<MEMBER> memberList = grandBlue.MEMBERs.ToList();
            //System.Diagnostics.Debug.WriteLine(email);
            MEMBER member = grandBlue.MEMBERs.Where(temp => temp.email == email).SingleOrDefault();
            //System.Diagnostics.Debug.WriteLine(member.mobile);
            grandBlue.MEMBERs.Remove(member);
            grandBlue.SaveChanges();
            return RedirectToAction("Members", "Admin");
        }

        public ActionResult UpdateRooms()
        {
            //grandBlue.Entry(member).State = System.Data.Entity.EntityState.Modified;
            //grandBlue.SaveChanges();
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}