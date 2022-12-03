using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class JobViewModel
    {
        [Key]
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

        [Display(Name = "JobName")]
        public string JobName { get; set; }

        [Display(Name = "PhoneNumber")]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [MinLength(9, ErrorMessage = "The phonenumber should be atleast 9 character.")]
        [MaxLength(13, ErrorMessage = "The phonenumber cant not be more than 13 character.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Enter Your email!")]
        public string EmailAddress { get; set; }

        [Display(Name = ("description"))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "UserPhoto")]
        //public IFormFile Coverphoto { get; set; }
        public string? Image { get; set; }

        [Display(Name = ("Resume"))]
        //public IFormFile ResumePhoto { get; set; }
        public string? Resume { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public bool IsDelete { get; set; }
        public bool IsRead { get; set; }
        public int ProductId { get; set; }







    }
}
