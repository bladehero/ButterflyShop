using System;

namespace ButterflyShop.DAL.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthdate { get; set; }
        public int RoleId { get; set; }
    }
}
