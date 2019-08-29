using ButterflyShop.DAL.Models;
using ButterflyShop.DAL.Models.StoredProcedureModels;
using System.Collections.Generic;

namespace ButterflyShop.Web.Models.HomeModels
{
    public class AboutVM
    {
        public IEnumerable<Brand> Brands { get; set; }
        public ProductItemInfo_Result Product { get; set; }
    }
}
