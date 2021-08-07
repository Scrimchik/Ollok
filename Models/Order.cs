using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ollok.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CartId { get; set; }
        public Cart Cart { get; set; }
        [Required(ErrorMessage = "Введите пожалуйста ваше имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Введите пожалуйста вашу фамилию")]
        public string LastName { get; set; }
        public string City { get; set; }
        public bool IsPickup { get; set; }
        public string Mail { get; set; }
        [Required(ErrorMessage = "Введите пожалуйста ваш номер телефона")]
        public string PhoneNumber { get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; }
        public int? OrderSum { get { return Cart?.CartLines.Sum(t => t.productCost); }}
    }
}
