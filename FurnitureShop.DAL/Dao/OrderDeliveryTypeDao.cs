﻿using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class OrderDeliveryTypeDao : BaseDao<OrderDeliveryType>
    {
        public OrderDeliveryTypeDao(IDbConnection connection) : base("dbo.OrderDeliveryTypes", connection) { }
    }
}