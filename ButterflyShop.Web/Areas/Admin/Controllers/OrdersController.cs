using Microsoft.AspNetCore.Mvc;

namespace ButterflyShop.Web.Areas.Admin.Controllers
{
    public class OrdersController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}