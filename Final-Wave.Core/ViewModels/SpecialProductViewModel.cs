using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.ViewModels
{
    public class SpecialProductViewModel

    {
        public int Productid { get; set; }
        public string ProductName { get; set; }
        public int Productsell { get; set; }
        public int productstar { get; set; }
        public int MainPrice { get; set; }
        public int? sepcialprice { get; set; }
        public DateTime? EndDiscount { get; set; }
        public string Productimg { get; set; }
        public int Productpriceid { get; set; }
    }
}
