using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class CategoryProductDao : BaseDao<CategoryProduct>
    {
        public CategoryProductDao(IDbConnection connection) : base("dbo.CategoryProducts", connection) { }
    }
}
