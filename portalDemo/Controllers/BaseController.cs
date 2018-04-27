using Microsoft.AspNet.Identity.Owin;
using portal.Domain.Model;
using portalDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace portalDemo.Controllers
{
    public class BaseController : Controller
    {
        public CurrentUserModel CurrentUser;
        // GET: Base
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public CurrentUserModel currentUser
        {
            get
            {
                return CurrentUser;
            }
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["Controller"].ToString().ToLower();
            var actionName = filterContext.RouteData.Values["Action"].ToString().ToLower();
            var user = filterContext.HttpContext.User;
            var loginInfo = filterContext.HttpContext.Request.Cookies["_formAuthInfo_"];
            //user.Identity.Name
            if (!controllerName.Equals("account"))
            {
                if (loginInfo == null)
                {
                    if (controllerName.Equals("home"))
                    {
                        base.OnActionExecuting(filterContext);
                    }
                    else
                    {
                        filterContext.Result = RedirectToAction("Login", "Account");
                    }
                }
                else
                {
                    var model = System.Web.Helpers.Json.Decode(loginInfo.Value, typeof(UserInfoModel));

                    CurrentUser = new CurrentUserModel()
                    {
                        UserName = model.Name,
                        UserId = model.Id
                    };
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}