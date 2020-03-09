﻿using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class OrderStatusDao : BaseDao<OrderStatus>
    {
        public OrderStatusDao(IDbConnection connection) : base("dbo.OrderStatuses", connection) { }
    }
}
