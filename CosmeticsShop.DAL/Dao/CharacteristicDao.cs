using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class CharacteristicDao : BaseDao<Characteristic>
    {
        public CharacteristicDao(IDbConnection connection) : base("dbo.Characteristics", connection) { }
    }
}
