using FurnitureShop.DAL.Models;
using System.Data;

namespace FurnitureShop.DAL.Dao
{
    public class ContactInfoDao : BaseDao<ContactInfo>
    {
        public ContactInfoDao(IDbConnection connection) : base("dbo.ContactInfo", connection) { }
    }
}
