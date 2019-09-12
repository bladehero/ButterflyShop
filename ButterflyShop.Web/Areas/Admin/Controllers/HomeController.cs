using ButterflyShop.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ButterflyShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : AdminController
    {
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
    }
}