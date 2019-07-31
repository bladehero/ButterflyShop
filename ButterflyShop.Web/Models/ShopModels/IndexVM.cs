using ButterflyShop.DAL.Models.StoredProcedureModels;
using System.Collections.Generic;

namespace ButterflyShop.Web.Models.ShopModels
{
    public class IndexVM
    {
        public IEnumerable<ProductItemInfo_Result> Products { get; set; }
    }
}
