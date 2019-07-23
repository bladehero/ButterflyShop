using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class OptionalParameterDao : BaseDao<OptionalParameter>
    {
        public OptionalParameterDao(IDbConnection connection) : base("dbo.OptionalParameters", connection) { }
    }
}
