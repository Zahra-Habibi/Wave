using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Entites
{
    public class Order
    {


        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }
        public string? ShortDescription { get; set; }
        public bool IsSend { get; set; }
        //public bool IsAccept { get; set; }

        public DateTime OrderTime { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product product { get; set; }

        public List<PrograssBar> prograssBars { get; set; }

    }
}
