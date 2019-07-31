using ButterflyShop.Web.Models.HomeModels;
using Microsoft.AspNetCore.Mvc;

namespace ButterflyShop.Web.Controllers
{
    public class HomeController : BaseController
    {
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
