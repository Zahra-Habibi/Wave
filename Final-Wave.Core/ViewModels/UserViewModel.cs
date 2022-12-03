using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class UserViewModel
    {

       
        public string Id { get; set; }

        [Display(Name = "FullName:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter your username.")]
        [StringLength(maximumLength: 40, MinimumLength = 3, ErrorMessage = "Your FullName can't less than 3 and more than 40 characters.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "Invalid! Can't use these.")]
        public string FullName { get; set; }


        [Display(Name = "Email:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter your  Email!")]
        [EmailAddress(ErrorMessage = "Invalid Format!")]
        public string Email { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter your  Password!")]
        [Display(Name ="Password")]
        [PasswordPropertyText]
        public string PasswordHash { get; set; }

        [Display(Name = "IsAdmin")]
        public byte IsAdmin { get; set; }


        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }

        [Display(Name ="UserImage")]
        [DataType(DataType.ImageUrl)]
        public string? usrimag { get; set; }

        public bool IsDelete { get; set; }
    }

    public class ChangePasswordByAdminViewModel
    {
        public string Id { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage ="Please Enter the new Password!")]
        public string NewPassword { get; set; }

        [Display(Name = "ConfirmNewPassword")]
        [Required(ErrorMessage ="Enter the confirmPassword!")]
        [Compare("NewPassword", ErrorMessage = "Your confirm passowrd doesn't match")]
        public string ConfirmNewPassword { get; set; } 

    }

    public class ChangePasswordViewModel
    {
        [Display(Name = "curremt Password")]
        [Required(ErrorMessage ="Please enter the old password!")]
        public string CurrentPassword { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "Please enter the New password!")]
        [StringLength(maximumLength: 30, MinimumLength = 4, ErrorMessage = "please enter between 4-30 charachter!")]
        public string NewPassword { get; set; }

        [Display(Name = "ConfirmNewPassword")]
        [Required(ErrorMessage = "Please enter the ConfirmNewPassword!")]
        [Compare("NewPassword", ErrorMessage = "Your confirm passowrd doesn't match")]
        public string ConfirmNewPassword { get; set; }

    }


}
