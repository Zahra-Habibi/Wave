﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string? ProductImage { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }
   
        public string? ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public DateTime ProductCreate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool IsOrginal { get; set; }
        public int CategoryId { get; set; }

        [Display(Name = "MainPrice")]
        public int MainPrice { get; set; }

        [Display(Name = "SpecialPrice")]
        public int SpecialPrice { get; set; }

        public int count { get; set; }
        public DateTime CreatDate { get; set; }

        [ForeignKey("CategoryId")]
        public Category Categories { get; set; }

     
        public ICollection<ProductGallery> ProductGalleries { get; set; }
        public List<Order> Orders { get; set; }
        public List<ProductPrice> productPrices { get; set; }


    }
}
