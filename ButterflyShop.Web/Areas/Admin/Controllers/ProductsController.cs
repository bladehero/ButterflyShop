using ButterflyShop.Web.Areas.Admin.Models.ProductsModel;
using ButterflyShop.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ButterflyShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : AdminController
    {
        public IActionResult Index(string search)
        {
            var model = new IndexVM
            {
                Products = UnitOfWork.StoredProcedures.GetProductsInfo_Admin(search)
            };

            return View(model);
        }

        public IActionResult _Product(int? id)
        {
            var model = new ProductVM
            {

            };

            return View();
        }
    }
}