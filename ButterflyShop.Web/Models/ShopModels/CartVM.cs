﻿using ButterflyShop.DAL.Models.StoredProcedureModels;
using System.Collections.Generic;
using System.Linq;

namespace ButterflyShop.Web.Models.ShopModels
{
    public class CartVM
    {
        public IEnumerable<CartItemsInfo_Result> CartItems { get; set; }
        public double Sum => CartItems.Sum(x => x.Price * x.Quantity);
    }
}
