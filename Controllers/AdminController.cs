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
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<BOOKING> bookingList = grandBlue.BOOKINGs.ToList();
                return View(bookingList);
            }
   
        }

        public ActionResult Members()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<MEMBER> memberList = grandBlue.MEMBERs.ToList();
                return View(memberList);
            }
            
        }
        public ActionResult Delete(string email)
        {
            MEMBER member = grandBlue.MEMBERs.Where(temp => temp.email == email).SingleOrDefault();
            grandBlue.MEMBERs.Remove(member);
            grandBlue.SaveChanges();
            return RedirectToAction("Members", "Admin");
        }

        public ActionResult UpdateRooms()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<ROOM> roomList = grandBlue.ROOMs.ToList();
                return View(roomList);
            }
        }

        public ActionResult Updateosv(ROOM roomosv)
        {
            ROOM room = grandBlue.ROOMs.SingleOrDefault();
            System.Diagnostics.Debug.WriteLine(roomosv.osv);
            room.osv = roomosv.osv;
            grandBlue.Entry(room).State = System.Data.Entity.EntityState.Modified;
            grandBlue.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Updateofv(ROOM roomfv)
        {
            ROOM room = grandBlue.ROOMs.SingleOrDefault();
            System.Diagnostics.Debug.WriteLine(roomfv.osv);
            room.osv = roomfv.osv;
            grandBlue.Entry(room).State = System.Data.Entity.EntityState.Modified;
            grandBlue.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Updateds(ROOM roomds)
        {
            ROOM room = grandBlue.ROOMs.SingleOrDefault();
            System.Diagnostics.Debug.WriteLine(roomds.osv);
            room.osv = roomds.osv;
            grandBlue.Entry(room).State = System.Data.Entity.EntityState.Modified;
            grandBlue.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Updateps(ROOM roomps)
        {
            ROOM room = grandBlue.ROOMs.SingleOrDefault();
            System.Diagnostics.Debug.WriteLine(roomps.osv);
            room.osv = roomps.osv;
            grandBlue.Entry(room).State = System.Data.Entity.EntityState.Modified;
            grandBlue.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Updateosr(ROOM roomosr)
        {
            ROOM room = grandBlue.ROOMs.SingleOrDefault();
            System.Diagnostics.Debug.WriteLine(roomosr.osv);
            room.osv = roomosr.osv;
            grandBlue.Entry(room).State = System.Data.Entity.EntityState.Modified;
            grandBlue.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}