using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class BrandDao : BaseDao<Brand>
    {
        public BrandDao(IDbConnection connection) : base("dbo.Brands", connection) { }
    }
}
