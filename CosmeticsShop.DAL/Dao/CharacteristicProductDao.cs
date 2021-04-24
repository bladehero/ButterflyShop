using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class CharacteristicProductDao : BaseDao<CharacteristicProduct>
    {
        public CharacteristicProductDao(IDbConnection connection) : base("dbo.CharacteristicProducts", connection) { }
    }
}
