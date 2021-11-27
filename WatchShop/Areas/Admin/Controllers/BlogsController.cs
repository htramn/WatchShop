using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WatchShop.Common;
using WatchShop.DAO;
using WatchShop.EntityFramework;
using WatchShop.ViewModel;

namespace WatchShop.Areas.Admin.Controllers
{
    public class BlogsController : BaseController
    {

        // GET: Admin/Blogs
        public ActionResult Index()
        {
            var dao = new BlogDAO();
            var blogs = dao.GetListBlogs();
            return View(blogs.ToList());
        }

        // GET: Admin/Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dao = new BlogDAO();
            var blog = dao.GetById(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Admin/Blogs/Create
        public ActionResult Create()
        {
            var dao = new BlogDAO();
            ViewBag.CreatedBy = new SelectList(dao.db.Users, "UserId", "UserName");
            ViewBag.ModifiedBy = new SelectList(dao.db.Users, "UserId", "UserName");
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogId,Title,Image,Content,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,Description")] Blog blog)
        {
            var dao = new BlogDAO();
            if (ModelState.IsValid)
            {
                UserLogin admin = (UserLogin)Session[CommonConst.USER_SESSION];
                blog.CreatedDate = DateTime.Now;
                blog.CreatedBy = admin.UserID;
                dao.Insert(blog);
                return RedirectToAction("Index");
            }

            ViewBag.CreatedBy = new SelectList(dao.db.Users, "UserId", "UserName", blog.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(dao.db.Users, "UserId", "UserName", blog.ModifiedBy);
            return View(blog);
        }

        // GET: Admin/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            var dao = new BlogDAO();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = dao.GetById(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedBy = new SelectList(dao.db.Users, "UserId", "UserName", blog.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(dao.db.Users, "UserId", "UserName", blog.ModifiedBy);
            return View(blog);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogId,Title,Image,Content,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,Description")] Blog blog)
        {
            var dao = new BlogDAO();
            if (ModelState.IsValid)
            {
                blog.ModifiedDate = DateTime.Now;
                dao.Update(blog);
                return RedirectToAction("Index");
            }
            ViewBag.CreatedBy = new SelectList(dao.db.Users, "UserId", "UserName", blog.CreatedBy);
            ViewBag.ModifiedBy = new SelectList(dao.db.Users, "UserId", "UserName", blog.ModifiedBy);
            return View(blog);
        }

        // GET: Admin/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            var dao = new BlogDAO();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = dao.GetById(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var dao = new BlogDAO();
            Blog blog = dao.GetById(id);
            dao.Delete(blog);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            var dao = new BlogDAO();
            if (disposing)
            {
                dao.db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
