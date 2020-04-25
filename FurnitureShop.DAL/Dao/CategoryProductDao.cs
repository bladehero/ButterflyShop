using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class CategoryProductDao : BaseDao<CategoryProduct>
    {
        public CategoryProductDao(IDbConnection connection) : base("dbo.CategoryProducts", connection) { }
    }
}
