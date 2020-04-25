using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class ProductImageDao : BaseDao<ProductImage>
    {
        public ProductImageDao(IDbConnection connection) : base("dbo.ProductImages", connection) { }
    }
}
