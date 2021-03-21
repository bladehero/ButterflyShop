using FleaMarket.Web.Areas.Admin.Models.HomeModels;
using FleaMarket.Web.Controllers;
using FleaMarket.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FleaMarket.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : AdminController
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginVM model)
        {
            bool success;
            string message = string.Empty;
            try
            {
                var password = UnitOfWork.StoredProcedures.MD5HashPassword(model.Password);
                var user = UnitOfWork.Users.FirstOrDefault(x => x.Password == password && x.Email == model.Login 
                && x.RoleId == UnitOfWork.StoredProcedures.GetUserRoleId(UserRole.Administrator.GetDescription()));
                if (success = ModelState.IsValid && user is DAL.Models.User)
                {
                    SetAuth(AuthKey, user.Token.ToString());
                }
                else if (!ModelState.IsValid)
                {
                    message = ModelState.GetHtmlErrors();
                }
                else
                {
                    message = "Неверный логин или пароль!";
                }
            }
            catch (Exception ex)
            {
                success = false;
                message = "Возникла непредвиденная ошибка!";
            }
            return Json(new { success, message });
        }

        [HttpGet]
        [AllowAnonymous]
        public new IActionResult Logout()
        {
            base.Logout();
            return RedirectToAction("Login", "Home", new { area = "Admin" });
        }
    }
}