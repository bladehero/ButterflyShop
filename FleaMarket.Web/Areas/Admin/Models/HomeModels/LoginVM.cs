using System.ComponentModel.DataAnnotations;

namespace FleaMarket.Web.Areas.Admin.Models.HomeModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Логин - обязательное поле!")]
        [EmailAddress(ErrorMessage = "Неверный формат эл. почты!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пароль - обязательное поле!")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "{0} должен быть длиной от {2} символов.", MinimumLength = 6)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
