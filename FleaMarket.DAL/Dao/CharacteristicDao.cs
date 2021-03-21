using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class CharacteristicDao : BaseDao<Characteristic>
    {
        public CharacteristicDao(IDbConnection connection) : base("dbo.Characteristics", connection) { }
    }
}
