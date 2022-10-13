using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class ServicesViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter the service name.")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter the Description.")]
        public string Descriptions { get; set; }

        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Alt")]
        [Required(ErrorMessage = "Please enter the image alt.")]
        public string Alt { get; set; }

        [Display(Name = "title")]
        [Required(ErrorMessage = "Please enter the image title.")]
        public string Title { get; set; }



    }
}
