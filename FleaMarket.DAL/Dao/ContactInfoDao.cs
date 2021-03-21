using FleaMarket.DAL.Models;
using System.Data;

namespace FleaMarket.DAL.Dao
{
    public class ContactInfoDao : BaseDao<ContactInfo>
    {
        public ContactInfoDao(IDbConnection connection) : base("dbo.ContactInfo", connection) { }
    }
}
