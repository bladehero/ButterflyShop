using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class CharacteristicProductDao : BaseDao<CharacteristicProduct>
    {
        public CharacteristicProductDao(IDbConnection connection) : base("dbo.CharacteristicProducts", connection) { }
    }
}
