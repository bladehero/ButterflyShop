using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class ProductImageDao : BaseDao<ProductImage>
    {
        public ProductImageDao(IDbConnection connection) : base("dbo.ProductImages", connection) { }
    }
}
