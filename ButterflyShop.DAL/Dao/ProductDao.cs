using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class ProductDao : BaseDao<Product>
    {
        public ProductDao(IDbConnection connection) : base("dbo.Products", connection) { }
    }
}
