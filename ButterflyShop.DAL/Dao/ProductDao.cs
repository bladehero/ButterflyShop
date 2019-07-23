using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class ProductDao : BaseDao<Product>
    {
        public ProductDao(IDbConnection connection) : base("dbo.Products", connection) { }
    }
}
