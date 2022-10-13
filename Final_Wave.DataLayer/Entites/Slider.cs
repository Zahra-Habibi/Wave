using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }

        public string Caption { get; set; }

        public string silderName { get; set; }

        public int sliderOrder { get; set; }

        public string? sliderImage { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
