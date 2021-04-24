using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class CategoryDao : BaseDao<Category>
    {
        public CategoryDao(IDbConnection connection) : base("dbo.Categories", connection) { }
    }
}
