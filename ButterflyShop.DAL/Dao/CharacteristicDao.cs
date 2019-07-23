using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class CharacteristicDao : BaseDao<Characteristic>
    {
        public CharacteristicDao(IDbConnection connection) : base("dbo.Characteristics", connection) { }
    }
}
