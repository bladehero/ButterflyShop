using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ButterflyShop.Web.Models.ShopModels;
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

        public IActionResult Product()
        {
            var model = new IndexVM
            {
                Products = UnitOfWork.StoredProcedures.GetItemsInfo(8),
            };
            return View(model);
        }
    }
}