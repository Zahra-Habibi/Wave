using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class ProductGalleryViewModel
    {
        [Display(Name = "productImage")]
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Please enter the image alt.")]
        public string Alt { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Please enter the image title.")]
        public string Title { get; set; }
    }
}
