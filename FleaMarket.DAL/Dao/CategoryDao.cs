using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class CategoryDao : BaseDao<Category>
    {
        public CategoryDao(IDbConnection connection) : base("dbo.Categories", connection) { }
    }
}
