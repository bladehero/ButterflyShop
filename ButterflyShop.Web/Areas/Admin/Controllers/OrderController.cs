using Microsoft.AspNetCore.Mvc;

namespace ButterflyShop.Web.Areas.Admin.Controllers
{
    public class OrderController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}