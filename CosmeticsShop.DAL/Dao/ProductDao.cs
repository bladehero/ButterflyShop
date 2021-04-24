using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class ProductDao : BaseDao<Product>
    {
        public ProductDao(IDbConnection connection) : base("dbo.Products", connection) { }
    }
}
