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
        public ActionResult Book(string name, string gender, string email, 
                                string mobile, string nationalId, string dob, string nationality, string password,
                                string selectedroom, string checkin, string checkout)
        {
            BOOKING booking = new BOOKING();
            booking.name = name;
            booking.gender = gender;
            booking.email = email;
            booking.mobile = mobile;
            booking.nationalId = nationalId;
            booking.dob = dob;
            booking.nationality = nationality;
            booking.selectedroom = selectedroom;
            booking.checkin = checkin;
            booking.checkout = checkout;
            grandBlue.BOOKINGs.Add(booking);
            grandBlue.SaveChanges();

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

            return RedirectToAction("Index");
            //return View();
        }
    }
}