using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class ItemDao : BaseDao<Item>
    {
        public ItemDao(IDbConnection connection) : base("dbo.Items", connection) { }
    }
}
