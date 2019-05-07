using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using App01.Models;

namespace App01.Controllers
{
    public class StudentController : Controller
    {
        private rmsCoders_r01Entities db = new rmsCoders_r01Entities();

        // GET: Student
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,LastName,FirstName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,LastName,FirstName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            DateTime date72hoursAgo = DateTime.Now.AddHours(-72);
            if ( (date72hoursAgo.CompareTo(student.EnrollmentDate)) >= 0)
            {
                // means 72 hours or more have passed
                db.Students.Remove(student);
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Notify(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        //      /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Notify([Bind(Include = "StudentID,LastName,FirstName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                student.EnrollmentDate = @DateTime.Now;
                db.SaveChanges();
                SendEmail("From:RMS_COders", "tayyabasuleman175@gmail.com", "To_User", "rehan.aryan@hotmail.com", "Account Delete Notification", "Your account may be deleted in next 72 hours", "", "");
    //         SendEmail("From:RMS_COders", "tayyabasuleman175@gmail.com", "To_User", student.FirstName, "Account Delete Notification", "Your account may be deleted in next 72 hours", "","");
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public static void SendEmail(string FromName, string FromEmail, string ToName, string ToEmail, string Subjecttt, string body, string CC, string File)
        {
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                MailAddress from = new MailAddress(FromEmail, FromName);
                MailAddress To = new MailAddress(ToEmail, ToName);
                mail.From = from;
                mail.To.Add(To);
                if (CC != "")
                    mail.Bcc.Add(CC);
                mail.IsBodyHtml = true;
                mail.Body = body;
                MailMessage message = new MailMessage(from, To);
                mail.Subject = Subjecttt;
                mail.IsBodyHtml = true;
                SmtpClient mailer = new SmtpClient();
                mailer.Host = "smtp.1and1.com";
                mailer.Credentials = new System.Net.NetworkCredential("test@systelligence.com", "test123");
                mailer.Send(mail);
            }

            catch (SmtpException ex)
            {

            }
        }

        //    */

    }
}