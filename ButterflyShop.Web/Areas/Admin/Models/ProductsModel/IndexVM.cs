using ButterflyShop.DAL.Models;
using System.Collections.Generic;

namespace ButterflyShop.Web.Areas.Admin.Models.ProductsModel
{
    public class IndexVM
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
