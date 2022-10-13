using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class UserViewModel
    {

        public string Id { get; set; }

        [Display(Name = "userName:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter your username.")]
        [StringLength(maximumLength: 40, MinimumLength = 4, ErrorMessage = "Your userName can't less than 4 and more than 40 characters.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "Invalid! Can't use these.")]
        public string UserName { get; set; }


        [Display(Name = "Email:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter your  Email!")]
        [EmailAddress(ErrorMessage = "Invalid Format!")]
        public string Email { get; set; }



        [Display(Name = "IsAdmin")]
        public byte IsAdmin { get; set; }


        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
    }

    public class ChangePasswordByAdminViewModel
    {
        public string Id { get; set; }
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Display(Name = "ConfirmNewPassword")]
        [Compare("NewPassword", ErrorMessage = "Your confirm passowrd doesn't match")]
        public string ConfirmNewPassword { get; set; }

    }

}
