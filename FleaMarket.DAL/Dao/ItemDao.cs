using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class ItemDao : BaseDao<Item>
    {
        public ItemDao(IDbConnection connection) : base("dbo.Items", connection) { }
    }
}
