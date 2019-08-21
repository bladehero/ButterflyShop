using ButterflyShop.Web.Models.HomeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ButterflyShop.Web.Controllers
{
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new IndexVM
            {
                Brands = UnitOfWork.Brands.FindAll(),
                NewItems = UnitOfWork.StoredProcedures.GetItemsInfo(8, newItems: true),
                SaleItems = UnitOfWork.StoredProcedures.GetItemsInfo(8, saleItems: true)
            };

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult AboutUs()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
