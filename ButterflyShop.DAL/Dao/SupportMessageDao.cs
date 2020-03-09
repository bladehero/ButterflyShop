using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class SupportMessageDao : BaseDao<SupportMessage>
    {
        public SupportMessageDao(IDbConnection connection) : base("dbo.SupportMessages", connection) { }
    }
}
