using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class CategoryDao : BaseDao<Category>
    {
        public CategoryDao(IDbConnection connection) : base("dbo.Categories", connection) { }
    }
}
