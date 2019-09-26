using Microsoft.AspNetCore.Mvc;
using System;

namespace ButterflyShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult _Order()
        {
            return PartialView();
        }
        public IActionResult _OrderList(string search)
        {
            var orders = UnitOfWork.StoredProcedures.GetOrdersInfo_Admin(search);
            return PartialView(orders);
        }

        [HttpPost]
        public IActionResult DeleteOrRestoreOrder(int id)
        {
            bool success;
            bool? isDeleted = null;
            try
            {
                var order = UnitOfWork.Orders.FindById(id);
                success = UnitOfWork.Orders.DeleteOrRestore(order);
                isDeleted = order.IsDeleted;
            }
            catch (Exception)
            {
                success = false;
            }

            return Json(new { success, isDeleted });
        }
    }
}