using System;
using System.ComponentModel.DataAnnotations;

namespace ButterflyShop.Web.Models.AccountModels
{
    public class UpdateUserInfoVM
    {
        [Required(ErrorMessage = "Ваше имя - обязательное поле!")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "Ваша эл. почта - обязательное поле!")]
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
