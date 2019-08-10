using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class UserDao : BaseDao<User>
    {
        public UserDao(IDbConnection connection) : base("dbo.Users", connection) { }
    }
}
