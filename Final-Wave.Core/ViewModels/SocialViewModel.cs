using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class SocialViewModel
    {
        public int Id { get; set; }
        [Display(Name = "SocialName")]
        public string SocialName { get; set; }

        [Display(Name = "SocialLink")]
        public string SocialLink { get; set; }

        [Display(Name = "SocialImage")]
        public string? SocailImg { get; set; }


        [Display(Name = "Image")]
        [Required(ErrorMessage = "Please enter the image alt.")]
        public string Alt { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Please enter the image title.")]
        public string Title { get; set; }


    }
}

