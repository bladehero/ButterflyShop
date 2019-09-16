using ButterflyShop.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ButterflyShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}