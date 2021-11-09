using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.DAO;
using PagedList;

namespace WatchShop.Controllers
{
    public class SearchController : Controller
    {
        public JsonResult ListName(string q)
        {
            var data = new ProductDAO().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Result(string keyword, int? page)
        {
            var dao = new ProductDAO();
            var result = dao.SearchResult(keyword);
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            ViewBag.Key = keyword;
            return View(result.ToPagedList(pageNumber, pageSize));
        }
    }
}