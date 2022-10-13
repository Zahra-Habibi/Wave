using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class AboutViewModel
    {

        public int Id { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Enter the title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Enter the Description")]
        public string Descriptions { get; set; }

        [Display(Name = "Image")]
        public string? Image{ get; set; }

        [Display(Name = "Addres")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "PhoneNumber")]
        [Phone]
        [MinLength(9, ErrorMessage = "The phonenumber should be atleast 9 character.")]
        [MaxLength(13, ErrorMessage = "The phonenumber cant not be more than 13 character.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Alt")]
        [Required(ErrorMessage = "Please enter the image Alt!")]
        public string Alt { get; set; }

    }
}
