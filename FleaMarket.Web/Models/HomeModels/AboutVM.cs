using FleaMarket.DAL.Models;
using FleaMarket.DAL.Models.StoredProcedureModels;
using System.Collections.Generic;

namespace FleaMarket.Web.Models.HomeModels
{
    public class AboutVM
    {
        public IEnumerable<Brand> Brands { get; set; }
        public ProductItemInfo_Result Product { get; set; }
    }
}
