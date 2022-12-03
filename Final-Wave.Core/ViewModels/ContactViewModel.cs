using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class ContactViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your Phone number")]
        [Display(Name = "PhoneNumber")]
        [Phone]
        [MinLength(9, ErrorMessage = "The phonenumber should be atleast 9 character.")]
        [MaxLength(13, ErrorMessage = "The phonenumber cant not be more than 13 character.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your Email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Message")]
        public string Message { get; set; }
    }
}
