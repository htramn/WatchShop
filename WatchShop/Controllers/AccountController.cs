using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchShop.DAO;
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
    }
}