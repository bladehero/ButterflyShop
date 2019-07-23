using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class BrandDao : BaseDao<Brand>
    {
        public BrandDao(IDbConnection connection) : base("dbo.Brands", connection) { }
    }
}
