using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class OptionalParameterDao : BaseDao<OptionalParameter>
    {
        public OptionalParameterDao(IDbConnection connection) : base("dbo.OptionalParameters", connection) { }
    }
}
