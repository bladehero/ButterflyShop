using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class RoleDao : BaseDao<Role>
    {
        public RoleDao(IDbConnection connection) : base("dbo.Roles", connection) { }
    }
}
