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
        GrandBlueEntities grandBlue = new GrandBlueEntities();
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
        public ActionResult Book(BOOKING booking, string name, string gender, string email, 
                                string mobile, string nationalId, string dob, string nationality, string password)
        {
            int resCount = grandBlue.MEMBERs.Where(temp => temp.email.Equals(email) || temp.mobile.Equals(mobile) 
                                                  || temp.nationalId.Equals(nationalId)).Count();
            if(resCount > 0)
            {
                TempData["msg"] = "Member already exists.";
            }
            else
            {
                MEMBER member = new MEMBER();
                member.name = name;
                member.gender = gender;
                member.email = email;
                member.mobile = mobile;
                member.nationalId = nationalId;
                member.dob = dob;
                member.nationality = nationality;
                member.password = password;
                grandBlue.MEMBERs.Add(member);
                grandBlue.SaveChanges();
            }
            grandBlue.BOOKINGs.Add(booking);
            grandBlue.SaveChanges();
            return RedirectToAction("Index");
            //return View();
        }
    }
}