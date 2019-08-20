using ButterflyShop.DAL.Models;
using Dapper;
using System;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class UserDao : BaseDao<User>
    {
        public UserDao(IDbConnection connection) : base("dbo.Users", connection) { }

        public User FindByToken(Guid token) => Connection.QueryFirstOrDefault<User>($"select top 1 * from {TableName} where Token = {token}");
    }
}
