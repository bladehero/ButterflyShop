using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class ProductImageDao : BaseDao<ProductImage>
    {
        public ProductImageDao(IDbConnection connection) : base("dbo.ProductImages", connection) { }
    }
}
