using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class OptionalParameterProductDao : BaseDao<OptionalParameterProduct>
    {
        public OptionalParameterProductDao(IDbConnection connection) : base("dbo.OptionalParameterProducts", connection) { }
    }
}
