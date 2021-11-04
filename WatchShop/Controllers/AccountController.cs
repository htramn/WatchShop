using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.Common;
using WatchShop.DAO;
using WatchShop.EntityFramework;
using WatchShop.ViewModel;

namespace WatchShop.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {         
            return View(GetUser());
        }
        public ActionResult AccountManagement()
        {
            
            return View(GetUser());
        }
        [HttpPost]
        public ActionResult AccountManagement([Bind(Include = "UserId,UserName,Password,UserRoleId,Name,Address,Email,Phone,Province,District,Status,CreatedDate")] User user)
        {
            var dao = new UserDAO();
            var result = dao.Update(user);
            if (result)
            {
                ViewBag.Success = "Cập nhật thành công";
            }
            else
            {
                ViewBag.Failed = "Cập nhật thất bại";
            }
            return View(user);
        }

        public ActionResult OrderDetail(int id)
        {
            var dao = new OrderDAO();
            var Order = dao.GetById(id);
            return View(Order);
        }
        public ActionResult CancelOrder(int id,string reasonCacel)
        {
            var dao = new OrderDAO();
            dao.Cancel(id, OrderStatusConst.Huy,reasonCacel);
            return RedirectToAction("Index");
        }
        public ActionResult Rating(int idProduct, long rating,string comment)
        {
            User user = GetUser();
            var dao = new ReviewDAO();
            var review = new Review();
            review.Comment = comment;
            review.ProductId = idProduct;
            review.Rating = rating;
            review.CustomerId = user.UserId;
            dao.Insert(review);
            return RedirectToAction("Index");
        }
        private User GetUser()
        {
            var session = (UserLogin)Session[CommonConst.USER_SESSION];
            var dao = new UserDAO();
            var user = dao.GetById(session.UserName);
            return (user);
        }
    }
}