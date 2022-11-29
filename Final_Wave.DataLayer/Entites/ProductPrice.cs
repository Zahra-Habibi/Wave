using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class ProductPrice
    {
        [Key]
        public int ProductPriceId { get; set; }

        [Display(Name ="MainPrice")]
        [Required(ErrorMessage ="Please enter the product price")]
        public int MainPrice { get; set; }

        [Display(Name = "SpecialPrice")]
        public int SpecialPrice { get; set; }

        [Display(Name = "MaxOrderCount")]
        [Required]
        public int MaxOrderCount { get; set; }

        public int ProductId { get; set; }
        public int count { get; set; }
        public DateTime CreatDate { get; set; }
        public DateTime EndDateDiscount { get; set; }

        #region relation
        [ForeignKey("ProductId")]
        public Product product { get; set; }
        #endregion

    }
}

