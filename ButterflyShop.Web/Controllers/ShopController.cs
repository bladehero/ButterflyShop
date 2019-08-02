﻿using ButterflyShop.Web.Models.ShopModels;
using Microsoft.AspNetCore.Mvc;

namespace ButterflyShop.Web.Controllers
{
    public class ShopController : BaseController
    {
        public IActionResult Index()
        {
            var model = new IndexVM
            {
                Products = UnitOfWork.StoredProcedures.GetItemsInfo(8),
            };
            return View();
        }

        public IActionResult Product(int id)
        {
            var model = new IndexVM
            {
                Product = UnitOfWork.Products.FindById(id),
                Products = UnitOfWork.StoredProcedures.GetItemsInfo(8),
                Categories = UnitOfWork.StoredProcedures.CategoriesForProduct(id),
                ProductImages = UnitOfWork.StoredProcedures.GetProductImages(id),
                Items = UnitOfWork.Items.Find(x => x.ProductId == id)
            };
            return View(model);
        }
    }
}