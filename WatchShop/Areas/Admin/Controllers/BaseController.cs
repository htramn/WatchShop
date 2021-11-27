using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WatchShop.ViewModel;

namespace WatchShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[Common.CommonConst.USER_SESSION];
            if (session == null || session.UserRoleId!=1)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "DangNhap", action = "Login" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}