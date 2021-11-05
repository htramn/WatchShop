using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using WatchShop.DAO;
using WatchShop.EntityFramework;
namespace WatchShop.Controllers
{
    public class ProductController : Controller
    {
        private WatchShopContext db = new WatchShopContext();
        // GET: Product

        public ActionResult ProductList()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Color).Include(p => p.CreatedPerson).Include(p => p.Material).Include(p => p.ModifiedPerson).Include(p => p.Supplier);
            return View(products.ToList());
        }

        public ActionResult PromotionProduct()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Color).Include(p => p.CreatedPerson)
                                      .Include(p => p.Material).Include(p => p.ModifiedPerson).Include(p => p.Supplier)
                                      .Where(p=>p.PromotionPrice!=null);
            return View(products.ToList());
        }



        // GET: Product/Details/5
        public ActionResult ProductDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dao = new ProductDAO();
            Product product = dao.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.RelatedProducts = dao.GetRelatedProducts(id);
            return View(product);
        }

        // GET: Product/Create

     

     
    }
}
