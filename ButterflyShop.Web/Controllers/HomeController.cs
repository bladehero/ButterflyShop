﻿using ButterflyShop.Web.Models.HomeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
                NewItems = UnitOfWork.StoredProcedures.GetItemsInfo(8, newItems: true, userId: SystemUser?.Id),
                SaleItems = UnitOfWork.StoredProcedures.GetItemsInfo(8, saleItems: true, userId: SystemUser?.Id)
            };

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult About()
        {
            var model = new AboutVM
            {
                Brands = UnitOfWork.Brands.Random(3),
                Product = UnitOfWork.StoredProcedures.GetItemsInfo(1, saleItems: true).FirstOrDefault()
            };

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
