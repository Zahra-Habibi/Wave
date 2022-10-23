using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Please enter the product title")]
        [MinLength(3, ErrorMessage = "product title can not be less than 3 character!")]
        [MaxLength(500, ErrorMessage = "Product title can not be more than 500 character!")]
        public string ProductName { get; set; }

        public int Price { get; set; }

        [Display(Name = "Product description ")]
        public string? ShortDescription { get; set; }

        [Display(Name = "Product Image ")]
        public string? ProductImage { get; set; }


        [Display(Name = "Image Alt")]
        [Required(ErrorMessage = "Please enter the image alt.")]
        public string Alt { get; set; }

        [Display(Name = "Image title")]
        [Required(ErrorMessage = "Please enter the image title.")]
        public string Title { get; set; }


        public DateTime ProductCreate { get; set; }

        [Display(Name = "AmountProduct")]
        [Required(ErrorMessage = "please enter the anoumt of product")]
        public int count { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public ICollection<ProductGalleryViewModel> Photos { get; set; }
        public int CategoryId { get; set; }
 

    }
}
