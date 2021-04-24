using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class SupportMessageDao : BaseDao<SupportMessage>
    {
        public SupportMessageDao(IDbConnection connection) : base("dbo.SupportMessages", connection) { }
    }
}
