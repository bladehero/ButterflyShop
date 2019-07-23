using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class ProductImageDao : BaseDao<ProductImage>
    {
        public ProductImageDao(IDbConnection connection) : base("dbo.ProductImages", connection) { }
    }
}
