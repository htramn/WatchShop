using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.Common;
using WatchShop.Models;
using WatchShop.EntityFramework;
using WatchShop.DAO;

namespace WatchShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BlogDAO blogDao = new BlogDAO();
            ProductDAO dao = new ProductDAO();
            ViewBag.BestSeller = dao.BestSeller().Take(10);
            ViewBag.Newest = dao.Newest().Take(10);
            ViewBag.Sale = dao.PromotionList().Take(10);
            ViewBag.Blog = blogDao.GetListBlogs().Take(3);
            return View();
        }

        public ActionResult About()
        {
           return View();
        }

        public ActionResult Contact()
        {
            ContactEmail email = new ContactEmail();
            return View(email);
        }
        [HttpPost]
        public ActionResult Contact(ContactEmail contactEmail)
        {
            ContactEmail email = new ContactEmail();
            email.Email = contactEmail.Email;
            email.Content = contactEmail.Content;
            email.Status = false;
            ContactDAO dao = new ContactDAO();
            var result = dao.Insert(email);
            if (result>0)
            {
                ViewBag.Success = "Gửi thành công";
            }
            else
            {
                ViewBag.Failed = "Gửi thất bại";
            }
            return View();
        }


        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConst.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }
    }
}