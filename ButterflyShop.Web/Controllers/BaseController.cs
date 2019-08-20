using ButterflyShop.DAL;
using ButterflyShop.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Data.SqlClient;

namespace ButterflyShop.Web.Controllers
{
    public class BaseController : Controller
    {
        public const string AuthCookie = "__auth__butterfly__";

        protected User SystemUser { get; set; }
        protected bool Anonymous => !(SystemUser is User user && user.Id != 0 && user.Token != Guid.Empty);
        protected UnitOfWork UnitOfWork { get; private set; }

        public BaseController()
        {
            UnitOfWork = new UnitOfWork(new SqlConnection(GlobalVariables.ConnectionString));
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var authCookieValue = GetCookie(AuthCookie);
            if (Guid.TryParse(authCookieValue, out Guid token))
            {
                SystemUser = UnitOfWork.Users.FindByToken(token);
            }

            ViewBag.SystemUser = SystemUser;
            ViewBag.Anonymous = Anonymous;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            UnitOfWork.Dispose();
        }

        protected void Login(string token)
        {
            if (!Anonymous)
            {
                SetCookie(AuthCookie, SystemUser.Token.ToString());
            }
        }
        protected void Logout()
        {
            if (!Anonymous)
            {
                RemoveCookie(AuthCookie);
            }
        }

        protected string GetCookie(string key)
        {
            return Request.Cookies[key];
        }
        protected void SetCookie(string key, string value)
        {
            var options = new CookieOptions()
            {
                Path = "/",
                HttpOnly = false,
                IsEssential = true,
                Expires = DateTime.Now.AddYears(100)
            };
            Response.Cookies.Append(key, value, options);
        }
        protected void RemoveCookie(string key)
        {
            Response.Cookies.Delete(key);
        }
    }
}
