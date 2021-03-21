using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class RoleDao : BaseDao<Role>
    {
        public RoleDao(IDbConnection connection) : base("dbo.Roles", connection) { }
    }
}
