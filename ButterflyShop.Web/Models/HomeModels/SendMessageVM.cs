using System.ComponentModel.DataAnnotations;

namespace ButterflyShop.Web.Models.HomeModels
{
    public class SendMessageVM
    {
        [Required(ErrorMessage = "Ваше имя - обязательное поле!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ваша почта - обязательное поле!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Сообщение - обязательное поле!")]
        public string Message { get; set; }
        public bool IsNotRobot { get; set; }
    }
}
