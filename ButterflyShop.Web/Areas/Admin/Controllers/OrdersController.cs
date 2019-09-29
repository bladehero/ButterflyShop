using ButterflyShop.Web.Areas.Admin.Models.OrderModels;
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
        public IActionResult _Order(int id)
        {
            var model = new OrderVM
            {
                OrderId = id
            };

            var order = UnitOfWork.Orders.FindById(id);
            model.UserId = order.UserId;
            model.Address = order.Address;
            model.City = order.City;
            model.Email = order.Email;
            model.FirstName = order.FirstName;
            model.LastName = order.LastName;
            model.OrderDeliveryTypeId = order.OrderDeliveryType;
            model.OrderPaymentTypeId = order.OrderPaymentType;
            model.OrderStatusId = order.OrderStatus;
            model.Phone = order.Phone;
            model.Region = order.Region;
            model.OrderDeliveryTypes = UnitOfWork.OrderDeliveryTypes.FindAll();
            model.OrderPaymentTypes = UnitOfWork.OrderPaymentTypes.FindAll();
            model.OrderStatuses = UnitOfWork.OrderStatuses.FindAll();
            model.OrderProducts = UnitOfWork.StoredProcedures.GetOrderProductsInfo(order.UserId, id);
            model.TotalSum = UnitOfWork.StoredProcedures.GetOrderSum(id);

            return PartialView(model);
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