using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class CharacteristicDao : BaseDao<Characteristic>
    {
        public CharacteristicDao(IDbConnection connection) : base("dbo.Characteristics", connection) { }
    }
}
