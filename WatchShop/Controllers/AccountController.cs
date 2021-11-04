using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var session = (UserLogin)Session[Common.CommonConst.USER_SESSION];
            var dao = new UserDAO();
            var user = dao.GetById(session.UserName);
            return View(user);
        }
        public ActionResult AccountManagement()
        {
            var session = (UserLogin)Session[Common.CommonConst.USER_SESSION];
            var dao = new UserDAO();
            var user = dao.GetById(session.UserName);
            return View(user);
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
    }
}