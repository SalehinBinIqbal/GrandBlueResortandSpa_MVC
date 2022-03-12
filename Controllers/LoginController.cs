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
            if (Session["email"] == null)
            {
                if (TempData["message"] != null)
                {
                    ViewBag.Message = TempData["msg"].ToString();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Profile");
            }
        }
        [HttpPost]
        public ActionResult Index(MEMBER member, ADMIN admin)
        {
            //var loggedin = false;
            
            if (Session["email"] == null)
            {
                ViewBag.Email = "Member already logged in";
                RedirectToAction("Index", "Home");
            }
            var checklogin = grandBlue.MEMBERs.Where(temp => temp.email.Equals(member.email) & temp.password.Equals(member.password)).FirstOrDefault();
            var checkAdminLogin = grandBlue.ADMINs.Where(temp => temp.email.Equals(admin.email) & temp.password.Equals(admin.password)).FirstOrDefault();
            if (checklogin != null)
            {
                Session["email"] = checklogin.email;
                //ViewBag.Login = "login check";
                return RedirectToAction("Profile");
            }
            else if(checkAdminLogin != null)
            {
                Session["email"] = checkAdminLogin.email;
                //ViewBag.Login = "login check";
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["message"] = "Email or Password does not match! Try again.";
                //ViewBag.Notification = "Wrong Email or password";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Reservation");
        }

        public ActionResult Profile()
        {
            return View();
        }
    }
}