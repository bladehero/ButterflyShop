using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class OptionalParameterDao : BaseDao<OptionalParameter>
    {
        public OptionalParameterDao(IDbConnection connection) : base("dbo.OptionalParameters", connection) { }
    }
}
