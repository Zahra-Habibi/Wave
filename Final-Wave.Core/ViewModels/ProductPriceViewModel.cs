using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Final_Wave.Core.ViewModels
{
    public class ProductPriceViewModel
    {
        public int ProductPriceId { get; set; }

        [Display(Name = "MainPrice")]
        [Required(ErrorMessage = "Please enter the product price")]
        public int MainPrice { get; set; }

        [Display(Name = "SpecialPrice")]
        public int SpecialPrice { get; set; }

        [Display(Name = "MaxOrderCount")]
        [Required]
        public int MaxOrderCount { get; set; }

        public int ProductId { get; set; }

        [Display(Name = "ProducCount")]
        public int count { get; set; }

        [Display(Name ="CreateDate")]
        public DateTime CreatDate { get; set; }

        [Display(Name = "EndDateDiscount")]
        public DateTime EndDateDiscount { get; set; }

    }
}
