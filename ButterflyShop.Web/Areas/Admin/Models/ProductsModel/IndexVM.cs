using ButterflyShop.DAL.Models.StoredProcedureModels;
using System.Collections.Generic;

namespace ButterflyShop.Web.Areas.Admin.Models.ProductsModel
{
    public class IndexVM
    {
        public IEnumerable<ProductsInfo_Admin_Result> Products { get; set; }
    }
}
