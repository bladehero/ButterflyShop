using ButterflyShop.Web.Models.ShopModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ButterflyShop.Web.Controllers
{
    public class ShopController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new IndexVM
            {
                Products = UnitOfWork.StoredProcedures.GetItemsInfo(8, userId: SystemUser?.Id),
            };
            return View();
        }

        [AllowAnonymous]
        public IActionResult Product(int id)
        {
            var model = new ProductVM
            {
                Product = UnitOfWork.Products.FindById(id),
                Products = UnitOfWork.StoredProcedures.GetItemsInfo(8, userId: SystemUser?.Id),
                Categories = UnitOfWork.StoredProcedures.CategoriesForProduct(id),
                ProductImages = UnitOfWork.StoredProcedures.GetProductImages(id),
                Items = UnitOfWork.Items.Find(x => x.ProductId == id),
                ItemsWithParameters = UnitOfWork.StoredProcedures.GetItemWithParameters(id),
                Favourite = UnitOfWork.FavouriteProducts.Find(x => x.UserId == SystemUser?.Id && x.ProductId == id).Any()
            };
            return View(model);
        }
    }
}