using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class OptionalParameterProductDao : BaseDao<OptionalParameterProduct>
    {
        public OptionalParameterProductDao(IDbConnection connection) : base("dbo.OptionalParameterProducts", connection) { }
    }
}
