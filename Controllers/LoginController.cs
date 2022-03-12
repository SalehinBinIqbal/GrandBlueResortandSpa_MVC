using GrandBlueResortandSpa.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

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
        public ActionResult Index(MEMBER member)
        {
            //var loggedin = false;

            if (Session["email"] == null)
            {
                ViewBag.Email = "Member already logged in";
                RedirectToAction("Index", "Home");
            }
            var checklogin = grandBlue.MEMBERs.Where(temp => temp.email.Equals(member.email) & temp.password.Equals(member.password)).FirstOrDefault();
            if (checklogin != null)
            {
                Session["email"] = checklogin.email;
                Session["password"] = checklogin.password;
                //ViewBag.Login = "login check";
                return RedirectToAction("Profile");
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


            if (Session["email"] != null)
            {
                string userEmail = Session["email"].ToString();
                MEMBER member = new MEMBER();

                //List<MEMBER> members = grandBlue.MEMBERs.Where(x => x.email.Equals(userEmail)).ToList();
                member = grandBlue.MEMBERs.SingleOrDefault(x => x.email.Equals(userEmail));

                if (member != null)
                {
                    TempData["memberID"] = member.MemId;
                    TempData["memberName"] = member.name;
                    TempData["memberGender"] = member.gender;
                    TempData["memberEmail"] = member.email;
                    TempData["memberMobile"] = member.mobile;
                    TempData["memberNID"] = member.nationalId;
                    TempData["memberDOB"] = member.dob;
                    TempData["memberNationality"] = member.nationality;
                    TempData["memberPassword"] = member.password;

                }
                List<BOOKING> booking = grandBlue.BOOKINGs.Where(x => x.nationalId.Equals(member.nationalId)).OrderByDescending(x => x.bookid).Take(1).ToList();
                int visitCount = grandBlue.BOOKINGs.Where(temp => temp.email.Equals(member.email)
                                                  && temp.nationalId.Equals(member.nationalId)).Count();
                TempData["memberVisit"] = visitCount;
                return View(booking);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpPost]
        public ActionResult updateContact(string phone)
        {

            if (Session["email"] != null)
            {
                string userEmail = Session["email"].ToString();
                MEMBER member = new MEMBER();

                member = grandBlue.MEMBERs.SingleOrDefault(x => x.email.Equals(userEmail));

                if (member != null)
                {

                    member.mobile = phone;
                    grandBlue.SaveChanges();
                }

                if (member != null)
                {
                    TempData["memberID"] = member.MemId;
                    TempData["memberName"] = member.name;
                    TempData["memberGender"] = member.gender;
                    TempData["memberEmail"] = member.email;
                    TempData["memberMobile"] = member.mobile;
                    TempData["memberNID"] = member.nationalId;
                    TempData["memberDOB"] = member.dob;
                    TempData["memberNationality"] = member.nationality;
                    TempData["memberPassword"] = member.password;
                }
                //Update in book table
                //BOOKING book = (BOOKING)grandBlue.BOOKINGs.Where(temp => temp.email.Equals(member.email) && temp.nationalId.Equals(member.nationalId));

                //if (book != null)
                //{
                //  book.mobile = phone;
                //}

                List<BOOKING> booking = grandBlue.BOOKINGs.Where(x => x.nationalId.Equals(member.nationalId)).OrderByDescending(x => x.bookid).Take(1).ToList();

                int visitCount = grandBlue.BOOKINGs.Where(temp => temp.email.Equals(member.email)
                                                  || temp.nationalId.Equals(member.nationalId)).Count();
                TempData["memberVisit"] = visitCount;


                return View(booking);
                //return RedirectToAction("Profile");


            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult ResetPass(string curpass, string newpass, string conpass)
        {

            if (curpass == Session["password"])
            {
                if (newpass == conpass)
                {
                    string userEmail = Session["email"].ToString();
                    MEMBER member = new MEMBER();
                    member = grandBlue.MEMBERs.SingleOrDefault(x => x.email.Equals(userEmail));



                    member.password = conpass;
                    grandBlue.SaveChanges();

                    return RedirectToAction("Profile");
                }
                else
                {
                    ViewBag.msg = "Password does not match";
                    return RedirectToAction("Profile");
                }

            }
            else
            {
                ViewBag.msg = "Incorrect Password";
                return RedirectToAction("Profile");
            }


        }


    }
}