using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class CategoryDao : BaseDao<Category>
    {
        public CategoryDao(IDbConnection connection) : base("dbo.Categories", connection) { }
    }
}
