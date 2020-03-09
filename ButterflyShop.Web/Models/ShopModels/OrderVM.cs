using System.ComponentModel.DataAnnotations;

namespace FurnitureShop.Web.Models.ShopModels
{
    public class OrderVM
    {
        [Required(ErrorMessage = "Эл. почта - обязательное поле!")]
        [EmailAddress(ErrorMessage = "Неверный формат эл. почты!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Имя - обязательное поле!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Фамилия - обязательное поле!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Телефон - обязательное поле!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Адрес - обязательное поле!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Город - обязательное поле!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Область - обязательное поле!")]
        public string Region { get; set; }
        [Required(ErrorMessage = "Доставка - обязательное поле!")]
        public int? DeliveryTypeId { get; set; }
        [Required(ErrorMessage = "Тип оплаты - обязательное поле!")]
        public int? PaymentTypeId { get; set; }
    }
}
