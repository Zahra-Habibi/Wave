using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter Your name!")]
        [MinLength(3, ErrorMessage = "You can not enter less than 3 character.")]
        [MaxLength(40, ErrorMessage = ("You can not enter more than 40 character."))]
        public string Name { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Enter Your Lastname!")]
        [MinLength(3, ErrorMessage = "You can not enter less than 3 character.")]
        [MaxLength(100, ErrorMessage = ("You can not enter more than 100 character."))]
        public string LastName { get; set; }

        [Display(Name = "PhoneNumber")]
        [Phone]
        [MinLength(9, ErrorMessage = "The phonenumber should be atleast 9 character.")]
        [MaxLength(13, ErrorMessage = "The phonenumber cant not be more than 13 character.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name = ("description"))]
        public string Description { get; set; }

        [Display(Name = "OrderTime")]
        public DateTime OrderTime { get; set; }
        public bool IsSend { get; set; }
        public string UserId { get; set; }

        public int ProductId { get; set; }
    }
}
