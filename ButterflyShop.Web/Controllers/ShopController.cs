using ButterflyShop.DAL.Models.StoredProcedureModels;
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

        [HttpGet]
        public IActionResult _Cart()
        {
            var model = new CartVM
            {
                CartItems = UnitOfWork.StoredProcedures.GetCartItemsInfo(SystemUser.Id)
            };
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult Cart()
        {
            var model = new CartVM
            {
                CartItems = UnitOfWork.StoredProcedures.GetCartItemsInfo(SystemUser.Id)
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            var model = new CheckoutVM
            {
                CartItems = UnitOfWork.StoredProcedures.GetCartItemsInfo(SystemUser.Id),
                OrderDeliveryTypes = UnitOfWork.OrderDeliveryTypes.FindAll(),
                OrderPaymentTypes = UnitOfWork.OrderPaymentTypes.FindAll()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Order(OrderVM model)
        {
            bool success;
            var message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    success = UnitOfWork.StoredProcedures.CreateOrder(SystemUser.Id, model.DeliveryTypeId.Value, model.PaymentTypeId.Value,
                        model.Email, model.FirstName, model.LastName, model.Phone, model.Address, model.City, model.Region);
                }
                else
                {
                    success = false;
                    message = ModelState.GetHtmlErrors();
                    return Json(new { success, message });
                }
            }
            catch (System.Exception)
            {
                success = false;
            }
            if (success)
            {
                message = "Ваш заказ был создан. Наш менеджер скоро свяжется с вами!";
            }
            else
            {
                message = "При создании заказа произошла ошибка! Обратитесь в службу поддержку.";
            }

            return Json(new { success, message });
        }

        [HttpPost]
        public IActionResult AddToCart(int itemId, int? quantity = null)
        {
            bool success;
            var message = string.Empty;
            var item = (CartItemsInfo_Result)null;
            try
            {
                var isZero = quantity.HasValue && quantity.Value == 0;
                item = UnitOfWork.StoredProcedures.MergeItemToCart(SystemUser.Id, itemId, isZero ? null : quantity, isZero);
                success = true;
                message = "Товар добавлен в корзину!";
            }
            catch (System.Exception)
            {
                success = false;
                message = "При добавлении товара произошла ошибка! Обратитесь в службу поддержку.";
            }

            return Json(new { success, message, item });
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int itemId)
        {
            bool success;
            var message = string.Empty;
            try
            {
                UnitOfWork.StoredProcedures.MergeItemToCart(SystemUser.Id, itemId, isDeleted: true);
                success = true;
                message = "Товар удален из корзины!";
            }
            catch (System.Exception)
            {
                success = false;
                message = "При добавлении товара произошла ошибка! Обратитесь в службу поддержку.";
            }

            return Json(new { success, message });
        }
    }
}