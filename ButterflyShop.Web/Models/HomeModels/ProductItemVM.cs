using ButterflyShop.DAL.Models;

namespace ButterflyShop.Web.Models.HomeModels
{
    public class ProductItemVM
    {
        public Product  Product{ get; set; }
        public Item Item { get; set; }
        public string Image { get; set; }
    }
}
