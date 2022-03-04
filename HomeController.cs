using System;
using System.Collections.Generic;

using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication23.Controllers
{
    public class HomeController : Controller
    {
        ammuEntities db = new ammuEntities();

        public ActionResult Doctor()
        {
            return View(db.Doctors.ToList());
        }

        public ActionResult Index()
        {
            return View(db.logins.ToList());
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signup(login lg)
        {
            if (db.logins.Any(x => x.UserName == lg.UserName))
            {
                ViewBag.Notification = "This account is already created";
                return View();
            }
            else
            {
                db.logins.Add(lg);
                db.SaveChanges();
                Session["IdSS"] = lg.Id.ToString();
                Session["UserNameSS"] = lg.UserName.ToString();
                return RedirectToAction("Login", "Home");
            }

        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(login lg)
        {
            var checklogin = db.logins.Where(x => x.UserName.Equals(lg.UserName) && x.Password.Equals(lg.Password)).FirstOrDefault();
            if (checklogin != null)
            {
                Session["IdSS"] = lg.Id.ToString();
                Session["UserNameSS"] = lg.UserName.ToString();
                return RedirectToAction("Create", "Home");
            }
            else
            {
                ViewBag.Notification = "Wrong UserName or Password";
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Delete1(int id)
        {
            Doctor s = new Doctor();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor employee = db.Doctors.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmeds(int id)
        {
            Doctor employee = db.Doctors.Find(id);
            db.Doctors.Remove(employee);
            db.SaveChanges();
            return View();
        }
        public ActionResult Patient()
        {
            return View(db.Patients.ToList());
        }
        [HttpGet]
        public ActionResult Create()//create one record
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientId,Name,Age,MobileNumber,Purpose")] Patient pat)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(pat);
                db.SaveChanges();
                return RedirectToAction("Doctor");
            }

            return View(pat);
        }
        public ActionResult Appoin()
        {
            return View(db.Appointments.ToList());
        }
        [HttpGet]
        public ActionResult Appointment()//create one record
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Appointment([Bind(Include = "AppointmentId,Appointmentdate,Appointmenttime")] Appointment app)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(app);
                db.SaveChanges();
                ViewBag.Notification = "Appointment Fixed";
                return RedirectToAction("Pres");
            }

            return View(app);
        }
        public ActionResult pres()
        {
            return View(db.Prescriptions.ToList());
        }

        [HttpGet]
        public ActionResult Prescription()//create one record
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Prescription([Bind(Include = "DoctorId,Name,Speciality,Experience")] Prescription pp)
        {
            if (ModelState.IsValid)
            {
                db.Prescriptions.Add(pp);
                db.SaveChanges();
                ViewBag.Notification = "Appointment Fixed";
                return RedirectToAction("Logout");
            }

            return View(pp);
        }
        public ActionResult Delete(int? Id)//delete the employee record
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient employee = db.Patients.Find(Id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? Id)
        {
            Patient employee = db.Patients.Find(Id);
            db.Patients.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Patient");
        }

    }
}
