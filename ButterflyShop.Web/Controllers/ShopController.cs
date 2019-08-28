using ButterflyShop.Web.Extensions;
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
            var products = UnitOfWork.StoredProcedures.GetItemsInfo(null, userId: SystemUser?.Id);
            var model = new IndexVM
            {
                Products = products.ChunkBy(6),
                CategoryHierarchy = UnitOfWork.StoredProcedures.GetCategoryHierarchy(),
                MinPrice = products.Min(x => x.Price),
                MaxPrice = products.Max(x => x.Price)
            };
            return View(model);
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