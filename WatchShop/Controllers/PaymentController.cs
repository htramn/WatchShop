using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.Common;
using WatchShop.DAO;
using WatchShop.EntityFramework;
using WatchShop.Models;
using WatchShop.ViewModel;

namespace WatchShop.Controllers
{
    public class PaymentController : BaseController
    {
        WatchShopContext db = new WatchShopContext();
        // GET: Payment
        [HttpGet]
        public ActionResult ConfirmPayment()
        {
            var cart = Session[CommonConst.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            ConfirmPayment confirmPayment = new ConfirmPayment();
            confirmPayment.ListProduct = list;

            //Lấy ra user đã lưu ở session
            var session = (UserLogin)Session[CommonConst.USER_SESSION];

            //Tìm trong db, gửi qua viewbag mục đích để hiển thị các thông tin của user
            var dao = new UserDAO();
            ViewBag.User = dao.GetById(session.UserName);

            ViewBag.MethodId = new SelectList(db.PaymentMethods, "MethodId", "MethodName", confirmPayment.MethodId);
            return View(confirmPayment);
        }
        //[HttpPost]
        //public ActionResult ConfirmPayment(ConfirmPayment confirmPayment)
        //{

        //}


    }
}