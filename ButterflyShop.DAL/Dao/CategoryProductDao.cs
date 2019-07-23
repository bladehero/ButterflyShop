using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class CategoryProductDao : BaseDao<CategoryProduct>
    {
        public CategoryProductDao(IDbConnection connection) : base("dbo.CategoryProducts", connection) { }
    }
}
