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
        public ActionResult Index(MEMBER member, ADMIN admin)
        {
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
                Session["password"] = checklogin.password.ToString();
                return RedirectToAction("Profile");
            }
            else if(checkAdminLogin != null)
            {
                Session["email"] = checkAdminLogin.email;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["message"] = "Email or Password does not match! Try again.";
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
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (Session["email"] != null)
            {
                string userEmail = Session["email"].ToString();
                MEMBER member = new MEMBER();

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
                                                  && temp.nationalId.Equals(member.nationalId)).Count();
                TempData["memberVisit"] = visitCount;

                TempData["contactUpdate"] = "1";
                //return View(booking);
                return RedirectToAction("Profile");


            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult ResetPass(string curpass, string newpass, string conpass)
        {

            if (Session["password"].Equals(curpass))
            {
                if (newpass == conpass)
                {
                    string userEmail = Session["email"].ToString();
                    MEMBER member = new MEMBER();

                    member = grandBlue.MEMBERs.SingleOrDefault(x => x.email.Equals(userEmail));

                    if (member != null)
                    {

                        member.password = newpass;
                        grandBlue.SaveChanges();
                        TempData["passwordUpdated"] = "1";
                    }

                    return RedirectToAction("Profile");
                    //return Content("Successful");

                }
                else
                {
                    ViewBag.msg = "Password does not match";
                    TempData["missMatch"] = "Password Missmatch";
                    return RedirectToAction("Profile");
                    //return Content("Password does not match");
                }

            }
            else
            {
                TempData["ResetPassFlag"] = "Incorrect Password";
                ViewBag.msg = "Incorrect Password";
                return RedirectToAction("Profile");
                //return Content("Incorrect Password");
            }
        }


    }
}