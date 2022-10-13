using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class ProductGallery
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Products { get; set; }
    }
}
