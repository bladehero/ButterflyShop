using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class BrandDao : BaseDao<Brand>
    {
        public BrandDao(IDbConnection connection) : base("dbo.Brands", connection) { }
    }
}
