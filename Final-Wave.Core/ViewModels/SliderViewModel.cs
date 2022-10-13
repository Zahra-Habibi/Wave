using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class SliderViewModel
    {
        public int SliderId { get; set; }
        [Display(Name = "Caption")]
        [Required(ErrorMessage = "Please enter the caption of slider!")]
        public string Caption { get; set; }

        [Display(Name = "name")]
        [Required(ErrorMessage = "Please enter the name of slider!")]
        public string silderName { get; set; }

        [Display(Name = "order")]
        [Required(ErrorMessage = "Please enter the slider order!")]
        public int sliderOrder { get; set; }

        [Display(Name = "iamge")]
        public string? sliderImage { get; set; }


        [Display(Name = "Alt")]
        [Required(ErrorMessage = "Please enter the slider Alt!")]
        public string Alt { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter the slider Title!")]
        public string Title { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
