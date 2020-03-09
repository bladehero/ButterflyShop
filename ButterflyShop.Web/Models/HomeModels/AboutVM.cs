using FurnitureShop.DAL.Models;
using FurnitureShop.DAL.Models.StoredProcedureModels;
using System.Collections.Generic;

namespace FurnitureShop.Web.Models.HomeModels
{
    public class AboutVM
    {
        public IEnumerable<Brand> Brands { get; set; }
        public ProductItemInfo_Result Product { get; set; }
    }
}
