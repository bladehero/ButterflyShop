﻿using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class OrderProductDao : BaseDao<OrderProduct>
    {
        public OrderProductDao(IDbConnection connection) : base("dbo.OrderProducts", connection) { }
    }
}
