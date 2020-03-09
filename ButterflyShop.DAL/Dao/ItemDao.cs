using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class ItemDao : BaseDao<Item>
    {
        public ItemDao(IDbConnection connection) : base("dbo.Items", connection) { }
    }
}
