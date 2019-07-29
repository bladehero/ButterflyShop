using ButterflyShop.Web.Models.HomeModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ButterflyShop.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var model = new IndexVM
            {
                Brands = UnitOfWork.Brands.Random(2),
                NewItems = 
            };

            return View(model);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
