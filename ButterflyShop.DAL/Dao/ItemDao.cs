using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class ItemDao : BaseDao<Item>
    {
        public ItemDao(IDbConnection connection) : base("dbo.Items", connection) { }
    }
}
