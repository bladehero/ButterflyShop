using ButterflyShop.DAL.Models;
using ButterflyShop.DAL.Models.StoredProcedureModels;
using System.Collections.Generic;

namespace ButterflyShop.Web.Models.ShopModels
{
    public class IndexVM
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
