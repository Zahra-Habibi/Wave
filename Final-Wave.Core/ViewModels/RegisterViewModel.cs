using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class RegisterViewModel
    {
        public string Id { get; set; }

        [Display(Name = "username")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your username.")]
        //[RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "Do not use incorrect character .")]
        //[StringLength(maximumLength: 40, MinimumLength = 4, ErrorMessage = "You can not enter less than 4 and more than 40 character.")]
        public string FullName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter your  Password!")]
        [Display(Name = "Password")]
        [PasswordPropertyText]
        public string PasswordHash { get; set; }


        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "please enter the correct format.")]
        public string Email { get; set; }

        [Display(Name = "IsAdmin")]
        public byte IsAdmin { get; set; }

        [Display(Name = "UserImage")]
        public string? usrimag { get; set; }
    }
}
