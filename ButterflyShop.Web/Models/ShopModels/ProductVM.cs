using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButterflyShop.Web.Models.ShopModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<ProductItemInfo_Result> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ProductImage> ProductImages { get; set; }
        public IEnumerable<Item> Items { get; set; }

        public IndexVM()
        {
            Products = new List<ProductItemInfo_Result>();
            Categories = new List<Category>();
            ProductImages = new List<ProductImage>();
        }
    }
}
