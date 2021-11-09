using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.DAO;
using WatchShop.EntityFramework;

namespace WatchShop.Controllers
{
    public class PromotionController : Controller
    {
        public ActionResult PromotionProduct(string sortOrder, int? page)
        {
            ProductDAO dao = new ProductDAO();
            IEnumerable<Product> list;
            ViewBag.CurrentSort = sortOrder;
            switch (sortOrder)
            {
                case "Newest":
                    list = dao.NewestPromotion();
                    break;
                case "BestSeller":
                    list = dao.BestSellerPromotion();
                    break;
                case "AscendingPrice":
                    list = dao.AscendingPricePromotion();
                    break;
                case "DescendingPrice":
                    list = dao.DescendingPricePromotion();
                    break;
                default:
                    list = dao.PromotionList();
                    break;
            }
            int pageSize = 16;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
        }
    }
}