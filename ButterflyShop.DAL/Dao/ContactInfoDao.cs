using ButterflyShop.DAL.Models;
using System.Data;

namespace ButterflyShop.DAL.Dao
{
    public class ContactInfoDao : BaseDao<ContactInfo>
    {
        public ContactInfoDao(IDbConnection connection) : base("dbo.ContactInfo", connection) { }
    }
}
