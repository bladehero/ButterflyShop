using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class CharacteristicProductDao : BaseDao<CharacteristicProduct>
    {
        public CharacteristicProductDao(IDbConnection connection) : base("dbo.CharacteristicProducts", connection) { }
    }
}
