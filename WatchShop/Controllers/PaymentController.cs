using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult AddCoupon(string code)
        {
            if(code==null)
            {
                Session[CommonConst.CouponSession] = "";
            }
            else
            {
                var coupon = db.Coupons.SingleOrDefault(c => c.Code == code);
                if (coupon == null)
                {
                    ModelState.AddModelError("", "Mã giảm giá không hợp lệ");
                }
                else
                {
                    if (coupon.Status == true)
                    {
                        Session[CommonConst.CouponSession] = coupon;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mã giảm giá đã hết hạn");
                    }
                }
            }  
            return RedirectToAction("ConfirmPayment");
        }
        [HttpGet]
        public ActionResult ConfirmPayment()
        {
            var cart = Session[CommonConst.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            var coupon = Session[CommonConst.CouponSession];
             
          
            ConfirmPayment confirmPayment = new ConfirmPayment();
            confirmPayment.ListProduct = list;
            if (coupon != null)
            {
                confirmPayment.Coupon =(Coupon)coupon;
                confirmPayment.CouponId = confirmPayment.Coupon.CouponId;
            }

            //Lấy ra user đã lưu ở session
            var session = (UserLogin)Session[CommonConst.USER_SESSION];

            //Tìm trong db, gửi qua viewbag mục đích để hiển thị các thông tin của user
            var dao = new UserDAO();
            ViewBag.User = dao.GetById(session.UserName);

            ViewBag.MethodId = new SelectList(db.PaymentMethods, "MethodId", "MethodName", confirmPayment.MethodId);
            return View(confirmPayment);
        }
        [HttpPost]
        public ActionResult ConfirmPayment([Bind(Include = "MethodId,Note")] ConfirmPayment confirmpayment)
        {
            using (var context = new WatchShopContext())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //ĐỌc session:
                        var cart = (List<CartItem>)Session[CommonConst.CartSession];
                        var coupon = (Coupon)Session[CommonConst.CouponSession];
                        var session = (UserLogin)Session[CommonConst.USER_SESSION];

                        ConfirmPayment confirm = new ConfirmPayment();
                        confirm.ListProduct = cart;
                        if(coupon!=null)
                        {
                            confirm.CouponId = coupon.CouponId;
                        }    
                        
                        confirm.Coupon = coupon;

                        //Tạo một order mới
                        var order = new Order();
                        //Ngày đặt hàng
                        order.OrderDate = DateTime.Now;
                        //MÃ giảm giá
                        order.CouponId = confirm.CouponId;
                        //Người đặt hàng
                        order.UserId = session.UserID;
                        //Trạng thái đơn hàng
                        order.StatusId = 1;
                        //Ghi chú đơn hàng
                        order.Note = confirmpayment.Note;
                        //Phương thức thanh toán
                        order.MethodId = confirmpayment.MethodId;
                        //Tổng thanh toán
                        order.TotalPayment = confirm.TotalPayment;

                        OrderDAO orderDAO = new OrderDAO();
                        int id = orderDAO.Insert(order);

                        foreach (var item in cart)
                        {
                            OrderDetail orderDetail = new OrderDetail();
                            orderDetail.OrderId = id;
                            orderDetail.ProductId = item.Product.ProductId;
                            orderDetail.Price = item.Product.SalePrice;
                            orderDetail.Quantity = item.Quantity;
                            orderDAO.InsertOrderDetail(orderDetail);
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine(ex);
                        return RedirectToAction("FailedPayment");
                    }
                }
            }
            return RedirectToAction("SuccessPayment");
        }
        public ActionResult SuccessPayment()
        {
            return View();
        }
        public ActionResult FailedPayment()
        {
            return View();
        }


    }
}