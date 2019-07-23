using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class RoleDao : BaseDao<Role>
    {
        public RoleDao(IDbConnection connection) : base("dbo.Roles", connection) { }
    }
}
