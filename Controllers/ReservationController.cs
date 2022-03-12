using GrandBlueResortandSpa.Models;
using System.Linq;
using System.Web.Mvc;

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
        public ActionResult BookLogin(string memberEmail, string memberPassword)
        {

            bool memberExist = grandBlue.MEMBERs.Any(x => x.email.Equals(memberEmail) && x.password.Equals(memberPassword));

            if (memberExist)
            {
                Session["flag"] = 1;

                MEMBER memberBook = new MEMBER();
                memberBook = grandBlue.MEMBERs.SingleOrDefault(x => x.email.Equals(memberEmail) && x.password.Equals(memberPassword));
                TempData["memName"] = memberBook.name;
                TempData["memGender"] = memberBook.gender;
                TempData["memEmail"] = memberBook.email;
                TempData["memMobile"] = memberBook.mobile;
                TempData["memNID"] = memberBook.nationalId;
                TempData["memDOB"] = memberBook.dob;
                TempData["memNationality"] = memberBook.nationality;


                Session["memberEmail"] = memberEmail;
                Session["memberPass"] = memberPassword;
                return RedirectToAction("Book");
            }
            else
            {
                return Content("Member Does not exist");
            }
        }

        [HttpPost]
        public ActionResult Book(string name, string gender, string email,
                                string mobile, string nationalId, string dob, string nationality, string password,
                                string selectedroom, string checkin, string checkout)
        {
            //if (Session["flag"] != null && Session["flag"].Equals(1))
            if (Session["memberEmail"] != null)
            {


                MEMBER memberBook = new MEMBER();
                string memberEmail = Session["memberEmail"].ToString();
                string memberPass = Session["memberPass"].ToString();

                memberBook = grandBlue.MEMBERs.SingleOrDefault(x => x.email.Equals(memberEmail) && x.password.Equals(memberPass));
                TempData["memName"] = memberBook.name;
                TempData["memGender"] = memberBook.gender;
                TempData["memEmail"] = memberBook.email;
                TempData["memMobile"] = memberBook.mobile;
                TempData["memNID"] = memberBook.nationalId;
                TempData["memDOB"] = memberBook.dob;
                TempData["memNationality"] = memberBook.nationality;

                string memName = (string)TempData["memName"];
                string memGender = (string)TempData["memGender"];
                string memEmail = (string)TempData["memEmail"];
                string memMobile = (string)TempData["memMobile"];
                string memNID = (string)TempData["memNID"];
                string memDOB = (string)TempData["memDOB"];
                string memNationality = (string)TempData["memNationality"];

                BOOKING booking = new BOOKING();
                booking.name = memName;
                booking.gender = memGender;
                booking.email = memEmail;
                booking.mobile = memMobile;
                booking.nationalId = memNID;
                booking.dob = memDOB;
                booking.nationality = memNationality;
                booking.selectedroom = selectedroom;
                booking.checkin = checkin;
                booking.checkout = checkout;
                grandBlue.BOOKINGs.Add(booking);
                grandBlue.SaveChanges();

                return RedirectToAction("Index");

            }

            else
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
                if (resCount > 0)
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
                //return Content("Failed");
                //return View();
            }
        }
    }
}