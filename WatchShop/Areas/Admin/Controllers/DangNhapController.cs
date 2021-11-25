using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WatchShop.Common;
using WatchShop.DAO;
using WatchShop.ViewModel;

namespace WatchShop.Areas.Admin.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: Admin/Account
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "UserName,Password")] Login model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName, model.Password,true);
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.UserId;
                    userSession.UserRoleId = user.UserRoleId;                   
                    Session.Add(CommonConst.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Products");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập.");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng.");
                }
            }
         
            return View("Login");
        }
        public ActionResult Logout()
        {
            Session[CommonConst.USER_SESSION] = null;
            return Redirect("/");
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}