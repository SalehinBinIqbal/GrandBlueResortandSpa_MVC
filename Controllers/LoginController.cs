using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrandBlueResortandSpa.Models;

namespace GrandBlueResortandSpa.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login\
        GrandBlueEntities grandBlue = new GrandBlueEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(String email, String password)
        {
            int resCount = grandBlue.MEMBERs.Where(temp => temp.email.Equals(email) & temp.password.Equals(password)).Count();
            if (resCount > 0)
            {
                List<MEMBER> user = grandBlue.MEMBERs.Where(temp => temp.email.Equals(email)).ToList();
                foreach (var i in user)
                {
                    Session["username"] = i.email;
                    //Session["userType"] = i.type;
                }

                return RedirectToAction("Profile");
            }
            else
            {

                TempData["msg"] = "Email or Password does not match! Try again.";
                return RedirectToAction("Home/Index");
            }
        }
        public ActionResult Profile()
        {
            return View();
        }
    }
}