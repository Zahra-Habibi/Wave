using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class Social
    {
        [Key]
        public int Id { get; set; }

        public string SocialName { get; set; }
        public string SocialLink { get; set; }

        public string? SocailImg { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }

        public bool IsDelete { get; set; }
    }
}
