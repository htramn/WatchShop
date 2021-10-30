using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WatchShop.Common;
using WatchShop.EntityFramework;
using WatchShop.Models;

namespace WatchShop.Controllers
{
    public class CartController : Controller
    {
        private WatchShopContext db = new WatchShopContext();
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CommonConst.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult AddItem(int productId, int quantity)
        {
            Product product = db.Products.Find(productId);
            var cart = Session[CommonConst.CartSession];
            if (cart != null)
            {
                //ép kiểu
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ProductId == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ProductId == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CommonConst.CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CommonConst.CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        public JsonResult DeleteAll()
        {
            Session[CommonConst.CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CommonConst.CartSession];
            sessionCart.RemoveAll(x => x.Product.ProductId == id);
            Session[CommonConst.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CommonConst.CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ProductId == item.Product.ProductId);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CommonConst.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
    }
}