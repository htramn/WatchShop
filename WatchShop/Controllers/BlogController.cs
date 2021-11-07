using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.DAO;
using PagedList;
using System.Net;
using WatchShop.EntityFramework;

namespace WatchShop.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index(int? page)
        {
            var productDao = new ProductDAO();
            ViewBag.Product = productDao.GetListProducts().Take(3);
            var dao = new BlogDAO();
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(dao.GetListBlogs().ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Detail(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productDao = new ProductDAO();
            ViewBag.Product = productDao.GetListProducts().Take(3);
            var dao = new BlogDAO();
            Blog blog = dao.GetById(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            
            return View(blog);
        }

        //[ChildActionOnly]
        //public PartialViewResult SlideMenuBlog()
        //{
        //    var productDao = new ProductDAO();
        //    ViewBag.Product = productDao.GetListProducts().Take(3);
        //    return PartialView();
        //}
    }
}