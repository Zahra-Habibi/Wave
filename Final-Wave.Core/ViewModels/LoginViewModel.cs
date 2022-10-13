using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your username.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "Do not use incorrect character .")]
        [StringLength(maximumLength: 40, MinimumLength = 4, ErrorMessage = "You can not enter less than 4 and more than 40 character.")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
