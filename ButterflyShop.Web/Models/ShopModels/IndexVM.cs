using ButterflyShop.DAL.Models.StoredProcedureModels;
using System.Collections.Generic;

namespace ButterflyShop.Web.Models.ShopModels
{
    public class IndexVM
    {
        public IEnumerable<IEnumerable<ProductItemInfo_Result>> Products { get; set; }
        public IEnumerable<GetCategoryHierarchy_Result> CategoryHierarchy { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }

        public IndexVM()
        {
            Products = new List<List<ProductItemInfo_Result>>();
            CategoryHierarchy = new List<GetCategoryHierarchy_Result>();
        }
    }
}
