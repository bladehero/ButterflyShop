using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class SupportMessageDao : BaseDao<SupportMessage>
    {
        public SupportMessageDao(IDbConnection connection) : base("dbo.SupportMessages", connection) { }
    }
}
