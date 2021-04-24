using CosmeticsShop.DAL.Models;
using System.Data;

namespace CosmeticsShop.DAL.Dao
{
    public class ContactInfoDao : BaseDao<ContactInfo>
    {
        public ContactInfoDao(IDbConnection connection) : base("dbo.ContactInfo", connection) { }
    }
}
