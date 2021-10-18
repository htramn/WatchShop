using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WatchShop.EntityFramework;

namespace WatchShop.Areas.Admin.Controllers
{
    public class ContactEmailsController : Controller
    {
        private WatchShopContext db = new WatchShopContext();

        // GET: Admin/ContactEmails
        public ActionResult Index()
        {
            return View(db.contactEmails.ToList());
        }

        // GET: Admin/ContactEmails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEmail contactEmail = db.contactEmails.Find(id);
            if (contactEmail == null)
            {
                return HttpNotFound();
            }
            return View(contactEmail);
        }

        // GET: Admin/ContactEmails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ContactEmails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Content,Status")] ContactEmail contactEmail)
        {
            if (ModelState.IsValid)
            {
                db.contactEmails.Add(contactEmail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactEmail);
        }

        // GET: Admin/ContactEmails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEmail contactEmail = db.contactEmails.Find(id);
            if (contactEmail == null)
            {
                return HttpNotFound();
            }
            return View(contactEmail);
        }

        // POST: Admin/ContactEmails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Content,Status")] ContactEmail contactEmail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactEmail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactEmail);
        }

        // GET: Admin/ContactEmails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEmail contactEmail = db.contactEmails.Find(id);
            if (contactEmail == null)
            {
                return HttpNotFound();
            }
            return View(contactEmail);
        }

        // POST: Admin/ContactEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactEmail contactEmail = db.contactEmails.Find(id);
            db.contactEmails.Remove(contactEmail);
            db.SaveChanges();
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
    }
}
