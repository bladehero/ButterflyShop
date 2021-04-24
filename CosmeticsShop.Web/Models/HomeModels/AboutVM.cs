using CosmeticsShop.DAL.Models;
using CosmeticsShop.DAL.Models.StoredProcedureModels;
using System.Collections.Generic;

namespace CosmeticsShop.Web.Models.HomeModels
{
    public class AboutVM
    {
        public IEnumerable<Brand> Brands { get; set; }
        public ProductItemInfo_Result Product { get; set; }
    }
}
