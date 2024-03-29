﻿using System;
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

     
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        [Display(Name ="fullDescription")]
        public string FullDescription { get; set; }

        public bool IsOrginal { get; set; }

        public int CategoryId { get; set; }


        [Display(Name = "MainPrice")]
        public int MainPrice { get; set; }

        [Display(Name = "SpecialPrice")]
        public int SpecialPrice { get; set; }

        public int count { get; set; }
        public DateTime CreatDate { get; set; }

        public int ProductPriceId { get; set; }
        public ICollection<ProductGalleryViewModel> Photos { get; set; }
       
 

    }
}
