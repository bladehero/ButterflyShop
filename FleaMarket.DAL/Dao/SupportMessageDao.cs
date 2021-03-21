using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class SupportMessageDao : BaseDao<SupportMessage>
    {
        public SupportMessageDao(IDbConnection connection) : base("dbo.SupportMessages", connection) { }
    }
}
