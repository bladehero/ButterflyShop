using ButterflyShop.Web.Models.AccountModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Text;

namespace ButterflyShop.Web.Controllers
{
    public class AccountController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(LoginViewVM model = null)
        {
            if (model == null)
            {
                model = new LoginViewVM();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult SignIn(LoginVM model)
        {
            var password = UnitOfWork.StoredProcedures.MD5HashPassword(model.Password);
            if (UnitOfWork.Users.FirstOrDefault(x => x.Password == password && x.Email == model.Username) is DAL.Models.User user)
            {
                // TODO: Перенаправление в личный кабинет.
            }
            return View("Login", new LoginViewVM { LoginVM = model, Error = "Неверный логин или пароль!" });
        }

        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.RepeatPassword)
                {
                    return View("Login", new LoginViewVM { RegisterVM = model, Error = "Пароли не совпадают!" });
                }
                else if (UnitOfWork.Users.FirstOrDefault(x => x.Email == model.Username) is DAL.Models.User user)
                {
                    return View("Login", new LoginViewVM { RegisterVM = model, Error = "Такой пользователь уже зарегистрирован в системе!" });
                }
                else
                {
                    // TODO: Перенаправление в личный кабинет.
                    return View("Login");
                }
            }
            else
            {
                var sb = new StringBuilder("<ul>");
                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        sb.Append("<li>- ");
                        sb.Append(error.ErrorMessage);
                        sb.Append("</li>");
                    }
                }
                sb.Append("</ul>");
                return View("Login", new LoginViewVM { RegisterVM = model, Error = sb.ToString() });
            }
        }
    }
}