using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class PrograssBar
    {
        [Key]
        public int PrograssId { get; set; }
        public int Requirement { get; set; }
        public int Design { get; set; }
        public int Codind { get; set; }
        public int Testing { get; set; }
        public int Maintenance { get; set; }
        public string UserId { get; set; }
        public int orderid { get; set; }

        [ForeignKey("orderid")]
        public Order order { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser user { get; set; }


        public DateTime OrderTime { get; set; } = DateTime.UtcNow;

    }
}
