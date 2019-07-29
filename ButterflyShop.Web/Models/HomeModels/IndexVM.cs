using ButterflyShop.DAL.Models;
using System.Collections.Generic;

namespace ButterflyShop.Web.Models.HomeModels
{
    public class IndexVM
    {
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<ProductItemVM> NewItems { get; set; }
        public IEnumerable<ProductItemVM> SaleItems { get; set; }

        public IndexVM()
        {
            Brands = new List<Brand>();
            NewItems = new List<ProductItemVM>();
            SaleItems = new List<ProductItemVM>();
        }
    }
}
