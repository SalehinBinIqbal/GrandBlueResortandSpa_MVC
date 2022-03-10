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
        public ActionResult Index(MEMBER member)
        {
            var loggedin = false;
            var checklogin = grandBlue.MEMBERs.Where(temp => temp.email.Equals(member.email) & temp.password.Equals(member.password)).FirstOrDefault();
            if (loggedin == true)
            {
                ViewBag.Email = "Member already logged in";
                return RedirectToAction("Home/Index");
            }
        
            else if (checklogin != null)
            {
                Session["email"] = checklogin.email;
                ViewBag.Login = "login check";
                loggedin = true;
                return RedirectToAction("Profile");
            }
            else
            {

                ViewBag.Notification = "Wrong Email or password";
                return View();
            }
        }
        public ActionResult Profile()
        {
            return View();
        }
    }
}