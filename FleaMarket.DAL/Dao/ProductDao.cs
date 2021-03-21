using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class ProductDao : BaseDao<Product>
    {
        public ProductDao(IDbConnection connection) : base("dbo.Products", connection) { }
    }
}
