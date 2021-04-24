using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class BrandDao : BaseDao<Brand>
    {
        public BrandDao(IDbConnection connection) : base("dbo.Brands", connection) { }
    }
}
