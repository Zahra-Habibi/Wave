using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }
        public string PositionName { get; set; }
        public string? ShortDesc { get; set; }
        public string? ImageUrl { get; set; }
        public string Alt { get; set; }
        public string Title { get; set; }
        public bool IsDelete { get; set; }
    }
}
