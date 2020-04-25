using System.ComponentModel.DataAnnotations;

namespace FurnitureShop.Web.Models.AccountModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Имя пользователя - обязательное поле!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Эл. почта - обязательное поле!")]
        [EmailAddress(ErrorMessage = "Неверный формат эл. почты!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Пароль - обязательное поле!")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "{0} должен быть длиной от {2} символов.", MinimumLength = 6)]
        [Display(Name = "Пароль")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Пароль должен содержать не менее 8 символов и содержать 3 из 4 следующих символов: верхний регистр (A-Z), нижний регистр (a-z), число (0-9) и специальный символ (например,! @ # $% ^ & *)")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Повтор пароля - обязательное поле!")]
        [Display(Name = "Повтор пароля")]
        public string RepeatPassword { get; set; }
    }
}
