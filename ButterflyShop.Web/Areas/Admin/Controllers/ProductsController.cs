using ButterflyShop.Web.Areas.Admin.Models.ProductsModel;
using ButterflyShop.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ButterflyShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _ProductList(string search)
        {
            var products = UnitOfWork.StoredProcedures.GetProductsInfo_Admin(search);
            return PartialView(products);
        }

        public IActionResult _Product(int? id)
        {
            var model = new ProductVM();
            model.Brands = UnitOfWork.Brands.FindAll();
            model.Categories = UnitOfWork.Categories.FindAll();
            model.Characteristics = UnitOfWork.Characteristics.FindAll();
            model.OptionalParameters = UnitOfWork.OptionalParameters.FindAll();
            model.ProductImages = UnitOfWork.StoredProcedures.GetProductImages(id);
            model.SelectedCategories = UnitOfWork.CategoryProducts.Find()
            model.SelectedCharacteristics = UnitOfWork.

            return View();
        }
    }
}