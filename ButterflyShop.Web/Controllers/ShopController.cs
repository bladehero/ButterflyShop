using ButterflyShop.Web.Extensions;
using ButterflyShop.Web.Models.ShopModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ButterflyShop.Web.Controllers
{
    public class ShopController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(int? categoryId = null, int? brandId = null)
        {
            var products = UnitOfWork.StoredProcedures.SearchItemInfo(SystemUser?.Id, categoryId, brandId);
            var model = new IndexVM
            {
                Products = products.ChunkBy(6),
                CategoryHierarchy = UnitOfWork.StoredProcedures.GetCategoryHierarchy(),
                MinPrice = UnitOfWork.StoredProcedures.GetProductNumericValueByOption(ProductOption.MinPrice.GetDescription()),
                MaxPrice = UnitOfWork.StoredProcedures.GetProductNumericValueByOption(ProductOption.MaxPrice.GetDescription())
            };
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult FuzzyMatch(string search)
        {
            var products = UnitOfWork.StoredProcedures.SearchItemInfo(SystemUser?.Id, search: search);
            var model = new IndexVM
            {
                Products = products.ChunkBy(6),
                CategoryHierarchy = UnitOfWork.StoredProcedures.GetCategoryHierarchy(),
                MinPrice = UnitOfWork.StoredProcedures.GetProductNumericValueByOption(ProductOption.MinPrice.GetDescription()),
                MaxPrice = UnitOfWork.StoredProcedures.GetProductNumericValueByOption(ProductOption.MaxPrice.GetDescription()),
                Search = search
            };
            return View("Index", model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Search(string categoriesStr, int minPrice, int maxPrice)
        {
            var categories = categoriesStr?.Split(',').Select(int.Parse).AsEnumerable();
            var products = UnitOfWork.StoredProcedures.SearchItemInfo(SystemUser?.Id, minPrice: minPrice, maxPrice: maxPrice);
            var hasProducts = products.Count() == 0;
            var _minPrice = hasProducts ? 0 : products.Min(x => x.Price);
            var _maxPrice = hasProducts ? 0 : products.Max(x => x.Price);
            if (categories?.Count() > 0)
            {
                products = products.Where(x => UnitOfWork.StoredProcedures.CategoriesForProduct(x.ProductId).Any(y => categories.Contains(y.Id)));
            }
            var model = new IndexVM
            {
                Products = products.ChunkBy(6),
                CategoryHierarchy = UnitOfWork.StoredProcedures.GetCategoryHierarchy(),
                MinPrice = UnitOfWork.StoredProcedures.GetProductNumericValueByOption(ProductOption.MinPrice.GetDescription()),
                MaxPrice = UnitOfWork.StoredProcedures.GetProductNumericValueByOption(ProductOption.MaxPrice.GetDescription()),
                SelectedMinPrice = minPrice,
                SelectedMaxPrice = maxPrice,
                Categories = categories
            };
            return View("Index", model);
        }

        [HttpGet]
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