using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
  public class About
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string? Image { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDelete { get; set; }
        public string Alt { get; set; }

    }
}
