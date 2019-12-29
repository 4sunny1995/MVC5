using SunShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SunShop.Controllers
{
    public class CheckingController : Controller
    {
        // GET: Checking
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstant.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "HomeBasic", action = "index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}